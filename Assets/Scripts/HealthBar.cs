using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	// static because they apply in all levels, don't they?
	private float healthBarLength;
	public Texture2D heart;
	public Texture2D emptyHeart;
	public Texture2D shard;
	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width / 4; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

		if (DataScript.menuActive)
			return;

		// score
		GUI.DrawTexture (new Rect (Screen.width - 120, 5, 60, 54), shard);
		GUI.Box (new Rect (Screen.width - 50, 20, 40, 25), ""+DataScript.score);

		// time
		GUI.Box (new Rect (Screen.width - 130, 65, 120, 25), "Time: "+DataScript.time);

		// health
		int curHealth = DataScript.curHealth;

		if (curHealth < 4) {
			if (curHealth < 3) {
				if (curHealth < 2) {
					if (curHealth < 1) {
						GUI.DrawTexture (new Rect (0, 0, 50, 50), emptyHeart);
						GUI.DrawTexture (new Rect (50, 0, 50, 50), emptyHeart);
						GUI.DrawTexture (new Rect (100, 0, 50, 50), emptyHeart);
						GUI.DrawTexture (new Rect (150, 0, 50, 50), emptyHeart);
						GUI.contentColor = Color.red;
						GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width - 20, Screen.height - 50), "Game Over");
					}else{
						GUI.DrawTexture (new Rect (0, 0, 50, 50), heart);
						GUI.DrawTexture (new Rect (50, 0, 50, 50), emptyHeart);
						GUI.DrawTexture (new Rect (100, 0, 50, 50), emptyHeart);
						GUI.DrawTexture (new Rect (150, 0, 50, 50), emptyHeart);
					}
				}else{
					GUI.DrawTexture (new Rect (0, 0, 50, 50), heart);
					GUI.DrawTexture (new Rect (50, 0, 50, 50), heart);
					GUI.DrawTexture (new Rect (100, 0, 50, 50), emptyHeart);
					GUI.DrawTexture (new Rect (150, 0, 50, 50), emptyHeart);
				}
			}else{
				GUI.DrawTexture (new Rect (0, 0, 50, 50), heart);
				GUI.DrawTexture (new Rect (50, 0, 50, 50), heart);
				GUI.DrawTexture (new Rect (100, 0, 50, 50), heart);
				GUI.DrawTexture (new Rect (150, 0, 50, 50), emptyHeart);
			}
		}else{
			GUI.DrawTexture (new Rect (0, 0, 50, 50), heart);
			GUI.DrawTexture (new Rect (50, 0, 50, 50), heart);
			GUI.DrawTexture (new Rect (100, 0, 50, 50), heart);
			GUI.DrawTexture (new Rect (150, 0, 50, 50), heart);
				}

		// code for healthbar instead of hearts
		/*if (curHealth == 0) {
			GUI.contentColor = Color.red;
			GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width - 20, Screen.height - 50), "Game Over");
		} 
		else 
		{
			GUI.backgroundColor = Color.red;
			GUI.Box (new Rect (maxHealth, maxHealth, Screen.width / 4, 20),curHealth+"/"+maxHealth);
			GUI.backgroundColor = Color.green;
			GUI.Box (new Rect (maxHealth, maxHealth, healthBarLength, 20), " ");
		}*/
		
	} 

	public void adjustCurHealth (int adj) {
		DataScript.curHealth += adj;
		
		if(DataScript.curHealth < 0)
			DataScript.curHealth = 0;
		
		if(DataScript.curHealth > DataScript.maxHealth)
			DataScript.curHealth = DataScript.maxHealth;
		
		if(DataScript.maxHealth < 1)
			DataScript.maxHealth = 1;
		
		healthBarLength = (Screen.width / 4) * (DataScript.curHealth / (float)DataScript.maxHealth);
		
	} 

	public void adjustScore (int sc) {
		DataScript.score += sc;
	}
}
