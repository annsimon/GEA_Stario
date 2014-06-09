﻿using UnityEngine;
using System.Collections;

// A StormCloud is an obstacle that changes between visible and invisible on a timer.
// Just add this as component to the object that should behave like a StormCloud.
public class StormCloud : MonoBehaviour {

	float timer;
	float damageTimer;
	public float visibleFor = 4.0f;
	public float invisibleFor = 1.5f;
	public int damage = 1;
	public float damageTickTime = 0.4f;

	// Use this for initialization
	void Start () {
		timer = invisibleFor;
		damageTimer = damageTickTime;
		this.collider.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		// change visibility state
		if(timer <= 0)
		{
			bool active = this.gameObject.renderer.enabled;
			this.gameObject.renderer.enabled = !active;
			if(active)
				timer = invisibleFor;
			else
				timer = visibleFor;
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		// TODO: let player lose health
		//if (collider.gameObject.tag == "Player")
		//	collider.gameObject.GetComponent<SCRIPT>().reduceHealth();
	}

	void OnTriggerStay(Collider collider)
	{
		// TODO: let player lose more health (called once per frame, so use timer)
		damageTimer -= Time.deltaTime;
		//if (damageTimer <= 0 && collider.gameObject.tag == "Player")
		//{
		//	collider.gameObject.GetComponent<SCRIPT>().reduceHealth();
		//	timer = damageTickTime;
		//}
	}
}
