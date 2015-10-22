using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
    public GameObject enemyPrefab;
    private GameObject enemy;
	// Use this for initialization
	void Start () {
        enemy = Instantiate(enemyPrefab);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
