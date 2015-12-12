using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	//Set up variables for health, damage, experience, 
	//to determine if they're dead, give the enemy its appearance, and animate the sprite
    private float fHealth = 100f;
	public float copyHealth;
    public float fLostHealth;
    public int  iExp;
    public float speed = 1f;
    public bool bIsDead;
    public bool bIsSpawnable;
	public bool unshrink;
    private int playerClickDamage = 0;
	public string enemySprite;
	public Sprite[] possibleSprites;


    //  public float minDam;
    //	public float maxDam;
    //  public float GDPS;

    // Used to get the enemy's health
    public float getHealth() {
        return fHealth;
    }
    
	//Allows the enemy to receive damage
    public void recieveDamage(float dmg) {
        fHealth -= dmg;
    }

	//Sets the health for the enemy based on what level the player is on
	public void setHealth(int level){
		fHealth *= level;
	}

    //Gives experience
    public int xpDrop() {
        return (iExp);
    }

	//Sets the experience the player gets to 10 times the level the player is on
	public void setXP(int level){
		iExp = level * 10;
	}

	//Sets the player click damage
    public void setPlayerClickDamage(int dmg) {
        playerClickDamage = dmg;
    }

	//Gets the player click damage
    public int getPlayerClickDamage() {
        return (playerClickDamage);
    }

	//Determines how much damage the enemy does per frame
	public float damagePerFrame(float time) {
		return ((copyHealth / 15) * time);
	}

	//Creates a boss every 5 levels with 10 times the health and twice the size
	public void boss(int level = 0){
		Game goLevel = GameObject.FindObjectOfType<Game>();
		level = goLevel.level;

		if (level % 5 == 0) {
			transform.localScale = transform.localScale * 2;
			fHealth *= 10;
		}
	}

	//Animates the enemy when it gets killed by the player
    public void deathAni()
    {
        //portion of movement per frame
        float directionx = -1;
        float directiony = Random.Range(-1, 1);
        transform.position = new Vector3(transform.position.x + Time.deltaTime * directionx * speed, transform.position.y + Time.deltaTime * directiony * speed, 0);
        if(transform.position.y <= -5)
        {
            bIsDead = true;
        }
    }

	//Sets the sprite for the enemy and slowly increase its size each level
	public void setSprite(){
		Game level = GameObject.FindObjectOfType<Game>();
		float lvlDelta = (float)level.level * .001f;
		if (lvlDelta > 3)
			lvlDelta = 3;

		int randint = Random.Range (0, possibleSprites.Length);
		gameObject.GetComponent<SpriteRenderer> ().sprite = possibleSprites [randint];
		transform.localScale = new Vector3(0.2F + lvlDelta, 0.2f + lvlDelta, 0.2f + lvlDelta);
//		Debug.Log (randint);
		//		enemySprite = possibleSprites[randint-1];
		/*if (level % 5 != 0) {
			int randint = Random.Range (1, 3);
			enemySprite = possibleSprites[randint-1];
		} else {
			enemySprite = possibleSprites[3];
		}*/
	}

	//Initializes the enemy
    void Start() {
		copyHealth = fHealth; //Variable to record the starting health of enemy
		bIsDead = false; //Sets the enemy to being alive
        gameObject.name = "Enemy"; 
		setSprite (); //Calls function to set the sprite
		boss (); //Calls function to determine if the enemy is a boss
    }

    // Update is called once per frame
    void Update() {
        //Checks to see how much damage it's taken
        if (fHealth <= 0) {
            //When the enemy's health is low enough, their death  animation starts and a new enemy spawns
            deathAni();
            bIsSpawnable = true;
        }

		//This unshrinks the enemy after it has been shrunk
		if (unshrink) {
			transform.localScale += new Vector3(0.02F, 0.02f, 0.02f);
			unshrink = false;
		}
        
		//The enemy shrinks and takes damage based on mouse clicks
        if (Input.GetMouseButtonDown(0)) {
			transform.localScale += new Vector3(-0.02F, -0.02f, -0.02f);
            recieveDamage(playerClickDamage);
			unshrink = true;
        }
    }
}
