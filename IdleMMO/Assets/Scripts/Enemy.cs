﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
//Set up variables for health, damage, experience, and to determine if they're dead
    public float fHealth = 100f;
	public float copyHealth;
    public float fLostHealth;
    public int  iExp;
    public bool bIsDead;
    private int playerClickDamage = 0;

    //  public float minDam;
    //	public float maxDam;
    //  public float GDPS;

    // Use this for initialization
    public void getHealth() {
//        return (fHealth);
    }
    
    public void recieveDamage(float dmg) {
        fHealth -= dmg;
    }

	public void setHealth(int level){
		fHealth *= level;
	}
    //Gives experience
    public int xpDrop() {
        return (iExp);
    }

	public void setXP(int level){
		iExp = level;
	}
    public void setPlayerClickDamage(int dmg) {
        playerClickDamage = dmg;
    }

    public int getPlayerClickDamage() {
        return (playerClickDamage);
    }

	public float damagePerFrame(float time) {
		return ((copyHealth / 15) * time);
	}

	public void boss(int level){
		if (level % 5 == 0) {
			fHealth *= 10;
		}
	}

    void Start() {
		iExp = 0;
		copyHealth = fHealth;
		bIsDead = false;
    }

    // Update is called once per frame
    void Update() {
        //Checks to see how much damage it's taken
        if (fHealth <= 0) {
            bIsDead = true;
        }
        
        if (Input.GetMouseButtonDown(0)) {
            recieveDamage(playerClickDamage);
        }
    }
}

/*// Use this for initialization
void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
*/