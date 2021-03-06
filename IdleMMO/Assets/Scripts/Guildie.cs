﻿using UnityEngine;
using System.Collections;

public class Guildie : HeroClass {
    //Set up variables for health, damage, experience, guildie number, and to determine if they're dead
	public float fHealth = 500f;
    private float fDamage = 10f;
	public int gLevel;
	public int gExp;
	public int expCap = 25;
	public static int gNumber = 0;
	private int gMember;
	private static float tDelay = 1.0f;

	//Gets the level for the guildie
	public int getLevel() {
		return gLevel;
	}

	//A contstructor that sets up the different variables for the guildie
	public Guildie() {
		gNumber++;
		gMember = gNumber;
		gExp = 0;
		fDamage = 10f * gMember;
		fHealth = fHealth * gMember;
		Debug.Log("Created Guild Member " + gMember);
	}

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
	}

	//Gets the value for the DPS
	public float getDPS() {
		return (fDamage);
	}

	//Gets the value for the experience that the guildie has
	public float getEXP(){
		return (gExp);
	}

	//States how much it costs to buy a guildie which is based on the number of guildies
	public int getGMember() {
		return gMember;
	}

	//Gets the what number the guildie is
	public int getGNumber() {
		return gNumber;
	}

	//Determines how much any individual guildie costs
	public int guildiePrice(){
		int cost = 100 + 100 * gNumber;
		return cost;
	}

	//Upgrades the guildie until they reach the level cap of 100
	public void guildieUpgrade(){
		if (fDamage * 1.1f < 0)
			return;

		if (gLevel < 100) {
			gExp -= (25 * gLevel);
			fDamage = Mathf.Abs(fDamage * 1.1f);
			fHealth += 50f;
			gLevel++;
		}

		Debug.Log ("Guildie: " + gMember + " DPS: " + fDamage);
	}
	
	//Level up the guildie
	public void levelUp(int experience){
		gExp += experience;
		if (gExp >= expCap) {
			gLevel++;
			expCap += (25 * gLevel);
		}
	}
	
	//Receive damage from enemy
	public void recieveDamage(float damage) {
		fHealth -= damage;
	}
	
	//Calculates DPS
	public float damagePerFrame(float time) {
		if (gMember == 1)
			tDelay -= time;

		if (tDelay <= 0) {
			Debug.Log("Guildie " + gMember + "does " + fDamage + " dps");
			if (gMember == gNumber)
				tDelay = 1;
		}
		return (fDamage * time);
		//        GDPS = GDamage / Time.fixedTime;
	}
}