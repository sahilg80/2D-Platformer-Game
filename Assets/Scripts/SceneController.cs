using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private int totalScenes;
    private Scene currentScene;
    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 1f;
        totalScenes = 4;
        currentScene = SceneManager.GetActiveScene();
        
        Debug.Log(currentScene.buildIndex + " " + currentScene.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLobbyScene()
    {
        SoundsManager.Instance.PlayClip(Sounds.OnClick, SoundPlayingType.OneShot);
        SceneManager.LoadScene("LobbyScene");
    }

    public void ReLoadScene()
    {
        SoundsManager.Instance.PlayClip(Sounds.OnClick, SoundPlayingType.OneShot);
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    public void LoadNextLevel()
    {
        if (currentScene.buildIndex > 3)
        {
            Debug.Log("Game completed");
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
        else
        {
            string nextLevel = currentScene.buildIndex.ToString();
            LevelName levelName = (LevelName)Enum.Parse(typeof(LevelName), nextLevel);
            LevelManager.Instance.SetLevelStatus(levelName, LevelStatus.Unlocked);
            SceneManager.LoadScene(currentScene.buildIndex+1);
        }
    }
}
