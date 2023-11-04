using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin :item
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteAnimation>().SetSprite(sprites, 0.1f);
        DownSpeed = 1;
    }
}
