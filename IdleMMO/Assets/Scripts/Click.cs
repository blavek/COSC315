using UnityEngine;
using System.Collections; 

public class Click{
	
public float monsterHealth = 10f;
public float playerDamage = 1f; 
public bool upgraded = false;
	
	void clickDamage () {
		if (Input.GetMouseButtonDown(0))
			monsterHealth = monsterHealth - playerDamage; 
		debug.Log ( "You have clicked the monster ");
		
		upgradedDamage () {
			if (upgraded = true);
			playerDamage = playerDamage * 2;
		}
		
	}
	
}