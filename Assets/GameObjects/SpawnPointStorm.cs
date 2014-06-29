using UnityEngine;
using System.Collections;

public class SpawnPointStorm : SpawnPoint {

	public StormCloud spawn;
	
	// Use this for initialization
	void Start () {
		spawn.activated = false;
		spawn.gameObject.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void ActivateTargetObject()
	{
		spawn.gameObject.renderer.enabled = true;
		spawn.activated = true;
	}
}
