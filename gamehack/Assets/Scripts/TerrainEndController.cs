using UnityEngine;

public class TerrainEndController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SendMessage("OnFellOff", SendMessageOptions.DontRequireReceiver);
    }
}
