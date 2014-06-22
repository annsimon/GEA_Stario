using UnityEngine;
using System.Collections;

public class DataScript : MonoBehaviour {

	// this script contains (partially static) variables for the global game state stuff we need
	public static bool menuActive = true;

	public static int time = 0;
	public static int maxHealth = 4; 
	public static int curHealth = 4; 
	public static int score = 0;

	// non-public
	float timer = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// increase the time taken every second as long as the menu is not active
		if (!menuActive) {
			timer -= Time.deltaTime;
			
			if(timer <= 0)
			{
				time++;
				timer = 1;
			}
		}
	}
}
