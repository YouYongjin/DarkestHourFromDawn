using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    public List<string> sceneGroup = new List<string>();

    public string sceneName;

    void Start()
    {
        sceneGroup.Add("Test1");
        sceneGroup.Add("Test2");
        sceneGroup.Add("Test3");
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("sceneName");
        }
        else if(col.gameObject.CompareTag("Player"))
        {
            //if()
            //{
                Player player = col.transform.GetComponent<Player>();
                GameManager.instance.CItem(player, 0, sceneName);
            //}

        }
    }
}
