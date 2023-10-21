using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed { get; set; }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * Speed);
    }
}
