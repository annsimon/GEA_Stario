using UnityEngine;
using System.Collections;

public class RainCloud : MonoBehaviour {

	// TODO: find a way to directly assign the raindrop without needing an instance in the scene
	public Rigidbody raindrop;
	public float speed = 10f;
	public float spawnTime = 2f;
	public float offset = 0.5f;
	public int totalRaindrops = 5;

	float timer;
	int currentID;
	Rigidbody[] raindrops;
	Vector3 spawnPoint;

	// Use this for initialization
	void Start() 
	{
		raindrops = new Rigidbody[totalRaindrops];
		timer = spawnTime;
		spawnPoint = transform.position + offset*transform.forward;
	}
	
	void Spawn() 
	{
		if(raindrops[currentID] != null) 
		{
			//Reuse the object
			raindrops[currentID].position = spawnPoint;
			raindrops[currentID].rotation = transform.rotation;
			raindrops[currentID].velocity = transform.forward * speed;
			raindrops[currentID].GetComponent<Raindrop>().Show();
		} 
		else 
		{
			//Instantiate the object
			Rigidbody raindropClone = (Rigidbody) Instantiate(raindrop, spawnPoint, transform.rotation);
			raindropClone.velocity = transform.forward * speed;
			raindropClone.GetComponent<Raindrop>().Show();
			raindrops[currentID] = raindropClone;
		}

		if(currentID++>=totalRaindrops-1) 
			currentID = 0;
	}

	void Update() 
	{
		timer -= Time.deltaTime;

		if(timer <= 0)
		{
			AudioSource.PlayClipAtPoint(gameObject.audio.clip, transform.position);
			Spawn();
			timer = spawnTime;
		}
	}
}
