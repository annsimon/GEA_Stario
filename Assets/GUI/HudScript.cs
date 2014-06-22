using UnityEngine;
using System.Collections;

public class HudScript : MonoBehaviour {

	public GUIStyle hudText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (!DataScript.menuActive) {
			GUI.Box (new Rect (5, 5, 300, 20), "Time: "+DataScript.time, hudText);
			GUI.Box (new Rect (5, 25, 300, 20), "Score: "+DataScript.score, hudText);
		}
	}
}
