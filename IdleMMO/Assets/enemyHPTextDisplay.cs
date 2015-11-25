﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class enemyHPTextDisplay : Enemy{

	public Text enemyHPText;
	private RectTransform enemyHealth;
	
	// Use this for initialization
	void Start () {
		enemyHPText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		enemyHPText.text = getHealth().ToString();
		enemyHP.GetComponent<Text>().text = "Enemy Health \n" + player.getPlayerDamage() + " Per Click";
	}
}
