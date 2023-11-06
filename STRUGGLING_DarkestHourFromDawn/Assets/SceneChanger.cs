using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (SceneManager.GetActiveScene().name == "Loop1")
        {
            if(collision.collider.gameObject.CompareTag("Player"))
            { 
            //Debug.Log("해당 씬은 Loop1 이며, Loop2 대기중입니다.");
            SceneManager.LoadScene("Loop2");
        
            }
        }
    }
    public void SceneList()
    {
        OnCollisionEnter();
    }

    private void Update()
    {
        SceneList();
    }
}
