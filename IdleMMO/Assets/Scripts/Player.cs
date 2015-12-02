using UnityEngine;
using System.Collections;

public class Player : HeroClass {
    public Click click = new Click();
    private int exp = 0;
	private int spendXp = 0;
	private int playerLevel = 1;
	private int xpToLevel = 100;

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

	public void buyClick() {
		if (spendXp >= click.getUpgradeCost()) {
			spendXp -= click.getUpgradeCost();
			click.upgradeDamage();
		}
	}

	public int getXpToLevel() {
		return xpToLevel;
	}

	public int getXp () {
		return exp;
	}

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
