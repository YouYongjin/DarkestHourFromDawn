using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        // �̱��� (���� ����): ��� ���� ������ �� �ִ�.
        instance = this;
    }

    public void SceneChange(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    // static�� �Է��� ���, Instance ��ΰ� �ƴ� �Լ��� ȣ���� �� �ִ�?
    //public static void SceneChange(string Scenename)
    //{
    //    SceneManager.LoadScene(Scenename);
    //}

    public void CItem(Player player, int ItemIndex, string SceneName)
    {
        // SceneName = (SceneName)�� String �迭�� �Է��ϰ� ����.
        if (player.hasCItems[ItemIndex])
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
