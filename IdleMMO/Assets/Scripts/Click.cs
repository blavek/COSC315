using UnityEngine;
using System.Collections; 

public class Click {
	
//    public float monsterHealth = 10f;
    public int playerDamage = 1; 
    public bool upgraded = false;

    public void upgradeDamage() {
        playerDamage = playerDamage * 2;
    }

    public int clickDamage () {
/*		if (Input.GetMouseButtonDown(0))
			monsterHealth = monsterHealth - playerDamage; 
*/		
//        Debug.Log ( "You have clicked the monster ");
        return (playerDamage);
	}
}