using UnityEngine;
using System.Collections;

public class QTextField : MonoBehaviour {
	
	public GUISkin skin;
	
	public bool isVisible = false;
	
	// Use this for initialization
	void Start () {
		if(!isVisible) {
			renderer.enabled = false;
		}
	}
	
	private string _default = "email";
	private string email_field_string = "";
	
	void OnGUI() {
		GUI.skin.settings.cursorColor = Color.gray;
		
		Rect textFieldRect = BoundsToScreenRect(renderer.bounds);
		string fieldName = "signup_form";
		GUI.SetNextControlName (fieldName);
		email_field_string = GUI.TextField( textFieldRect, email_field_string, skin.FindStyle("mailchimp"));
		
		
		if (UnityEngine.Event.current.type == EventType.Repaint)
		{
			if (GUI.GetNameOfFocusedControl () == fieldName)
			{
				if (email_field_string == _default) email_field_string = "";
			}
			else
			{
				if (email_field_string == "") email_field_string = _default;
			}
		}
		
	}
	
	public Rect BoundsToScreenRect(Bounds bounds)
	{
		// Get mesh origin and farthest extent (this works best with simple convex meshes)
		Vector3 origin = Camera.main.WorldToScreenPoint(new Vector3(bounds.min.x, bounds.max.y, 0f));
		Vector3 extent = Camera.main.WorldToScreenPoint(new Vector3(bounds.max.x, bounds.min.y, 0f));
		
		// Create rect in screen space and return - does not account for camera perspective
		return new Rect(origin.x, Screen.height - origin.y, extent.x - origin.x, origin.y - extent.y);
	}
	
	
}

