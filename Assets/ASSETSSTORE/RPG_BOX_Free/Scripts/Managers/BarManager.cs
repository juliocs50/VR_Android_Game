using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BarManager : MonoBehaviour {

    Image BarImage;
    Image BarBackground;
    Outline BarOutline;
    Text BarText;

    public Color32 BarColor=Color.red;
    public Color32 BackgroundColor=Color.gray;
    public Color32 OutlineColor=Color.black;
    public float OutlineSize;
    public int TextFontSize;
    public Color32 TextColor=Color.black;
    public Vector2 BarSize = new Vector2(100,100);
    public int PercentageRoundingToNearest;

    public float TestMax;
    public float TestMin;
    public bool TestIsPrecentage;
    public float TestValue;
    public bool IsShowText;

    private void Start()
    {
        GetChildren();
    }

    void GetChildren()
    {
        BarImage = transform.Find("TheBar").GetComponent<Image>();
        BarOutline = transform.Find("BarBG").GetComponent<Outline>();
        BarBackground = transform.Find("BarBG").GetComponent<Image>();
        BarText = transform.Find("BarText").GetComponent<Text>();
    }

    public void ChangeLookOfTheBar()
    {
        GetChildren();

        BarImage.color = BarColor;
        BarImage.GetComponent<RectTransform>().sizeDelta = BarSize;

        BarBackground.color = BackgroundColor;
        BarBackground.GetComponent<RectTransform>().sizeDelta = BarSize;
        BarOutline.effectColor = OutlineColor;
        BarOutline.effectDistance = new Vector2(OutlineSize, OutlineSize);

        BarText.fontSize = TextFontSize;
        BarText.color = TextColor;
    }

    public void ChangeBarSize(float CurrentValue, float MaxValue, bool IsPrecentage)
    {
        if (CurrentValue > MaxValue)
        {
            CurrentValue = MaxValue;
        }
        else if (CurrentValue < 0)
        {
            CurrentValue = 0;
        }
        BarImage.fillAmount = CurrentValue / MaxValue;

        if (IsShowText)
        {
            if (IsPrecentage)
            {
                float value = (CurrentValue / MaxValue) * 100;
                double percentage = Math.Round(value, PercentageRoundingToNearest);
                BarText.text = (percentage).ToString() + "%";
            }
            else
            {
                BarText.text = CurrentValue.ToString("0") + " / " + MaxValue.ToString("0");
            }
        }
        else
        {
            BarText.text = "";
        }

    }

}
