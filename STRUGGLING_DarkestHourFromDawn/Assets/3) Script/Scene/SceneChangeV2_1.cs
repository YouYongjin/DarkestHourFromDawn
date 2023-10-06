using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeV2_1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("PrototypeV2_2");
        }
    }
}
