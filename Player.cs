using UnityEngine;
using System.Collections;

public interface Resettable {
	void Reset();
}

public class Player : MonoBehaviour, Resettable {

	Game game;
	Rigidbody rigidbody;

	Vector3 startPos;
	Quaternion startRot;

	void Start () {
		rigidbody = GetComponent<Rigidbody> () as Rigidbody;
		startPos = transform.position;
		startRot = transform.rotation;
		game = FindObjectOfType (typeof(Game)) as Game;
		rigidbody.useGravity = false;
	}

	void OnCollisionEnter(Collision c) {
		//Debug.Log (c.collider.name);
		if (c.gameObject.CompareTag ("Wall")) {
			// Hit a wall
			Debug.Log("collided with" + c.gameObject.name);
			Die();
		}
	}

	public void Reset() {
		transform.position = startPos;
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
		transform.rotation = startRot;
		//rigidbody.useGravity = true;
	}

	// Called when a condition is present that should cause the player to die/lose
	void Die() {
		// Show the death animations and effects on Player itself

		// Inform the game that the round should end
		game.DidLose();
	}

}
