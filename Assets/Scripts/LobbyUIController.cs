using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuContainer;
    [SerializeField]
    private GameObject levelSelectionContainer;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuContainer.SetActive(true);
        levelSelectionContainer.SetActive(false);
    }

    // Update is called once per frame
    public void DisableMainMenu()
    {
        SoundsManager.Instance.PlayClip(Sounds.OnClick, SoundPlayingType.OneShot);
        mainMenuContainer.SetActive(false);
        levelSelectionContainer.SetActive(true);
    }

    public void QuitGame()
    {
        SoundsManager.Instance.PlayClip(Sounds.OnClick, SoundPlayingType.OneShot);
        Debug.Log("Quit the app");
        Application.Quit();
    }
}
