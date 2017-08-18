using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public PlayerMovement movement;


	void OnCollisionEnter(Collision collisionInfo){
		if(collisionInfo.collider.tag == "obstacle"){
			movement.enabled = false;
			FindObjectOfType<GameManager> ().EndGame();
		}
		if(collisionInfo.collider.tag == "endPoint"){
			movement.enabled = false;
			Debug.Log ("Finish");
		}
	}
}
