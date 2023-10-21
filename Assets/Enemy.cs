using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform firePos;
    Player p;
    [SerializeField] private List<Sprite> normalSprite;
    [SerializeField] private List<Sprite> hitSprite;
    [SerializeField] private EBullet bullet;
    public float Speed { get; set; }
    SpriteAnimation sa;
    float fireDelayTimer;
    const float fireDelayTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        firePos = transform.GetChild(0);
        sa = GetComponent<SpriteAnimation>();
        sa.SetSprite(normalSprite, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!p)
        {
            return;
        }
        Targeting();
        fireDelayTimer += Time.deltaTime;
        if (fireDelayTimer > fireDelayTime)
        {
            fireDelayTimer = 0;
            EBullet b=Instantiate(bullet,firePos);
            b.Speed = 3f;
            b.transform.SetParent(null);
        }
    }
    void Move()
    {
        transform.Translate(Vector2.down * Time.deltaTime * Speed);
    }
    void Targeting()
    {
        Vector2 vec = transform.position - p.transform.position;
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        firePos.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
    public void SetPlayer(Player player)
    {
        p = player;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PBullet>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
