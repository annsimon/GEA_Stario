using UnityEngine;
using System.Collections;

public class EndScript : MonoBehaviour {
	
	public GUIStyle backdrop;
	public GUIStyle background;
	public GUIStyle backgroundGameOver;
	public GUIStyle imageWin;
	public GUIStyle imageGameOver;
	public GUIStyle text;

	public AudioClip win;
	public AudioClip loss;

	public int healthBonus = 200;
	public int scoreBonus = 100;

	// Use this for initialization
	void Start () {
		if (DataScript.gameOver)
		{
			audio.clip = loss;
		}
		else
		{
			audio.clip = win;
		}
		audio.loop = true;
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		// Determine the screen size
		int h = Screen.height;
		int w = Screen.width;
		int hc = h / 2;
		int wc = w / 2;
		
		// backdrop
		GUI.Box(new Rect(0,0,w,h), "", backdrop);
		
		if (DataScript.gameOver)
			DrawGameOver (w, h, wc, hc);
		else 
			DrawWin(w, h, wc, hc);
	}

	void DrawGameOver(int w, int h, int wc, int hc)
	{
		// background image
		GUI.Box (new Rect (w - 256 - 30, h - 256 - 30, 256, 256), "", imageGameOver);
		
		// background
		GUI.Box (new Rect (wc - 200, hc - 150, 400, 300), "Game Over", backgroundGameOver);
		
		// button to restart the level
		if (GUI.Button (new Rect (wc - 180, 
		                          hc - 120 + 140,
		                          360, 35), "Try Again")) {
			ResetGameState();
			Application.LoadLevel(DataScript.currentLevelID);
		}
		// button to start a new game
		if (GUI.Button (new Rect (wc - 180, 
		                          hc - 120 + 180,
		                          360, 35), "New Game")) {
			ResetGameState();
			Application.LoadLevel(DataScript.firstLevelID);
		}
		// button to end the game
		if (GUI.Button (new Rect (wc - 180, 
		                          hc - 120 + 220,
		                          360, 35), "Quit")) {
			Application.Quit ();
		}
	}

	void DrawWin(int w, int h, int wc, int hc)
	{
		// determine points
		int timeTaken = DataScript.time;
		int timeMax = DataScript.maxTime;
		int timeBonusPoints = timeMax - timeTaken;
		timeBonusPoints = (timeBonusPoints < 0) ? 0 : timeBonusPoints;
		int healthLeft = DataScript.curHealth;
		int healthBonusPoints = healthLeft * healthBonus;
		int score = DataScript.score;
		int scoreBonusPoints = score * scoreBonus;
		int total = timeBonusPoints + healthBonusPoints + scoreBonusPoints;

		// score text
		string scoreText = 
				"Time bonus: "+timeMax+" - "+timeTaken+" = "+timeBonusPoints+" \n" +
				"Health bonus: "+healthLeft + " * "+healthBonus+" = "+healthBonusPoints+" \n" +
				"Shard bonus: "+score+" * "+scoreBonus+" = "+scoreBonusPoints+" \n \n"+
				"<size=22><b>           Total Score: "+total+"</b></size>";
		
		// background image
		GUI.Box (new Rect (w - 256 - 30, h - 256 - 30, 256, 256), "", imageWin);
		
		// background
		GUI.Box (new Rect (wc - 200, hc - 150, 400, 300), "Congratulations!", background);
		
		// Text
		GUI.Box (new Rect (wc - 200 + 40, hc - 150 + 60, 240, 240), scoreText, text);
		
		// button to restart the game
		if (GUI.Button (new Rect (wc - 180, 
		                          hc - 120 + 180,
		                          360, 35), "New Game")) {
			ResetGameState();
			Application.LoadLevel(DataScript.firstLevelID);
		}
		// button to end the game
		if (GUI.Button (new Rect (wc - 180, 
		                          hc - 120 + 220,
		                          360, 35), "Quit")) {
			Application.Quit ();
		}
	}

	void ResetGameState()
	{
		DataScript.curHealth = DataScript.maxHealth;
		DataScript.score = 0;
		DataScript.time = 0;
	}
}
