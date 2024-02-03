using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverManager : MonoBehaviour 
{
    //script which is responsible for Tooltip and controling it.


    int TextFont;
    float FontOverHeighetRatio = 1.12f;
    float AttributeTextYOffset = -19;

    RarityManager AccRM;

    Vector2 BGSizeForGear;
    Vector2 BGSizeForMisc;
    Vector2 ItemIconSize;


    Vector2 BGSize;
    Vector2 LowerPos;
    Vector2 FirstBoarderPosition;
    Vector2 SecondBoarderPosition;

    Image ItemIconImg;

    Text AttributeText;
    Text NameText;
    Text TypeText;
    Text RarityText;
    Text MainStatText1;
    Text LevelReqText;
    Text SellPriceText;

    GameObject Boarder2;
    GameObject Boarder1;

    [Header("Don't Change")]
    public Transform Father;
    public Transform GrandFatherCanvas;

    public RectTransform ChangableText;
    public RectTransform Background;
    public RectTransform LowerPart;

    float TextLineSpacing;
    public float DistanceBetweenTooltipAndItem = 15;

    Vector2 AttPos;
    Vector2 InfPos = new Vector2(5000, 5000);
    HoverSizeChanger accHSC;

    void Start () 
	{
        //geting texts and transforms and assigning them to variables


        if (GameObject.Find("_RarityManager") != null)
        {
            AccRM = GameObject.Find("_RarityManager").GetComponent<RarityManager>();
        }
        accHSC = GetComponent<HoverSizeChanger>();
        AttributeTextYOffset = -19 * accHSC.TooltipYSize;

        BGSizeForGear = new Vector2(Background.sizeDelta.x, 193* accHSC.TooltipYSize+accHSC.BGYSize);
        BGSizeForMisc = new Vector2(Background.sizeDelta.x, 150* accHSC.TooltipYSize + accHSC.BGYSize);

        AttributeText = ChangableText.GetComponent<Text>();
        NameText = transform.Find("Name").GetComponent<Text>();
        TypeText = transform.Find("Type").GetComponent<Text>();
        RarityText = transform.Find("Rarity").GetComponent<Text>();

        ItemIconImg = transform.Find("Icon").GetComponent<Image>();

        LevelReqText = transform.Find("LowerPart").Find("ReqLevel").GetComponent<Text>();
        SellPriceText = transform.Find("LowerPart").Find("SellPrice").GetComponent<Text>();

        MainStatText1 = transform.Find("GearSpecific").Find("MainStatText1").GetComponent<Text>();

        Boarder2 = transform.Find("Boarder2").gameObject;
        Boarder1 = transform.Find("Boarder1").gameObject;
        FirstBoarderPosition = Boarder1.transform.localPosition;
        SecondBoarderPosition = Boarder2.transform.localPosition;
        AttPos = AttributeText.gameObject.transform.localPosition;
        BGSize = Background.sizeDelta;
        TextFont = AttributeText.fontSize;
        TextLineSpacing = AttributeText.lineSpacing;
        Father.position = InfPos;
    }


    public void ForceAdd() //for AttributeText to look good in the tooltip
    {
        Canvas.ForceUpdateCanvases();

        if (AttributeText.text == "")
        {
            Background.sizeDelta = new Vector2(BGSize.x, BGSize.y);
            LowerPart.localPosition = new Vector2(LowerPos.x, LowerPos.y );
        }
        else
        {
            float AdditionInHeight = FontOverHeighetRatio * AttributeText.cachedTextGenerator.lineCount * TextFont * TextLineSpacing;
            Background.sizeDelta = new Vector2(BGSize.x, BGSize.y + AdditionInHeight - AttributeTextYOffset);
            LowerPart.localPosition = new Vector2(LowerPos.x, LowerPos.y - AdditionInHeight + AttributeTextYOffset);
        }
    }

    public void ItemToShow(ItemProps itemAsGo) //takes item and shows its properties to the player
    {
        ItemM TheItem=itemAsGo.MyItem;
        NameText.text = TheItem.itemName;
        RarityText.text = TheItem.itemRarity.ToString();
        ItemIconSize = itemAsGo.MyImage.GetComponent<RectTransform>().sizeDelta;

        if (AccRM != null)
        {
            RarityText.color = AccRM.ColorOfRarity[(int)TheItem.itemRarity];
        }
        ItemIconImg.sprite = TheItem.itemIcon;
        LevelReqText.text = "Level: " + TheItem.LevelReq.ToString();

        #region ItemType Ifs
        if (TheItem.itemType == ItemType.Gear)
        {
            BGSize = BGSizeForGear;
            Boarder2.SetActive(true);
            LowerPart.localPosition = SecondBoarderPosition;
            AttributeText.transform.localPosition = AttPos;
            TypeText.text = TheItem.gearMainType.ToString();
            MainStatText1.text = "";
            if (TheItem.mainStat.TheStat == MainStat.Attack)
            {
                MainStatText1.text = "Attack: " + TheItem.mainStat.TheValue;
            }
            else if (TheItem.mainStat.TheStat == MainStat.Magic)
            {
                MainStatText1.text = "Magic: " + TheItem.mainStat.TheValue;
            }
            else if (TheItem.mainStat.TheStat == MainStat.Defence)
            {
                MainStatText1.text = "Defence: " + TheItem.mainStat.TheValue;
            }
            AttributeText.text = GetAttributesInGoodTextFormat(TheItem.Attributes);
        }
        else if (TheItem.itemType == ItemType.Misc || TheItem.itemType == ItemType.Consumable)
        {
            BGSize = BGSizeForMisc;

            Boarder2.SetActive(false);
            MainStatText1.text = "";
            AttributeText.transform.position = new Vector2(AttributeText.transform.position.x, MainStatText1.transform.position.y+(TextFont/2));
            AttributeText.text = TheItem.Description;

            TypeText.text = TheItem.itemType.ToString();
            LowerPart.localPosition = FirstBoarderPosition;
        }
        #endregion

        #region ItemHome Ifs
        if (itemAsGo.MyHome == ItemHome.Inventory || itemAsGo.MyHome == ItemHome.Dropped || itemAsGo.MyHome == ItemHome.Equiped)
        {
            SellPriceText.text = "Sell: " + TheItem.SellPrice.ToString();
        }
        else if (itemAsGo.MyHome == ItemHome.PlayerBuyTab)
        {
            SellPriceText.text = "Buy: " + TheItem.BuyPrice.ToString();
        }
        #endregion

        LowerPos = LowerPart.localPosition;
        ForceAdd();
    }

    public void CallHoverer(Vector2 PosOfItem, ItemProps ItemToHover) // when the player hover over an item, it calls this method
    {
        ItemToShow(ItemToHover);//shows the item first
        Vector2 PosAttribute = new Vector2();

        //chooses where to show the tooltip
        if (PosOfItem.x >= GrandFatherCanvas.transform.position.x && PosOfItem.y >= GrandFatherCanvas.transform.position.y)
        {
            PosAttribute = PosForAnchor(1);
        }
        else if (PosOfItem.x >= GrandFatherCanvas.transform.position.x && PosOfItem.y < GrandFatherCanvas.transform.position.y)
        {
            PosAttribute = PosForAnchor(4);
        }
        else if (PosOfItem.x < GrandFatherCanvas.transform.position.x && PosOfItem.y < GrandFatherCanvas.transform.position.y)
        {
            PosAttribute = PosForAnchor(3);
        }
        else if (PosOfItem.x < GrandFatherCanvas.transform.position.x && PosOfItem.y >= GrandFatherCanvas.transform.position.y)
        {
            PosAttribute = PosForAnchor(2);
        }
        Father.position = PosOfItem + PosAttribute;

    }

    public void HideTooltip()
    {
        Father.position = InfPos;
    }

    Vector2 PosForAnchor(int WhichCorner)
    {
        Vector2 Pos = new Vector2();
        float FromOriginToBGCenter = Father.position.x - Background.transform.position.x - (Background.sizeDelta.x / 2);


        if (WhichCorner == 1)//Bot Left
        {
            Pos = new Vector2(-1 * (ItemIconSize.x/2)-DistanceBetweenTooltipAndItem+ FromOriginToBGCenter, -1 * (ItemIconSize.y/2) - DistanceBetweenTooltipAndItem);
        }
        else if (WhichCorner == 2) //Bot Right
        {
            Pos = new Vector2(((ItemIconSize.x / 2) + DistanceBetweenTooltipAndItem)+ (FromOriginToBGCenter+Background.sizeDelta.x), -1 * (ItemIconSize.y / 2) - DistanceBetweenTooltipAndItem);
        }
        else if (WhichCorner == 3) //Top Right
        {
            Pos = new Vector2(((ItemIconSize.x / 2) + DistanceBetweenTooltipAndItem) +  (FromOriginToBGCenter + Background.sizeDelta.x), ( (ItemIconSize.y / 2) + DistanceBetweenTooltipAndItem)+ Background.sizeDelta.y);
        }
        else if (WhichCorner == 4) //Top Left
        {
            Pos = new Vector2(-1 * (ItemIconSize.x / 2) - DistanceBetweenTooltipAndItem+ FromOriginToBGCenter, ((ItemIconSize.y / 2) + DistanceBetweenTooltipAndItem) + Background.sizeDelta.y);
        }

        return Pos;
    }


    string GetAttributesInGoodTextFormat(List<ItemAttribute> attributes)// to make Attributes look nice in the tooltip
    {
        string Attributes = "";

        for (int i = 0; i < attributes.Count; i++)
        {
            if (i > 0)
            {
                Attributes += "\n";
            }
            Attributes += attributes[i].MyAttribute.AttributeDisplay.Replace("#VALUE#", attributes[i].Value.ToString());
        }

        return Attributes;
    }


}
