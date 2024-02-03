using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverSizeChanger : MonoBehaviour {

    //This script changes the tooltip sizes and sprites

    //main variables
    public float TooltipXSize=1;
    public float TooltipYSize=1;
    public float BGXSize = 1;
    public float BGYSize = 1;
    public float FontSize=1;
    public float IconSize=1;
    public float AttributeTextPos = 0;
    public float TypeRarityPos = 0;
    public float IconPos = 0;
    public float BoarderThickness = 5;

    public int TopBottomMargin;
    public int RightLeftMargin;

    public Sprite BackgroundSprite;
    public Sprite BoarderSprite;

    Vector2 FatherPos;

    RectTransform BGRect;
    List<CustomRectTransformPos> Boarders = new List<CustomRectTransformPos>();

    RectTransform AttributeTextRect;
    CustomTextFloatPos AttributeText;
    CustomTextFloatPos NameText;
    CustomTextFloatPos TypeText;
    CustomTextFloatPos RarityText;
    CustomTextFloatPos MainStatText1;
    CustomTextFloatPos LevelReqText;
    CustomTextFloatPos SellPriceText;

    CustomRectFloatPos IconImage;

    //there are many fixed values here, dont change any unless you know what you are doing. 
    //If you want to revert back, just redownload this script from the assetstore

    Vector2 BgOriginalSize = new Vector2(250, 230.5f);
    Vector2 BoarderOriginalSize = new Vector2(230, 5);
    Vector2 ModTextSize = new Vector2(223, 300);

    Transform LowerPart;
    Vector2 LowerPartPos;
    Vector2 BgPos=new Vector2(2007,110);
    Vector2 ItemHovererPos = new Vector2(2007, -40);
    Vector2 ItemsTooltipPos = new Vector2(2132, 110);

    void ObjectLoader()//loads all neccessay objects
    {
        if (BGRect == null)
        {
            BGRect = transform.Find("Background").GetComponent<RectTransform>();
        }
        if (Boarders.Count == 0)
        {

            Boarders.Add(new CustomRectTransformPos(transform.Find("Boarder0").GetComponent<RectTransform>(), new Vector2(2007,67)));
            Boarders.Add(new CustomRectTransformPos(transform.Find("Boarder1").GetComponent<RectTransform>(), new Vector2(2007, -9)));
            Boarders.Add(new CustomRectTransformPos(transform.Find("Boarder2").GetComponent<RectTransform>(), new Vector2(2007, -51)));
            Boarders.Add(new CustomRectTransformPos(transform.Find("LowerPart").Find("Boarder3").GetComponent<RectTransform>(), new Vector2(2007, -91)));
        }

        FatherPos = transform.parent.position;
        if (BackgroundSprite != null)
        {
            BGRect.GetComponent<Image>().sprite = BackgroundSprite;
        }
        else
        {
            BGRect.GetComponent<Image>().sprite = null;
        }
        if (BoarderSprite != null)
        {
            for(int i=0;i<Boarders.Count;i++)
            {
                Boarders[i].RT.GetComponent<Image>().sprite = BoarderSprite;
            }
        }
        else
        {
            for (int i = 0; i < Boarders.Count; i++)
            {
                Boarders[i].RT.GetComponent<Image>().sprite = null;
            }
        }
        if (LowerPart == null)
        {
            LowerPart = transform.Find("LowerPart");
            LowerPartPos = new Vector2(2007,-91);
        }

        if (AttributeTextRect == null)
        {
            AttributeTextRect = transform.Find("ModStartPoint").Find("Mods").GetComponent<RectTransform>();
        }

        if (AttributeText == null)
        {
            AttributeText = new CustomTextFloatPos(transform.Find("ModStartPoint").Find("Mods").GetComponent<Text>(), 16, new Vector2(2007, -65));
        }
        if (NameText == null)
        {
            NameText = new CustomTextFloatPos(transform.Find("Name").GetComponent<Text>(), 18, new Vector2(2007, 87.65f));

        }
        if (TypeText == null)
        {
            TypeText = new CustomTextFloatPos(transform.Find("Type").GetComponent<Text>(), 16, new Vector2(2067, 44.6f));
        }

        if (RarityText == null)
        {
            RarityText = new CustomTextFloatPos(transform.Find("Rarity").GetComponent<Text>(), 16, new Vector2(2067, 13.45f));
        }

        if (MainStatText1 == null)
        {
            MainStatText1 = new CustomTextFloatPos(transform.Find("GearSpecific").Find("MainStatText1").GetComponent<Text>(), 16, new Vector2(2007f, -30.15f));

        }

        if (LevelReqText == null)
        {
            LevelReqText = new CustomTextFloatPos(transform.Find("LowerPart").Find("ReqLevel").GetComponent<Text>(), 12, new Vector2(2046.1f, -107.65f));

        }

        if (SellPriceText == null)
        {
            SellPriceText = new CustomTextFloatPos(transform.Find("LowerPart").Find("SellPrice").GetComponent<Text>(), 12, new Vector2(1968f, -107.65f));
        }

        if (IconImage == null)
        {
            IconImage = new CustomRectFloatPos(transform.Find("Icon").GetComponent<RectTransform>(), 45, new Vector2(1947f, 29.55f));
        }
    }

    public void ApplyChangesToSizes()
    {

        ObjectLoader();
        //changes Background size first
        BGRect.sizeDelta = new Vector2((BgOriginalSize.x * TooltipXSize) , (BgOriginalSize.y * TooltipYSize));
        BGRect.transform.position = BgPos;
        BGRect.transform.parent.position = ItemHovererPos;
        BGRect.transform.parent.parent.position = ItemsTooltipPos;

        AttributeTextRect.sizeDelta = new Vector2((BGRect.sizeDelta.x - BgOriginalSize.x)+ModTextSize.x, ModTextSize.y);

        //changes boarders sizes and posistions
        for (int i = 0; i < Boarders.Count; i++)
        {
            Boarders[i].RT.sizeDelta = new Vector2((BGRect.sizeDelta.x - BgOriginalSize.x) + BoarderOriginalSize.x, BoarderThickness);
            if (i != 3)
            {
                Boarders[i].RT.transform.position = Boarders[i].Position;
                Boarders[i].RT.transform.position = new Vector2(Boarders[i].Position.x + (RightLeftMargin), FatherPos.y + (TooltipYSize * (Boarders[i].Position.y - FatherPos.y)) + (TopBottomMargin));
            }
        }
        //LowerPart is Sell Text and Level Text 
        LowerPart.position = LowerPartPos;
        LowerPart.position = new Vector2(LowerPartPos.x + (RightLeftMargin), FatherPos.y + (TooltipYSize * (LowerPartPos.y - FatherPos.y))+(TopBottomMargin));

        //these codes are repeated, they are simply: 1-Assign to default position. 2-Change Position. 3-Change Font Size
        SellPriceText.TheText.transform.position = SellPriceText.Position;
        SellPriceText.TheText.transform.position = new Vector2(SellPriceText.Position.x + ((BGRect.sizeDelta.x - BgOriginalSize.x) / 2), LowerPart.position.y + (TooltipYSize * (SellPriceText.Position.y - LowerPartPos.y)));
        SellPriceText.TheText.fontSize = (int)(SellPriceText.SizeOfFont * FontSize);

        LevelReqText.TheText.transform.position = LevelReqText.Position;
        LevelReqText.TheText.transform.position = new Vector2(LevelReqText.Position.x - ((BGRect.sizeDelta.x - BgOriginalSize.x) / 2) , LowerPart.position.y + (TooltipYSize * (LevelReqText.Position.y - LowerPartPos.y)));
        LevelReqText.TheText.fontSize = (int)(LevelReqText.SizeOfFont * FontSize);

        MainStatText1.TheText.transform.position = MainStatText1.Position;
        MainStatText1.TheText.transform.position = new Vector2(MainStatText1.Position.x + (RightLeftMargin), FatherPos.y + (TooltipYSize * (MainStatText1.Position.y - FatherPos.y)) + (TopBottomMargin));
        MainStatText1.TheText.fontSize = (int)(MainStatText1.SizeOfFont * FontSize);

        RarityText.TheText.transform.position = RarityText.Position;
        RarityText.TheText.transform.position = new Vector2(RarityText.Position.x + TypeRarityPos, FatherPos.y + (TooltipYSize * (RarityText.Position.y - FatherPos.y)) + (TopBottomMargin));
        RarityText.TheText.fontSize = (int)(RarityText.SizeOfFont * FontSize);

        TypeText.TheText.transform.position = TypeText.Position;
        TypeText.TheText.transform.position = new Vector2(TypeText.Position.x + TypeRarityPos, FatherPos.y + (TooltipYSize * (TypeText.Position.y - FatherPos.y)) + (TopBottomMargin));
        TypeText.TheText.fontSize = (int)(TypeText.SizeOfFont * FontSize);

        NameText.TheText.transform.position = NameText.Position;
        NameText.TheText.transform.position = new Vector2(NameText.Position.x + (RightLeftMargin), FatherPos.y + (TooltipYSize * (NameText.Position.y - FatherPos.y)) + (TopBottomMargin));
        NameText.TheText.fontSize = (int)(NameText.SizeOfFont * FontSize);

        AttributeText.TheText.transform.position = AttributeText.Position;
        AttributeText.TheText.transform.position = new Vector2(AttributeText.Position.x + (RightLeftMargin), AttributeText.Position.y+AttributeTextPos);
        AttributeText.TheText.fontSize = (int)(AttributeText.SizeOfFont * FontSize);

        IconImage.TheRect.transform.position = IconImage.Position;
        IconImage.TheRect.transform.position = new Vector2(IconImage.Position.x + IconPos, FatherPos.y + (TooltipYSize * (IconImage.Position.y - FatherPos.y)) + (TopBottomMargin));
        IconImage.TheRect.sizeDelta = new Vector2(IconImage.SizeOfRect * IconSize, IconImage.SizeOfRect * IconSize);

        BGRect.sizeDelta = new Vector2((BGRect.sizeDelta.x) + BGXSize, (BGRect.sizeDelta.y) + BGYSize);

    }
}

//Some Custom classes
public class CustomTextFloatPos
{
    public Text TheText;
    public float SizeOfFont;
    public Vector2 Position;

    public CustomTextFloatPos(Text theText, float fontSize,Vector2 pos)
    {
        TheText = theText;
        SizeOfFont = fontSize;
        Position = pos;
    }
}

public class CustomRectFloatPos
{
    public RectTransform TheRect;
    public float SizeOfRect;
    public Vector2 Position;

    public CustomRectFloatPos(RectTransform theRect, float rectSize, Vector2 pos)
    {
        TheRect = theRect;
        SizeOfRect = rectSize;
        Position = pos;
    }
}


public class CustomRectTransformPos
{
    public RectTransform RT;
    public Vector2 Position;

    public CustomRectTransformPos(RectTransform rt, Vector2 pos)
    {
        RT = rt;
        Position = pos;
    }
}
