using UnityEngine;
using System.Collections;

public class Click
{

    //    public float monsterHealth = 10f;
    public int playerDamage = 1;
    public bool upgraded = false;
    private int upgradeCost = 1;
    public int autoClick = 0;
    public bool acActivate = false;

    public void upgradeDamage()
    {
        upgradeCost *= 2;
        playerDamage = playerDamage * 2;
    }

    public int getUpgradeCost()
    {
        return (upgradeCost);
    }

    public int clickDamage()
    {
        /*		if (Input.GetMouseButtonDown(0))
                    monsterHealth = monsterHealth - playerDamage; 
        */
        //        Debug.Log ( "You have clicked the monster ");
        return (playerDamage);
    }

    // the actial function
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