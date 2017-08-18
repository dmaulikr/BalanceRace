using UnityEngine;

public class EndTrigger : MonoBehaviour {

	public GameManager gameManager;
	// Use this for initialization
	void OnTriggerEnter () {
		gameManager.CompleteLevel ();
	}

}
