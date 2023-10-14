using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform[] bottom;
    [SerializeField] private Transform[] middle;
    [SerializeField] private Transform[] top;
    [SerializeField] private float bottomSpeed;
    [SerializeField] private float middleSpeed;
    [SerializeField] private float topSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in bottom)
        {
            item.transform.Translate(Vector2.down * Time.deltaTime * bottomSpeed);
            if (item.transform.position.y < -12)
            {
                item.transform.position = new Vector2(0f, 12f);
            }
        }
        foreach (var item in middle)
        {
            item.transform.Translate(Vector2.down * Time.deltaTime * middleSpeed);
            if (item.transform.position.y < -12)
            {
                item.transform.position = new Vector2(0f, 12f);
            }
        }
        foreach (var item in top)
        {
            item.transform.Translate(Vector2.down * Time.deltaTime * topSpeed);
            if (item.transform.position.y < -12)
            {
                item.transform.position = new Vector2(0f, 12f);
            }
        }
    }
}
