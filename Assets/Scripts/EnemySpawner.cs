using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float speed = 15.0f;
	public float width = 10f;
	public float height = 5f;
	public float padding = 7f;
	Vector3 x = Vector3.left;
	float xmin;
	float xmax;
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding; 
		
		foreach( Transform child in transform){
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += x * speed * Time.deltaTime;
		float nwX = Mathf.Clamp(transform.position.x, xmin, xmax);
		if (nwX == xmin || nwX == xmax){
			if (x == Vector3.right){
				x = Vector3.left;
			}else if(x == Vector3.left){
				x = Vector3.right;
			}
		}
		transform.position = new Vector3(nwX, transform.position.y,transform.position.z);
			
		}
	}
