using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private LevelName levelName;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadLevel);
    }

    public void LoadLevel()
    {
        SoundsManager.Instance.PlayClip(Sounds.OnClick, SoundPlayingType.OneShot);
        if (LevelManager.Instance.GetLevelStatus(levelName) == LevelStatus.Locked)
        {
            Debug.Log("can not play level locked");
            return;
        }
        Debug.Log("level name index " + (int)levelName);
        SceneManager.LoadScene(levelName.ToString());
    }
}

public enum LevelName
{
    Level1,
    Level2,
    Level3,
    Level4,
}
