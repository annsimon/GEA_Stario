using UnityEngine;
using System.Collections;

public class Raindrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		if( collision.gameObject.tag != "RainCloud" )
			Hide();
		// TODO: if collision with player, reduce his health here
		//if (collision.gameObject.tag == "Player")
		//	collider.gameObject.GetComponent<SCRIPT>().reduceHealth();
	}

	public void Hide()
	{
		// make invisible
		this.gameObject.renderer.enabled = false;
		// disable collisions
		this.collider.isTrigger = true;
	}

	public void Show()
	{
		// make visible
		this.gameObject.renderer.enabled = true;
		// enable collisions
		this.collider.isTrigger = false;
	}
}
