using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void OnGoGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnAddUI()
    {
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }public void OnGoLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
