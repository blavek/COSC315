using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {
    public Enemy enemyPrefab;
    private Enemy enemy;
    private Player player = new Player();
    private ArrayList guildies = new ArrayList();
    private int level = 1;
    private int subLevel = 1;
    private Slider enemyHp;

    public int getLevel() {
        return (level);
    }

	// Use this for initialization
	void Start () {
        enemyHp = Slider.FindObjectOfType<Slider>();  // Coincidently returned the bar I was looking for
        enemy = Instantiate(enemyPrefab);
        enemy.setPlayerClickDamage(player.getPlayerDamage());
        enemy.setHealth(level);
        enemy.setXP(level);
        enemy.boss(level);

        Debug.Log(enemy.fHealth);
        Guildie g = new Guildie();
        guildies.Add(g);
        enemyHp.maxValue = enemy.fHealth;
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Guildie g in guildies) {
            enemy.recieveDamage(g.damagePerFrame(Time.deltaTime));
        }

        if (enemy.bIsDead) {
            if (--subLevel <= 0) {
                level++;
                subLevel = 1;
            }

            player.addXp(enemy.xpDrop());
            GameObject.Destroy(enemy.gameObject);

            enemy = Instantiate(enemyPrefab);
            enemy.setHealth(level);
            enemy.setXP(level);
            enemy.boss(level);
            Debug.Log(enemy.fHealth);
            enemyHp.maxValue = enemy.fHealth;

            //            enemy.transform.position = new Vector3 (level, 0 ,0);
        }

        if (enemy.getPlayerClickDamage() != player.getPlayerDamage()) {
            enemy.setPlayerClickDamage(player.getPlayerDamage());
        }

        enemyHp.value = enemy.fHealth;
//            Debug.Log(Time.deltaTime);
    }
}
