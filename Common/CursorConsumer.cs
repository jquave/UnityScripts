using UnityEngine;
using System.Collections;

public class CursorConsumer : MonoBehaviour {

	public Cursor cursor;

	// Use this for initialization
	void Awake () {
		cursor = FindObjectOfType(typeof(Cursor)) as Cursor;
		if (cursor == null) {
			Debug.LogError("No cursor in scene");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
