using UnityEngine;
using System.Collections;
 
public class SCR_playerMove : MonoBehaviour {

	private Transform myTransform;				// this transform
	private Vector3 destinationPosition;		// The destination Point
	private float destinationDistance;			// The distance between myTransform and destinationPosition
    
	public bool clickToMove=true;  
	public float clickMoveSpeed;						// The Speed the character will move
 	public float keyMoveSpeed = 0.05F;
	void GatherFight(){

		if (animation.IsPlaying ("Attack") || (animation.IsPlaying ("Pick_Up"))) {
			animation.Stop ("Idle");
				} else {
			animation.Play ("Idle");
				}

		}

	void Start () {
		myTransform = transform;							// sets myTransform to this GameObject.transform
		destinationPosition = myTransform.position;			// prevents myTransform reset
		animation.Play ("Idle");
	}
 
	void Update () {
 
        if(clickToMove==true){
			// keep track of the distance between this gameObject and destinationPosition
			destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);
	 
			if(destinationDistance < .5f){		// To prevent shakin behavior when near destination
				clickMoveSpeed = 0;
				GatherFight();
			}
			else if(destinationDistance > .5f){			// To Reset Speed to default
				clickMoveSpeed = 8;
				animation.Play("Run");
			}
	 
			// Moves the Player if the Left Mouse Button was clicked
			if (Input.GetMouseButtonDown(0)&& GUIUtility.hotControl ==0) {
	 
				Plane playerPlane = new Plane(Vector3.up, myTransform.position);
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float hitdist = 0.0f;
	 
				if (playerPlane.Raycast(ray, out hitdist)) {
					Vector3 targetPoint = ray.GetPoint(hitdist);
					destinationPosition = ray.GetPoint(hitdist);
					Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
					myTransform.rotation = targetRotation;
				}
			}
	 
			// Moves the player if the mouse button is hold down
			else if (Input.GetMouseButton(0)&& GUIUtility.hotControl ==0) {
	 
				Plane playerPlane = new Plane(Vector3.up, myTransform.position);
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float hitdist = 0.0f;
	 
				if (playerPlane.Raycast(ray, out hitdist)) {
					Vector3 targetPoint = ray.GetPoint(hitdist);
					destinationPosition = ray.GetPoint(hitdist);
					Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
					myTransform.rotation = targetRotation;
				}
			//	myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
			}
	 
			// To prevent code from running if not needed
			if(destinationDistance > .5f){
				myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, clickMoveSpeed * Time.deltaTime);
			}
		} 	

	}
}