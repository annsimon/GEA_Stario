using UnityEngine;
using System.Collections;

public class SpawnPointRain : SpawnPoint {

	public RainCloud spawn;

	// Use this for initialization
	void Start () {
		spawn.activated = false;
		spawn.gameObject.renderer.enabled = false;
		spawn.collider.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void ActivateTargetObject()
	{
		spawn.gameObject.renderer.enabled = true;
		spawn.collider.isTrigger = false;
		spawn.activated = true;
	}
}
