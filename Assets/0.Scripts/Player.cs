using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    enum Direction
    {
        Center,
        Left,
        Right
    }

    [SerializeField] private GameObject[] bullets;
    [SerializeField] private List<Sprite> normalSprite;
    [SerializeField] private List<Sprite> leftSprite;
    [SerializeField] private List<Sprite> rightSprite;
    [SerializeField] private float speed;
    [SerializeField] private Transform bulletParent;
    [SerializeField] private float fireBulletDelayTime;
    private Direction dir = Direction.Center;
    private float fireDelayTimer;
    public int BulletLevel { get; set; } = 1;
    void Start()
    {
        SceneChange.instance?.OnAddUI();
        GetComponent<SpriteAnimation>().SetSprite(normalSprite, 0.1f);
        Invoke("GameStart", 2f);
    }
    void GameStart() => UI.instance.gameState = GameState.Play;


    // Update is called once per frame
    void Update()
    {
        if (UI.instance == null || UI.instance.gameState != GameState.Play)
        {
            return;
        }
        Fire();

    }
    public void Move(float aX, float aY)
    {
        float x = aX * Time.deltaTime * speed; ;
        float y = aY * Time.deltaTime * speed;

        float clampX = Mathf.Clamp(transform.position.x + x, -2.3f, 2.3f);
        float clampY = Mathf.Clamp(transform.position.y + y, -4.5f, 4.5f);
        transform.position = new Vector2(clampX, clampY);
        if (x < 0 && dir != Direction.Left)
        {
            dir = Direction.Left;
            GetComponent<SpriteAnimation>().SetSprite(leftSprite, 0.2f);

        }
        else if (x > 0 && dir != Direction.Right)
        {
            dir = Direction.Right;
            GetComponent<SpriteAnimation>().SetSprite(rightSprite, 0.2f);
        }
        else if (x == 0 && dir != Direction.Center)
        {
            dir = Direction.Center;
            GetComponent<SpriteAnimation>().SetSprite(normalSprite, 0.2f);
        }
        //transform.Translate(new Vector3(x, y, 0f) * Time.deltaTime * 3f);
    }
    void Fire()
    {
        fireDelayTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if (fireDelayTimer > fireBulletDelayTime)
            {
                fireDelayTimer = 0;
                GameObject obj = Instantiate(bullets[BulletLevel-1], transform.GetChild(0));
                obj.transform.SetParent(bulletParent);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EBullet>())
        {
            Destroy(collision.gameObject);
            //Destroy(gameObject);
            UI.instance.Life--;
            UI.instance.SetLifeImage();
            if (UI.instance.Life <= 0)
            {
                UI.instance.ShowGameOver();
            }
        }
        if (collision.GetComponent<Coin>())
        {
            Destroy(collision.gameObject);
            UI.instance.Score += 10;
        }
        if (collision.GetComponent<Power>())
        {
            BulletLevel++;
            if (BulletLevel > bullets.Length){
                BulletLevel = bullets.Length;
            }
            Destroy(collision.gameObject);
        }
        if (collision.GetComponent<Boom>())
        {
            collision.GetComponent<Boom>().Play();
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Enemy>())
        {
            Destroy(collision.gameObject);
            hit();
        }
    }
    void hit()
    {
        UI.instance.Life--;
        UI.instance.SetLifeImage();
        if (UI.instance.Life <= 0)
        {
            UI.instance.ShowGameOver();
        }
    }
}
