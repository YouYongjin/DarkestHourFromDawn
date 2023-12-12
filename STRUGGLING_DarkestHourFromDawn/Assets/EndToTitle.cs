using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndToTitle : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Title");
    }
    public void Mouse()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        Mouse();
    }
}
