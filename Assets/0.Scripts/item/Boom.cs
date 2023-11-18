using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : item
{
    [SerializeField] private List<Sprite> boomSprite;
    [SerializeField] private GameObject boomObj;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteAnimation>().SetSprite(sprites, 0.1f);
        DownSpeed = 1f;
    }
    public void Play()
    {
        GameObject obj = Instantiate(boomObj);
        FindObjectOfType<EnemyController>().EnemyAllDelete();
        obj.GetComponent<SpriteAnimation>().SetSprite(boomSprite, 0.25f,
            () =>
            {
                Destroy(obj);
            }
        );
    }
    
}
