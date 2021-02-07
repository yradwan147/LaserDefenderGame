using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject laserPrefab;
	public float speed = 15.0f;
	public float padding = 1f;
	float lastStep, timeBetweenSteps = 0.5f;
	float xmin;
	float xmax;
	float ymax;
	
	void Start(){
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		Vector3 upmost = Camera.main.ViewportToWorldPoint(new Vector3(0,1,distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
		ymax = upmost.y -padding; 
				
	}
	
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)){
			//transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y,transform.position.z);
		
		if (Input.GetKey(KeyCode.Space)){
			if(Time.time - lastStep > timeBetweenSteps){
				lastStep = Time.time;
				GameObject laser = Instantiate(laserPrefab,transform.position,Quaternion.identity) as GameObject;
				laser.transform.parent = transform;
		}
		//foreach(Transform child in transform){
			//while(true){
			//child.transform.position += Vector3.up * Time.deltaTime;
			//if (child.transform.position.y >= ymax){
				//Destroy(child);
			//}
		}
		}
	}
