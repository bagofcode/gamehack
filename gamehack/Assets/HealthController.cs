using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthController : MonoBehaviour
{
    public float health = 10.0f;
    public Text healthDisplay;

    void Awake()
    {
        DisplayHealth();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        DisplayHealth();
        if (health <= 0)
        {
            this.gameObject.SendMessage("OnDeath");
        }
    }

    void DisplayHealth()
    {
        healthDisplay.text = "HP: " + health;
    }
}
