using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
    public Enemy enemyPrefab;
    private Enemy enemy;
    private Player player = new Player();
    private ArrayList guildies = new ArrayList();

	// Use this for initialization
	void Start () {
        enemy = Instantiate(enemyPrefab);
        enemy.setPlayerClickDamage(player.getPlayerDamage());
        Guildie g = new Guildie();
        guildies.Add(g);
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Guildie g in guildies) {
//            enemy.recieveDamage(g.damagePerFrame(Time.deltaTime));
        }

        if (enemy.bIsDead) {
            player.addXp(enemy.xpDrop());
            Destroy(enemy);
            enemy = Instantiate(enemyPrefab);
        }
        if (enemy.getPlayerClickDamage() != player.getPlayerDamage()) {
            enemy.setPlayerClickDamage(player.getPlayerDamage());
        }

//            Debug.Log(Time.deltaTime);
    }
}
