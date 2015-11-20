using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {
    public Enemy enemyPrefab;
    private Enemy enemy;
    private Player player = new Player();
    private ArrayList guildies = new ArrayList();
    private int level = 1;
    private int subLevel = 10;
    private Slider enemyHp;
	private Slider xpBar;

    public int getLevel() {
        return (level);
    }

	public void buyGuildie() {
		Guildie g = new Guildie();
		guildies.Add(g);
	}

	// Use this for initialization
	void Start () {
		enemyHp = GameObject.FindWithTag("EnemyHp").GetComponent<Slider>();
		xpBar = GameObject.FindWithTag("XpBar").GetComponent<Slider>();
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
		enemyHp.value = enemy.getHealth();
		xpBar.value = player.getXp();
		xpBar.maxValue = player.getXpToLevel();
	}

	// Update is called once per frame
	void Update () {
        foreach (Guildie g in guildies) {
            enemy.recieveDamage(g.damagePerFrame(Time.deltaTime));
        }

        if (enemy.bIsDead) {
            if (--subLevel <= 0) {
                level++;
				if (level % 5 != 0) {
                	subLevel = 10;
				} else {
					subLevel = 1;
				}
            }

			player.addXp(enemy.xpDrop());
            GameObject.Destroy(enemy.gameObject);

            enemy = Instantiate(enemyPrefab);
            enemy.setHealth(level);
            enemy.setXP(level);
            enemy.boss(level);
			enemyHp.maxValue = enemy.getHealth();
        }

        if (enemy.getPlayerClickDamage() != player.getPlayerDamage()) {
            enemy.setPlayerClickDamage(player.getPlayerDamage());
        }

		updateUI();
    }
}
