using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    private float BossSpawn;
    [SerializeField] float bossFireBulletDelayTime;
    float bossFireDelayTimer;
    [SerializeField] private GameObject BBullets;

    void Start()
    {
        sa = GetComponent<SpriteAnimation>();
        sa.SetSprite(normalSprite, 0.2f);
        HP = 5040;
        Score = 300;
    }
    void bossAttack()
    {
        if (bossFireDelayTimer > bossFireBulletDelayTime)
        {
            bossFireDelayTimer = 0;
            BBullets.transform.Translate(Vector2.down * Time.deltaTime * Speed);
        }
    }
}
