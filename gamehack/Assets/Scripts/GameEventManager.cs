using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameEventManager : MonoBehaviour
{

    public void OpenMenu()
    {
        SceneManager.LoadScene("menu");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
    }
}
