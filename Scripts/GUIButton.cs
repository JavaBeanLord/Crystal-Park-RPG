using UnityEngine;
using System.Collections;

public class GUIButton : MonoBehaviour {
	public Texture btnTexture;
	public Texture bashNow;
	public Rigidbody projectile;
	public float speed = 20;
	public GameObject player;

	void OnGUI() {
		if (!btnTexture) {
			Debug.LogError("Please assign a texture on the inspector");
			return;
		}

		if (GUI.Button (new Rect (371, 449, 50, 50), btnTexture)) {
			if (!player.animation.IsPlaying("Run"))
				player.animation.Play("Attack");

			Rigidbody instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation)as Rigidbody;
			instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0,speed));
				}

		if (GUI.Button(new Rect(436, 449, 50, 50),bashNow ))
			Debug.Log("Clicked the button with an image");
		

		if (GUI.Button(new Rect(501, 449, 50, 50), bashNow))
			Debug.Log("Clicked the button with an image");

		if (GUI.Button(new Rect(566, 449, 50, 50), bashNow))
			Debug.Log("Clicked the button with an image");

		if (GUI.Button(new Rect(631, 449, 50, 50), bashNow))
			Debug.Log("Clicked the button with an image");
	}
}