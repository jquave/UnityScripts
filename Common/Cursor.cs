using UnityEngine;
using System.Collections;

public class CursorEvent {
	public Vector3 pos;
	public CursorEvent(Vector3 _pos) {
		pos = _pos;
	}
}

/*
 * A cursor is used to detect clicks on the screen on a flat surface in the background using raycasts
 * */
public class Cursor : MonoBehaviour {

	public delegate void CursorDelegate(CursorEvent e);
	public CursorDelegate cursorDelegates;

	void Start () {
	
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Debug.Log(ray);
			int layerMask = (1<<8);
			if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, float.MaxValue, layerMask)) {
				//Usable u = hitInfo.collider.gameObject.GetComponent<Boulder>() as Boulder;
				GameObject hitGO = hitInfo.collider.gameObject;
				if(hitGO != null) {
					Debug.Log ("GetMouseButtonDown");
					if(cursorDelegates != null) {
						CursorEvent cursorEvent = new CursorEvent(hitInfo.point);
						cursorDelegates(cursorEvent);
					}
					else {
						Debug.LogWarning("A click occurred with no cursor delegates");
					}
				}
				else {
					Debug.LogWarning("A click occurred but hit no game object");
				}
				return;
			}
			else {
				Debug.LogWarning("A click occurred but hit nothing in the raycast");
			}
		}
	}
}
