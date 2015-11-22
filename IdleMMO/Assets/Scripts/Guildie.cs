using UnityEngine;
using System.Collections;

public class Guildie : HeroClass {
    //Set up variables for health, damage, experience, and to determine if they're dead
	public float fHealth = 500f;
//    public float minDam;
//    public float maxDam;
    private float fDamage = 10f;
//    public float GDPS;
	public int gLevel;
	public int gExp;
	public int expCap = 25;
	public static int gNumber = 0;
//    public bool GDead;

    // Use this for initialization
    void Start() {
//        fDamage = 10f;
//        maxDam = 1.5f;
    }

    // Update is called once per frame
    void Update() {
/*
        GDamage = Random.Range(minDam, maxDam);
        DPS();
        if (GHealth <= 0) {
            GDead = true;
        }
        if (GDead) {
            Destroy(gameObject);
        }*/
	}

	//States how much it costs to buy a guildie which is based on the number of guildies
	public int guildiePrice(){
		int cost = 100 + 100 * gNumber;
		return cost;
	}

	//Upgrades the guildie
	public void guildieUpgrade(){
		gExp -= (25 * gLevel);
		fDamage = 10f * gLevel;
		fHealth += 50f;
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
//		Debug.Log(fDamage * time);
		return (fDamage * time);
		//        GDPS = GDamage / Time.fixedTime;
	}
}