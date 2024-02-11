using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private LevelName firstLevelName;
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (GetLevelStatus(firstLevelName) != LevelStatus.Unlocked)
        {
            SetLevelStatus(firstLevelName, LevelStatus.Unlocked);
        }
    }

    public LevelStatus GetLevelStatus(LevelName levelName)
    {
        return (LevelStatus)PlayerPrefs.GetInt(levelName.ToString(), 0);
    }

    public void SetLevelStatus(LevelName levelName, LevelStatus levelStatus)
    {
        Debug.Log("setting status levelName "+ levelName.ToString());
        PlayerPrefs.SetInt(levelName.ToString(), (int)levelStatus);
    }

}

public enum LevelStatus
{
    Locked,
    Unlocked,
    Completed
}
