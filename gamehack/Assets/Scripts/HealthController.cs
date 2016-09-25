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
            this.gameObject.SendMessage("OnDeath", SendMessageOptions.RequireReceiver);
        }
    }

    void DisplayHealth()
    {
        if (healthDisplay != null)
        {
            healthDisplay.text = "HP: " + health;
        }
    }
}
