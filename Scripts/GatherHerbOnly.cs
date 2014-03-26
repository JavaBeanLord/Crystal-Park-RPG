using UnityEngine;
using System.Collections;

public class GatherHerbOnly : MonoBehaviour {
	public Transform Player;
	public float MinRange = 3f;
	private bool ShowButton=false;
	public GameObject PlayerBod;
	public string ItemName;
	// Use this for initialization
	void Start () {

	}
	void OnGUI(){
		if (!ShowButton) {
				} else {
			if(GUI.Button(new Rect(452, 415, 150, 30), "Gather "+ ItemName)){
				PlayerBod.animation.Play ("Pick_Up");
			}
				}

		}

	// Update is called once per frame
	void Update () {
		if ((System.Convert.ToBoolean (Vector3.Distance (transform.position, Player.position) < MinRange))) {
			ShowButton=true;
		} else {
			ShowButton=false;
		}
	}

}
