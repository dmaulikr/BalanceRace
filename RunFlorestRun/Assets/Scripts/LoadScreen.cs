using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreen : MonoBehaviour {

	[SerializeField]
	private int unitsCount;

	[SerializeField]
	private GameObject[] createPrefab;

	public GameObject player, endPoint;
	private Vector3 closeCorner, farCorner;
	private float constY =  0.5f, closeCornerX = 7f;

	void Start () {
		closeCorner = new Vector3 (closeCornerX,player.transform.position.y,player.transform.position.z);
		farCorner = new Vector3 (-closeCornerX, endPoint.transform.position.y, endPoint.transform.position.z);


		StartCoroutine (BuildUnits ());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator BuildUnits(){
		
		for(int i = 0; i < unitsCount; i++){
			Vector3 randPosition = new Vector3 (Random.Range (closeCorner.x, farCorner.x),constY, Random.Range (closeCorner.z, farCorner.z));
			Instantiate (createPrefab[Random.Range (0, createPrefab.Length)], randPosition, Quaternion.identity);
			yield return null;
		}
	}
}
