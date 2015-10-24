using UnityEngine;
using System.Collections;

public class Guildie : HeroClass {
    //Set up variables for health, damage, experience, and to determine if they're dead
//    public float GHealth = 10f;
//    public float minDam;
//    public float maxDam;
    private float fDamage = 10f;
//    public float GDPS;
//    public int GExp;
//    public bool GDead;

    // Use this for initialization
    void Start() {
//        fDamage = 10f;
//        maxDam = 1.5f;
    }

    // Update is called once per frame
    void Update() {
/*
        GDamage = Random.Range(minDam, maxDam);
        DPS();
        if (GHealth <= 0) {
            GDead = true;
        }
        if (GDead) {
            Destroy(gameObject);
        }
*/
    }

    //Calculates DPS
    public float damagePerFrame(float time) {
        Debug.Log(fDamage * time);
        return (fDamage * time);
//        GDPS = GDamage / Time.fixedTime;
    }
}