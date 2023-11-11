using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum GameState
{
    Play,
    Pause,
    STOP
}
public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public static UI instance;
    [SerializeField] private Image lifelmg;
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private GameObject gameover;
    public FixedJoystick joy;
    Player p;
    public GameState gameState;
    public int Life { get; set; } = 3;
    private int score;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreTxt.text = $"Score:{score}";
        }
    }
    void Awake()
    {
        instance = this;
        SetLifeImage();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = joy.Horizontal;
        float y = joy.Vertical;
        Vector2 vec = new Vector2(x, y);
        vec.Normalize();
        if (p == null)
        {
            p = FindObjectOfType<Player>();
        }
        p.Move(x, y);
    }
    public void SetLifeImage()
    {
        float width = 66.6f;
        lifelmg.rectTransform.sizeDelta=new Vector2(width* Life,66.6f);
    }
    public void ShowGameOver()
    {
        gameover.SetActive(true);
        gameState = GameState.STOP;
    }
    public void OnRetry()
    {
        SceneChange.instance.OnGoGame();
    }
    public void OnExit()
    {
        SceneChange.instance.OnGoLobby();
    }
}
