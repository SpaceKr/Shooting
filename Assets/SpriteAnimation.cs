using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]

public class SpriteAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sr;
    private List<Sprite> sprite;
    private float delay;
    int animindex = 0;
    float timer;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sprite.Count == 0)
        {
            return;
        }timer += Time.deltaTime;
        if (timer >= delay)
        {
            timer = 0;
            sr.sprite = sprite[animindex];
            animindex++;
            if (sprite.Count <= animindex)
            {
                animindex = 0;
            }
        }
        
    }
    /// <summary>
    /// 
    /// </summary>
    public void SetSprite(List<Sprite> sprite,float delay)
    {
        this.sprite = sprite;
        this.delay = delay;
        if (sr == null)
        {
            sr = GetComponent<SpriteRenderer>();
        }
        sr.sprite = this.sprite[0];
        animindex = 0;
    }
}
