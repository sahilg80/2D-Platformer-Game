
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    [SerializeField]
    private SceneController sceneController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (collision != null && playerController != null)
        {
            Debug.Log("Player died level over");
            SoundsManager.Instance.PlayClip(Sounds.LevelFail, SoundPlayingType.OneShot);
            sceneController.ReLoadScene();
        }
    }
}
