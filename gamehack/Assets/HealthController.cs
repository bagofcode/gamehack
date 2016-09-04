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

    void TakeDamage(float damage)
    {
        health -= damage;
        DisplayHealth();
    }

    void DisplayHealth()
    {
        healthDisplay.text = "HP: 10";
    }
}
