using UnityEngine;
using System.Collections;

// Use:
// Attach this script to the character
// Add Rigidbody component to all movable objects
public class ObjectPusher : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// this script pushes all rigidbodies that the character touches
	public float pushPower = 2.0f;
	
	void OnControllerColliderHit (ControllerColliderHit hit)
	{
		// detection if Shard is hit
		if (hit.collider.gameObject.tag == "Shard")
		{
			HealthBar score = (HealthBar) GetComponent("HealthBar");
			score.adjustScore(1);
			AudioSource.PlayClipAtPoint(hit.collider.gameObject.audio.clip, hit.collider.transform.position);
			Destroy(hit.collider.gameObject);
			return;
		}

		// goal reached?
		if (hit.collider.gameObject.tag == "Goal") {
			DataScript.gameOver = false;
			Application.LoadLevel(DataScript.gameEndID);
		}

		Rigidbody body = hit.collider.attachedRigidbody;

		// no rigidbody
		if (body == null || body.isKinematic) 
			return;

		// don't push raindrops
		if (hit.gameObject.tag == "Raindrop")
						return;
		
		// We dont want to push objects below us
		if (hit.moveDirection.y < -0.3) 
			return;
		
		// Calculate push direction from move direction,
		// we only push objects to the sides never up and down
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		
		// If you know how fast your character is trying to move,
		// then you can also multiply the push velocity by that.
		
		// Apply the push
		body.velocity = pushPower * pushDir;
	}
}
