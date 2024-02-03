using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessageText : MonoBehaviour
{

    //this script is for error messages which appears in the middle of the screen

    public static ErrorMessageText instance;
    Text MyText;
    float fadingRate=0.007f; //rate at which error messages disappear
    Color MyOrignalColor;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        MyText = GetComponent<Text>();
        MyOrignalColor = MyText.color;
        MyText.text = "";
    }

    public void ShowMessage(string MessageToShow) //function called to show a message
    {
        MyText.color = MyOrignalColor;
        MyText.text = MessageToShow;
        StopAllCoroutines();
        StartCoroutine(HideMessage());
    }

    IEnumerator HideMessage()
    {
        while (MyText.color.a >= 0.1f)
        {
            yield return null;
            Color TextColor = MyText.color;
            TextColor.a -= fadingRate;
            if (TextColor.a <= 0.1f)
            {
                TextColor.a = 0;
            }
            MyText.color = TextColor;
        }
    }
}
