using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private float initialHealth;
    public float currentHealth { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = initialHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDamage(float val)
    {
        currentHealth -= val;
        healthBar.fillAmount = currentHealth / 10;
    }
}
