using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.gameObject.CompareTag("LevelEnd"))
        {
            Debug.Log("Player completed level");
            SceneManager.LoadScene("MainScene");
        }
        else if (collision != null && collision.gameObject.CompareTag("GameOver"))
        {
            Debug.Log("Level over ");
            SceneManager.LoadScene("MainScene");
        }
    }
}
 