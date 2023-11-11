using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        firePos = transform.GetChild(0);
        sa = GetComponent<SpriteAnimation>();
        sa.SetSprite(normalSprite, 0.2f);
        HP = 100;
        Score = 20;
        Speed = Random.Range(0.5f, 0.6f);
    }

    // Update is called once per frame

}
