using UnityEngine;
using System.Collections;

public class Click
{

    //Sets up the variables needed to upgrade the functions
    public int playerDamage = 1;
    public bool upgraded = false;
    private int upgradeCost = 1;
    public int autoClick = 0;
    public bool acActivate = false;

	//Upgrades the player damage and increases its cost
    public void upgradeDamage()
    {
        upgradeCost *= 2;
        playerDamage = playerDamage * 2;
    }

	//Gets how much it costs to upgrade the click damage
    public int getUpgradeCost()
    {
        return (upgradeCost);
    }

	//Does damage for each click
    public int clickDamage()
    {
        /*		if (Input.GetMouseButtonDown(0))
                    monsterHealth = monsterHealth - playerDamage; 
        */
        //        Debug.Log ( "You have clicked the monster ");
        return (playerDamage);
    }

    // the actual function
    public void activateAutoClick()
    {
        int autoClick = 0;

        // while loop that says wile autoClick == 0 damage the enemy and increase the variable
        while (autoClick <= 30)
        {
            Enemy enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.recieveDamage(playerDamage);
                autoClick++;
            }
            // checks to see if the autoClick has made it to 30 then resets it back

            /*if (autoClick == 30)
            {
                acActivate == false;
                autoClick = 1;*/
        }
    }
    
}