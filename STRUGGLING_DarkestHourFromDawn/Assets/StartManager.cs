using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    void GameStart()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Lobby");
        }
    }

    void Update()
    {
        GameStart();
    }
}
