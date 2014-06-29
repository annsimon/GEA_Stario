using UnityEngine;
using System.Collections;

public class BrowserBehaviorTemp : MonoBehaviour {

	private bool interact = false;
	public KeyCode key = KeyCode.M;
	public KeyCode keyController = KeyCode.JoystickButton0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		interact = Input.GetKeyDown(key) || Input.GetKeyDown(keyController);
	}
	
	void OnControllerColliderHit (ControllerColliderHit hit)
	{
		if (interact && hit.collider.gameObject.tag == "SpawnPoint") {
			SpawnPoint spawn = (SpawnPoint) hit.collider.gameObject.GetComponent("SpawnPoint");
			spawn.ActivateTargetObject();
		}
	}
}
