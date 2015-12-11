using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
    public Enemy enemyPrefab;
    private Enemy enemy;
	private List<Enemy> dieingEnemies = new List<Enemy>();
	private Guildie guildie;
    protected Player player = new Player();
    private List<Guildie> guildies = new List<Guildie>();
    private int level = 1;
    private int subLevel = 10;
    private Slider enemyHp;
	private Slider xpBar;
	private RectTransform clickDmg;
	private RectTransform guildDmg;
	private RectTransform enemyHP;
	private RectTransform numOfGuildies;
	public Button guildieUI;
	private List<Button> guildieButtons = new List<Button>();
	//public Text numberOfGuildies;
	//private RectTransform enemyHP;
	private float guildieDPS = 0;

	public void ability1() {
		player.click.activateAutoClick ();
	}
    public int getLevel() {
        return (level);
    }

	private void calcGuildieDPS() {
		Debug.Log ("Calc DEEPS");
		guildieDPS = 0;
		for (var i = 0; i < guildies.Count && i < guildieButtons.Count; i++) {
			if (guildieDPS + guildies[i].getDPS() < 0)
				break;

			guildieDPS += guildies[i].getDPS();
			Text [] tempText = guildieButtons[i].GetComponentsInChildren<Text>();
			tempText[0].text = "G: " + guildies[i].getGMember();
			tempText[1].text = "LVL: " + guildies[i].getLevel();
			tempText[2].text = "DPS: " + (int) guildies[i].getDPS();
			Debug.Log (tempText[2].text);
		}

		guildieDPS = (int) guildieDPS;
	}

	public void buyGuildie() {
		// Create the New Guildie
		Guildie g = new Guildie();
		if (g.getGNumber() > 36)
			return;

		guildies.Add(g);

		// Get canvas for the button
		GameObject tempCanvas = GameObject.FindGameObjectWithTag ("GuildButtons");
//		tempCanvas.AddComponent<Button>();
		// Create the guildies button
		Button tempButton = GameObject.Instantiate (guildieUI);

		// Add the button to the canvas
		tempButton.transform.SetParent (tempCanvas.transform);
        
		// set the button functionality
		tempButton.onClick.AddListener(guildies[guildies.Count - 1].guildieUpgrade);
		tempButton.onClick.AddListener(calcGuildieDPS);
		Text [] tempText = tempButton.GetComponentsInChildren<Text>();
		tempText[0].text = "G: " + g.getGMember();
		tempText[1].text = "LVL: " + g.getLevel();
		tempText[2].text = "DPS: " + (int) g.getDPS();

		// store the button for later use
		guildieButtons.Add(tempButton);
		calcGuildieDPS();
	}

	public void buyClickUpgrade() {
		player.buyClick();
	}

	public void buyGuildieUpgrade(){
		guildie.guildieUpgrade ();
	}

	// Use this for initialization
	void Start () {
		enemyHp = GameObject.FindWithTag("EnemyHp").GetComponent<Slider>();
		xpBar = GameObject.FindWithTag("XpBar").GetComponent<Slider>();
		clickDmg = GameObject.FindWithTag("ClickDamage").GetComponent<RectTransform>();
		guildDmg = GameObject.FindWithTag("GuildieDamage").GetComponent<RectTransform>();
		enemyHP = GameObject.FindWithTag ("EnemyHealth").GetComponent<RectTransform> ();
		numOfGuildies = GameObject.FindWithTag ("GuildMembers").GetComponent<RectTransform> ();


		//numberOfGuildies = GameObject.GetComponent<Text>;

		enemy = Instantiate(enemyPrefab);
        enemy.setPlayerClickDamage(player.getPlayerDamage());
        enemy.setHealth(level);
        enemy.setXP(level);
        enemy.boss(level);
//        Guildie g = new Guildie();
//        guildies.Add(g);
        enemyHp.maxValue = enemy.getHealth ();
	}

	void updateUI() {
		enemyHp.value = enemy.getHealth ();
		xpBar.value = player.getXp ();
		xpBar.maxValue = player.getXpToLevel ();
		clickDmg.GetComponent<Text> ().text = "Player Damage\n" + player.getPlayerDamage () + " Per Click";
		guildDmg.GetComponent<Text> ().text = "Guild Damage\n" + guildieDPS + " DPS";
		enemyHP.GetComponent<Text> ().text = "Enemy Health\n" + (int)enemy.getHealth ();

		if (guildies.Count > 0) {
			numOfGuildies.GetComponent<Text> ().text = "Number of Guildies\n" + guildies.Count;
		}
//			numOfGuildies.GetComponent<Text> ().text = "Number of Guildies\n" + guildie[0].getGNumber();
		//numberOfGuildies.GetComponent<Text>().text = "Enemy Health \n" + guildie.gNumber;
	}

	// Update is called once per frame
	void Update () {
//        foreach (Guildie g in guildies) {
//            enemy.recieveDamage(g.damagePerFrame(Time.deltaTime));
//		}
		enemy.recieveDamage(guildieDPS * Time.deltaTime);
		if (enemy.bIsSpawnable) {
			if (--subLevel <= 0) {
				level++;
				if (level % 5 != 0) {
					subLevel = 10;
				} else {
					subLevel = 1;
				}
			}

			Text lvl = GameObject.FindWithTag("Level").GetComponent<Text>();

			if (level % 5 != 0) {
				lvl.text = "Level " + level +"\n" + subLevel + " Enemies Left";
			} else {
				lvl.text = "Level " + level +"\nBOSS LEVEL";
			}




			dieingEnemies.Add (enemy);
			player.addXp(enemy.xpDrop());

			enemy = Instantiate(enemyPrefab);
			enemy.setHealth(level);
			enemy.setXP(level);
			enemy.boss(level);
			enemyHp.maxValue = enemy.getHealth();
		}
		
/*
		for (int i = 0; i < dieingEnemies.Count; i++) {
			if (e.bIsDead) {
				GameObject.Destroy (e.gameObject);
				dieingEnemies.Remove (e);
			}
		}
*/
		

        if (enemy.getPlayerClickDamage() != player.getPlayerDamage()) {
            enemy.setPlayerClickDamage(player.getPlayerDamage());
        }

		updateUI();
    }
}
