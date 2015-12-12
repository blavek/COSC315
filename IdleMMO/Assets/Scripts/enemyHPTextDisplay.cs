using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class enemyHPTextDisplay : Enemy {
	//Sets variable to create text for enemy health bar
	public Text enemyHPText;
	private RectTransform enemyHealth;
	
	// Use this for initialization
	void Start () {
		enemyHPText = GetComponent<Text>();
	}
	
	//Gets the varibale for health and turns it into an integer and then a string
	void Update () {
		int a;
		a = (int)getHealth ();
		enemyHPText.text = a.ToString();
//		enemyHP.GetComponent<Text>().text = "Enemy Health \n" + player.getPlayerDamage() + " Per Click";
	}
}
