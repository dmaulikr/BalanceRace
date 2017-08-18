using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour {
	public Button gas_btn, break_btn;
	public Rigidbody rb;

	private float smooth = 0.4f, startSpeed = 50f, minSpeed = 10f, maxSpeed = 250f;
	private float forwardForce = 100f, sidewaysForce = 25f,timeModifier = 1200f;
	private float timer = 0, duration = 35f;
	private float minAngleRot = 0.025f, maxAngleRot = 0.15f;
	private Vector3 startRot;

	void Awake () {
		rb.AddForce (0, 0, startSpeed * smooth, ForceMode.VelocityChange);
		startRot = new Vector3(rb.rotation.x, rb.rotation.y, rb.rotation.z);
	}

	void FixedUpdate () {
		if (rb.velocity.z <= minSpeed)
			rb.AddForce (0, 0, minSpeed * smooth, ForceMode.VelocityChange);
		if (rb.velocity.z >= maxSpeed)
			rb.AddForce (0, 0, -minSpeed * smooth, ForceMode.VelocityChange);

		timer += Time.deltaTime;
		if (timer > duration)
			timer = 0;

		#if UNITY_STANDALONE_WIN || UNITY_EDITOR
		if(forwardForce > 0){
			Vector3 currentRot = new Vector3(rb.rotation.x, rb.rotation.y, rb.rotation.z);
//			Debug.Log(currentRot);
			if(!isKeyPressed() && (currentRot.y >= minAngleRot || currentRot.y <= -minAngleRot)){
				rb.transform.Rotate (-Vector3.Lerp (currentRot, startRot, (timer/duration) * smooth));// = ;
			}

			if(Input.GetKey ("d") || Input.GetKey (KeyCode.RightArrow)){
				rb.AddForce (sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
				if(currentRot.y <= maxAngleRot)
					rb.transform.Rotate (Vector3.Lerp(startRot, Vector3.up * Time.deltaTime * timeModifier, timer/duration));
			} else if(Input.GetKey ("a") || Input.GetKey (KeyCode.LeftArrow)){
				rb.AddForce (-sidewaysForce * Time.deltaTime, 0,  0, ForceMode.VelocityChange);
				if(currentRot.y >= -maxAngleRot)
					rb.transform.Rotate (Vector3.Lerp(startRot, -Vector3.up * Time.deltaTime * timeModifier, timer/duration));
			}
		}
		#endif
	}

	bool isKeyPressed(){
		if (Input.GetKey ("d")
		   || Input.GetKey (KeyCode.RightArrow)
		   || Input.GetKey ("a")
		   || Input.GetKey (KeyCode.LeftArrow))
			return true;

		return false;
	}
}
