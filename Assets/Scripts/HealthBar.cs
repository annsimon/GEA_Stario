using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	private int maxHealth = 4; 
	public int curHealth = 4; 
	public int score = 0;
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
		adjustCurHealth (0) ; 
	
	}

	void OnGUI () {


		GUI.DrawTexture (new Rect (Screen.width - 120, 5, 60, 54), shard);
		GUI.Box (new Rect (Screen.width - 50, 17, 40, 30), ""+score);

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
		
		curHealth += adj;
		
		if(curHealth < 0)
			curHealth = 0;
		
		if(curHealth > maxHealth)
			curHealth = maxHealth;
		
		if(maxHealth < 1)
			maxHealth = 1;
		
		healthBarLength = (Screen.width / 4) * (curHealth / (float)maxHealth);
		
	} 

	public void adjustScore (int sc) {
		score += sc;
	}
}
