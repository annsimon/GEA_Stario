using UnityEngine;
using System.Collections;

public class SplashScreenScript : MonoBehaviour {
	
	public GUIStyle backdrop;
	public GUIStyle image;

	// Use this for initialization
	void Start () {
		StartCoroutine(StartGame(3.0f));
	}
	
	// Update is called once per frame
	void Update () {

	}

	// Gui stuff is done here
	void OnGUI () {
		// Determine the screen size
		int h = Screen.height;
		int w = Screen.width;
		int hc = h / 2;
		int wc = w / 2;
		// backdrop
		GUI.Box(new Rect(0,0,w,h), "", backdrop);
		
		// splash screen image
		GUI.Box(new Rect(wc-256,hc-256,512,512), "", image);
	}

	IEnumerator StartGame(float delay)
	{
		yield return new WaitForSeconds(delay);
		DataScript.menuActive = true;
		Application.LoadLevel(DataScript.firstLevelID);
	}
}
