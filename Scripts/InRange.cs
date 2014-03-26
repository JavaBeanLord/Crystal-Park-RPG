using UnityEngine;
using System.Collections;

public class InRange : MonoBehaviour {

	public Transform Player;
	public float MaxRange = 100f;
	public float MinRange = 3f;
	public Rigidbody projectile;
	public float speed = 20;


	void rightonme(){
		if ((System.Convert.ToBoolean (Vector3.Distance (transform.position, Player.position) < MinRange))) {
				//Take Away Health if in range

				} else {
					//Or Do Noting At All

				}
}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		rightonme ();

			

		 
	

	}
}



