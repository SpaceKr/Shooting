using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class item : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected List<Sprite> sprites;
    public float DownSpeed { get; set; }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * DownSpeed);
        if (UI.instance.gameState != GameState.Play)
        {
            return;
        }
    }
}
