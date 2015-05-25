using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject objectToSpawn;
	float emitFrequency = 1.1f;

	// Use this for initialization
	void Start () {
		StartCoroutine(Spawn());
	}

	Vector3 posAtTime() {
		float t = Time.timeSinceLevelLoad;
		Vector3 newPos = transform.position;
		//float xrand = Random.Range (0, Screen.width);

		float xrand = 0.5f * Screen.width * Mathf.Sin (Time.timeSinceLevelLoad) + 0.5f * Screen.width;

		Vector3 worldRandPos = Camera.main.ScreenToWorldPoint (new Vector3 (xrand, 0, 0));

		newPos.x = worldRandPos.x;

		return newPos;
	}

	void GiveInitialProperties(GameObject go) {
		Rigidbody rb = go.GetComponent<Rigidbody> () as Rigidbody;
		if (rb != null) {
			//float xv = Random.Range(0.0f,10.0f) - 5.0f;
			float xv = 0.0f;
			//rb.velocity = new Vector3(xv,-10.0f,0);
		}
	}

	IEnumerator Spawn() {

		// Animate the spawner between spawns
		//iTween.MoveTo (gameObject, posAtTime(), emitFrequency);


		Vector3 position = transform.position;
		GameObject newObj = GameObject.Instantiate (objectToSpawn, position, Quaternion.identity) as GameObject;
		GiveInitialProperties (newObj);
		yield return new WaitForSeconds(emitFrequency);
		StartCoroutine (Spawn ());
		yield return null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
