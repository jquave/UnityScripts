using UnityEngine;
using System.Collections;

public class Boulder : MonoBehaviour, Usable {

	bool canUse = true;
	Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}

	void Usable.Use() {
		if (canUse) {
			// Do something
			DropOnCars();
			StartCoroutine(Reenable());
		}
	}

	void DropOnCars() {
		rigidbody.velocity = 30.0f * Vector3.left;
		rigidbody.angularVelocity = 10.0f * Vector3.forward;
	}

	void ResetBoulder() {
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
		gameObject.transform.eulerAngles = Vector3.zero;
		transform.position = startPosition;
	}

	IEnumerator Reenable() {
		yield return new WaitForSeconds (3.0f);
		ResetBoulder();
		yield return null;
	}


	void OnCollisionEnter(Collision c) {
		Debug.Log(c.collider.name);
		Vehicle v = c.gameObject.GetComponent<Vehicle> () as Vehicle;
		if (v != null) {
			//v.rigidbody.useGravity = true;
			// Struck a car
			v.DidCrash();
		}
	}

}
