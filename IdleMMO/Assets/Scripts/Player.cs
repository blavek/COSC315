using UnityEngine;
using System.Collections;

public class Player : HeroClass {
	//Sets up variables for click, experience, level, and experience to next level
    public Click click = new Click();
    private int exp = 0;
	private int spendXp = 0;
	private int playerLevel = 1;
	private int xpToLevel = 100;

	//Adds experience to level up character
    public void addXp(int amt) {
        exp += amt;
		spendXp += amt;

		if (exp >= xpToLevel) {
			exp = exp - xpToLevel;
			xpToLevel += (int)(xpToLevel * 1.5);
			playerLevel++;
		}

//		Debug.Log ("Adding " + amt + " exp");
    }

	//Upgrades the click damage
	public void buyClick() {
		if (spendXp >= click.getUpgradeCost()) {
			spendXp -= click.getUpgradeCost();
			click.upgradeDamage();
		}
	}

	//Gets value for the experience needed to level up
	public int getXpToLevel() {
		return xpToLevel;
	}

	//Gets the value for experience
	public int getXp () {
		return exp;
	}

	//Gets the value for click damage
    public int getPlayerDamage() {
        return (click.clickDamage());
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
