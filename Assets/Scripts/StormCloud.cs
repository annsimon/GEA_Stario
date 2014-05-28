using UnityEngine;
using System.Collections;

// A StormCloud is an obstacle that changes between visible and invisible on a timer.
// Just add this as component to the object that should behave like a StormCloud.
public class StormCloud : MonoBehaviour {

	float timer;

	// Use this for initialization
	void Start () {
		timer = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		// change visibility state
		if(timer <= 0)
		{
			bool active = this.gameObject.renderer.enabled;
			this.gameObject.renderer.enabled = !active;
			this.collider.isTrigger = active; // more or less a hack but it works nicely
			if(active)
				timer = 1.5f;
			else
				timer = 4.0f;
		}
		//this.gameObject.
	}
}
