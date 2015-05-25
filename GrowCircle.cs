using UnityEngine;
using System.Collections;

public class GrowCircle : MonoBehaviour {

	float lifespan = 3.0f;
	float scaleBy = 4.0f;

	void Start () {
		iTween.ScaleTo (gameObject, scaleBy * Vector3.one, lifespan);
		iTween.FadeTo (gameObject, 0.0f, lifespan);
		StartCoroutine (DestroyAfterTime());
	}

	IEnumerator DestroyAfterTime() {
		yield return new WaitForSeconds (lifespan);
		Destroy (gameObject);
		yield return null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
