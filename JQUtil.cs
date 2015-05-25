using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QV3 {
	Vector3 innerVector;
	public QV3(float x, float y, float z) {
		innerVector = new Vector3 (x, y, z);
	}
	public QV3 flippedX() {
		return new QV3(-innerVector.x, innerVector.y, innerVector.z);
	}
	public QV3 flippedZ() {
		return new QV3(innerVector.x, innerVector.y, -innerVector.z);
	}
	public QV3 flippedXZ() {
		return new QV3(-innerVector.x, innerVector.y, -innerVector.z);
	}
	public Vector3 toV3() {
		return innerVector;
	}
}

public enum Team {
	Player = 0,
	AI
}

public class JQUtil {
	public static T[] ExtractComponentsFromGameObjects<T> (GameObject[] itGameObjects) where T:UnityEngine.Component {
		int maxItemCount = itGameObjects.Length;
		T[] componentArray = new T[maxItemCount];
		int i = 0;
		foreach(GameObject go in itGameObjects) {
			T iComponent = go.GetComponent<T>() as T;
			if(iComponent != null) {
				componentArray[i] = iComponent;
				i++;
			}
		}
		return componentArray;
	}
	
	public static T[] FindGameObjectComponentsWithTag<T> (string tag) where T:UnityEngine.Component {
		GameObject [] gos = GameObject.FindGameObjectsWithTag (tag);
		return JQUtil.ExtractComponentsFromGameObjects<T> (gos);
	}
}

public interface Usable {
	void Use();
}