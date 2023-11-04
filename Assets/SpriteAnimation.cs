using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
[RequireComponent(typeof(SpriteRenderer))]

public class SpriteAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sr;
    private List<Sprite> sprite;
    private float delay;
    UnityAction action;
    bool loop;
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
                if (loop)
                {
                    animindex = 0;
                }
                else
                {
                    sprite.Clear();
                    if (action != null)
                    {
                        action();
                        action = null;
                    }
                }
                animindex = 0;
            }
        }
        
    }
    /// <summary>
    /// 
    /// </summary>
    public void SetSprite(List<Sprite> sprite,float delay)
    {
        this.sprite = sprite.ToList();
        this.delay = delay;
        action = null;
        loop = true;
        if (sr == null)
        {
            sr = GetComponent<SpriteRenderer>();
        }
        sr.sprite = this.sprite[0];
        animindex = 0;
    }
    public void SetSprite(List<Sprite> sprite,float delay,UnityAction action)
    {
        this.sprite = sprite.ToList();
        this.delay = delay;
        this.action = action;
        loop = false;
        if (sr == null)
        {
            sr = GetComponent<SpriteRenderer>();
        }
        sr.sprite = sprite[0];
        animindex = 0;
    }
}
