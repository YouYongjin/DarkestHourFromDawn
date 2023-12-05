using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextBlink : MonoBehaviour
{
    Text flashingText;

    void Start()
    {

        flashingText = GetComponent<Text>();

        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    { 
        while (true)
        {

            flashingText.text = "";

            yield return new WaitForSeconds(.7f);

            flashingText.text = "�ƹ�Ű�� �Է��ϼ���.";

            yield return new WaitForSeconds(.7f);
        }
    }
}
