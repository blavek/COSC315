﻿using UnityEngine;
using System.Collections;

public class Click {
    public int damage = 1;

	public float playerDamage = 1; 
	public float monsterHealth= 10; 

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update (){

		public class ClickDamage{

			if (Input.GetMouseButtonDown(0)){
				monsterHealth = monsterHealth - playerDamage;
				Debug.Log ("You have clicked the monster ");

			}
		}
	}