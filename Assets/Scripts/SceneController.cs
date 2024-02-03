using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Debug.Log("Quit the app");
        Application.Quit();
    }

    public void LoadLobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
