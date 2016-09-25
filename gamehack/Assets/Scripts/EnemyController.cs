using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    void OnDeath()
    {
        Destroy(this.gameObject);
    }
}
