using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform firePos;
    Player p;
    [SerializeField] private List<Sprite> normalSprite;
    [SerializeField] private List<Sprite> hitSprite;
    [SerializeField] private List<Sprite> deadSprite;
    [SerializeField] private EBullet bullet;
    [SerializeField] private item[] items;
    public float Speed { get; set; }
    public int HP { get; set; }
    public int Score { get; set; }
    SpriteAnimation sa;
    float fireDelayTimer;
    const float fireDelayTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        firePos = transform.GetChild(0);
        sa = GetComponent<SpriteAnimation>();
        sa.SetSprite(normalSprite, 0.2f);
        HP = 100;
        Score = 20;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
            Hit((int)collision.GetComponent<PBullet>().Power);
            if (HP <= 0)
            {
                Dead();
            }
        }
    }
    void Hit(int damage)
    {
        HP -= damage;
        GetComponent<SpriteAnimation>().SetSprite(hitSprite, 0.2f, () => GetComponent<SpriteAnimation>().SetSprite(normalSprite, 0.2f));
    }
    void Dead()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        p = null;
        UI.instance.Score += Score;
        GetComponent<SpriteAnimation>().SetSprite(deadSprite, 0.1f, () =>
        {
            int rand = Random.Range(0, 100);
            int spawnItemIndex = rand > 75 ? rand > 85 ? rand > 95 ? 2 : 1 : 0 : -1;
            if (spawnItemIndex != -1)
            {
                Instantiate(items[spawnItemIndex], transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        });

    }
}
