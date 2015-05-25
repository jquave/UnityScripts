using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour, Resettable {

	public GameObject target;
	Vector3 startPos;

	public bool lockZ = true;

	// Use this for initialization
	void Start () {
		Reset ();
		startPos = transform.position;
	}

	public void Reset () {
		maxY = -float.MaxValue;
		transform.position = startPos;
	}
	
	// Update is called once per frame
	Vector3 lastPos;
	float maxY;
	void LateUpdate () {
		Vector3 newPos = target.transform.position;
		maxY = Mathf.Max (newPos.y, maxY);
		newPos.y = maxY;

		if (lockZ) {
			newPos.z = startPos.z;
		}

		Camera.main.orthographicSize = Mathf.Min( Mathf.Max(2, (newPos - startPos).magnitude) , 8);

		//newPos.z = 100.0f * Time.deltaTime + startPos.z;

		transform.position = newPos;

		lastPos = newPos;

	}
}
