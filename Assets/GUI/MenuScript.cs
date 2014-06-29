using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	
	public int currentLevelID;

	public GUIStyle background;
	public GUIStyle backdrop;

	public GUIStyle imageMain;
	public GUIStyle imageSettings;
	public GUIStyle imageCredits;

	public GUIStyle text;

	bool optionsMenuActive = false;
	bool creditsMenuActive = false;

	int buttonHeight = 35;
	int buttonOffset = 5;
	int headerOffset = 40;
	int boxHeight;

	// Use this for initialization
	void Start () {
		if(DataScript.menuActive)
			Time.timeScale = 0.0f;
		else
			Time.timeScale = 1.0f;

		DataScript.currentLevelID = currentLevelID;

		DataScript.volume = AudioListener.volume;
	}
	
	// Update is called once per frame
	void Update () {
		// open menu on esc
		if(Input.GetKeyDown(KeyCode.Escape)){
			DataScript.menuActive = true;
			Time.timeScale = 0.0f;
		}
	}

	// Gui stuff is done here
	void OnGUI () {
		if (!DataScript.menuActive)
			return;
		// Determine the screen size
		int h = Screen.height;
		int w = Screen.width;
		int hc = h / 2;
		int wc = w / 2;

		// geometry calculations
		int numButtons = 6;
		boxHeight = 58 + numButtons * buttonHeight + (numButtons - 1) * buttonOffset;

		// backdrop
		GUI.Box(new Rect(0,0,w,h), "", backdrop);

		if (optionsMenuActive)
			DrawOptionsMenus (w, h, wc, hc);
		else if (creditsMenuActive)
			DrawCreditsMenu (w,h,wc,hc);
		else
			DrawMainMenu (w,h,wc,hc);
	}

	void DrawMainMenu(int w, int h, int wc, int hc)
	{
		// background image
		GUI.Box (new Rect (w - 256 - 30, h - 256 - 30, 256, 256), "", imageMain);
		
		// background
		GUI.Box (new Rect (wc - 200, hc - boxHeight/2, 400, boxHeight), "Main Menu", background);

		// button to start/continue the game
		if (GUI.Button (new Rect (wc - 180, 
		                          hc - boxHeight/2 + headerOffset + 0*buttonHeight + 0*buttonOffset, 
		      				      360, 35), "Continue")) {
			DataScript.menuActive = false;
			Time.timeScale = 1.0f;
		}

		// button to restart the current level
		if (GUI.Button (new Rect (wc - 180, 
		                          hc - boxHeight/2 + headerOffset + 1*buttonHeight + 1*buttonOffset,
		                          360, 35), "Restart Level")) {
			DataScript.menuActive = false;
			Application.LoadLevel(currentLevelID);
		}

		// button to restart the entire game
		if (GUI.Button (new Rect (wc - 180, 
		                          hc - boxHeight/2 + headerOffset + 2*buttonHeight + 2*buttonOffset,
		                          360, 35), "New Game")) {
			DataScript.menuActive = false;
			Application.LoadLevel(DataScript.firstLevelID);
		}

		// button to enter the options menu (and control reference)
		if (GUI.Button (new Rect (wc - 180, 
		                          hc - boxHeight/2 + headerOffset + 3*buttonHeight + 3*buttonOffset,
		                          360, 35), "Settings")) {
			optionsMenuActive = true;
		}

		// button to display the credits
		if (GUI.Button (new Rect (wc - 180, 
		                          hc - boxHeight/2 + headerOffset + 4*buttonHeight + 4*buttonOffset,
		                          360, 35), "Credits")) {
			creditsMenuActive = true;
		}

		// button to quit the game
		if (GUI.Button (new Rect (wc - 180, 
		                          hc - boxHeight/2 + headerOffset + 5*buttonHeight + 5*buttonOffset,
		                          360, 35), "Quit")) {
				Application.Quit ();
		}
	}

	void DrawOptionsMenus(int w, int h, int wc, int hc)
	{
		// controls text
		string controls = "<b>Stario:</b> \n" +
						"Move: W, A, S, D \n" +
						"Jump: Space \n" +
						"Camera: Mouse (move), mousewheel (zoom) \n \n" +
						"<b>Browser:</b> \n" +
						"Move: Left gamepad analog stick \n" +
						"Jump: A      Interact: X \n" +
						"Camera: Right gamepad analog stick \n" +
						"Zoom: Gamepad triggers (TL, TR)";
	

		// background image
		GUI.Box (new Rect (w - 256 - 30, h - 256 - 30, 256, 256), "", imageSettings);
		
		// background
		GUI.Box (new Rect (wc - 200, hc - boxHeight/2, 400, boxHeight), "Settings", background);

		// Text
		GUI.Box (new Rect (wc - 200 + 40, hc - boxHeight/2 + 33, 400, boxHeight), controls, text);

		// sound slider
		GUI.Box (new Rect (wc - 200 + 40, h - 256 - 10, 400, boxHeight), "<b>Volume:</b>", text);
		GUI.Box (new Rect (wc - 200 + 40, h - 256 + 17, 20, boxHeight), "Min", text);
		GUI.Box (new Rect (wc - 200 + 333, h - 256 + 17, 20, boxHeight), "Max", text);
		DataScript.volume = GUI.HorizontalSlider (new Rect (wc - 160, h - 256 + 5, 320, 10), DataScript.volume, 0.0f, 1.0f);
		AudioListener.volume = DataScript.volume;

		// button to go back
		if (GUI.Button (new Rect (wc - 180, 
		                          hc - boxHeight/2 + headerOffset + 5*buttonHeight + 5*buttonOffset,
		                          360, 35), "Back")) {
			optionsMenuActive = false;
		}
	}

	void DrawCreditsMenu(int w, int h, int wc, int hc)
	{
		// credit text
		string credits = "Prototype for \n" +
						 "<b>Game Engine Architecture</b> \n \n" +
						 "Made by: \n \n" +
						 "<b>Alexander Roewer \n" +
						 "Anne-Lena Simon \n" +
						 "Manuel Kosta \n" +
						 "Philipp Schladitz \n" +
						 "Sebastian Rohde</b> \n \n"+
						 "Supported by Acagamics";

		// background image
		GUI.Box (new Rect (w - 256 - 30, h - 256 - 30, 256, 256), "", imageCredits);
		
		// background
		GUI.Box (new Rect (wc - 200, hc - boxHeight/2, 400, boxHeight), "Credits", background);

		// Text
		GUI.Box (new Rect (wc - 200 + 40, hc - boxHeight/2 + 40, 400, boxHeight), credits, text);
		
		// button to go back
		if (GUI.Button (new Rect (wc - 180, 
		                          hc - boxHeight/2 + headerOffset + 5*buttonHeight + 5*buttonOffset,
		                          360, 35), "Back")) {
			creditsMenuActive = false;
		}
	}
}
