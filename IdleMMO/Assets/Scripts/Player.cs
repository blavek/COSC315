using UnityEngine;
using System.Collections;

public class Player : HeroClass {
    Click click = new Click();
    private int exp = 0;

    public void addXp(int amt) {
        exp += amt;
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
