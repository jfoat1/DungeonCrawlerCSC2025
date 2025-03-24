using System;
using System.Buffers;
using System.Collections;
using UnityEngine;

public class fightSceneManager : MonoBehaviour
{
    public GameObject healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Fight f = new Fight();
        StartCoroutine(f.startFight());
        GameObject playerHB = Instantiate(this.healthBar);
        Vector3 PlayerHBPos = Core.playerPos;
        PlayerHBPos.y = Core.playerPos.y + 1f;
        playerHB.transform.position = PlayerHBPos;
        GameObject monsterHB = Instantiate(this.healthBar);
        Vector3 monsterHBPos = Core.monsterPos;
        monsterHBPos.y = Core.monsterPos.y + 1f;
        monsterHB.transform.position = monsterHBPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
