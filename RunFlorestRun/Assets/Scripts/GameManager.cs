using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	bool gameHasEnded = false;
	public float restartDelay = 2f;
	public GameObject completeLevelUI, restartLevelUI, breakBtn, gasBtn;

	// Use this for initialization
	public void EndGame(){
		if (gameHasEnded == false) {
			gameHasEnded = true;
			restartLevelUI.SetActive (true);
			Invoke("Restart", restartDelay);
		}
	}

	void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void CompleteLevel(){
		completeLevelUI.SetActive (true);
		breakBtn.SetActive (false);
		gasBtn.SetActive (false);
	}
}
