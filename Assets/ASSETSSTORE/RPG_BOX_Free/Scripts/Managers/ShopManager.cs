using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour 
{
    public static Dictionary<int, CustomItemAndGo> PlayerBuyInventory = new Dictionary<int, CustomItemAndGo>();//inventory of items in the shop

    List<CustomBoolIntVector2> PositionsAndOccupation = new List<CustomBoolIntVector2>();//list for every position in the inventroy and is it occupied or not


    //For Test Scene
    public int TestScenePlayerGold;
    Text TestSceneGoldText;
    //For Test Scene


    public Sprite BackgroundSprite;
    public Sprite SlotSprite;

    Transform X1Y1;//first slot in first row
    Transform X2Y1;//second slot in first row
    Transform X1Y2;//first slot in second row

    Transform ItemsParent;
    Transform SlotsParent;

    RectTransform BackgroundRT;

    GameObject ItemGoPrefab;
    GameObject ShopSlotPrefab;

    public static bool IsSellMode;

    Image SellModeImage;

    public int Rows = 3;
    public int Columns = 3;
    public int SlotSize = 100;
    public int SpacingBetweenSlots = 30;
    public int TopBottomMargin;
    public int RightLeftMargin;
    public int TopBottomSpace = 100;
    public int RightLeftSpace = 100;

    int MaxNumberOfItemsALLinventory;

    InventoryManager AccInv;



    void TransformsLoader()//load needed Transforms
    {
        if (ItemsParent == null)
        {
            ItemsParent = transform.Find("ItemsParent");
        }
        if (SlotsParent == null)
        {
            SlotsParent = transform.Find("SlotsParent");
        }
        if (BackgroundRT == null)
        {
            BackgroundRT = transform.Find("ShopBG").GetComponent<RectTransform>();
        }

    }

    private void Start()
    {
        IsSellMode = false;
        TransformsLoader();
        PrefabLoader();
        TestScenePlayerGold += 5000;
        if (GameObject.Find("TestSceneGoldText") != null)
        {
            TestSceneGoldText = GameObject.Find("TestSceneGoldText").GetComponent<Text>();
        }
        if (GameObject.Find("InventoryWindow") != null)
        {
            AccInv = GameObject.Find("InventoryWindow").GetComponent<InventoryManager>();
        }
        if (GameObject.Find("SellModeButton")!=null)
        {
            SellModeImage = GameObject.Find("SellModeButton").GetComponent<Image>();
        }
        MaxNumberOfItemsALLinventory = Columns * Rows;
        StartCoroutine(AssignXYPos());
    }

    IEnumerator AssignXYPos()
    {
        yield return new WaitForEndOfFrame();
        if (Columns == 1 && SlotsParent.childCount > 1)
        {
            X1Y1 = SlotsParent.GetChild(0);
            X1Y2 = SlotsParent.GetChild(1);
            X2Y1 = SlotsParent.GetChild(0);
            ResetPosAndOccList();
        }
        else if (Rows == 1 && SlotsParent.childCount>1)
        {
            X1Y1 = SlotsParent.GetChild(0);
            X1Y2 = SlotsParent.GetChild(0);
            X2Y1 = SlotsParent.GetChild(1);
            ResetPosAndOccList();
        }
        else if(SlotsParent.childCount > Columns + 1)
        {
            X1Y1 = SlotsParent.GetChild(0);
            X1Y2 = SlotsParent.GetChild(Columns + 1);
            X2Y1 = SlotsParent.GetChild(1);
            ResetPosAndOccList();
        }

        //FOR Test Scene ONLY
        if (DatabaseManager.LootTables.Count > 0)
        {
            RerollItemsInShop(DatabaseManager.LootTables[0]);
        }
        //FOR Test Scene ONLY

    }

    public void ChangeSprites() //change sprites of background and slots
    {
        int cCount = SlotsParent.childCount;

        if (SlotSprite != null)
        {
            for (int i = cCount - 1; i >= 0; i--)
            {
                SlotsParent.GetChild(i).GetComponent<Image>().sprite = SlotSprite;
            }
        }
        else
        {
            for (int i = cCount - 1; i >= 0; i--)
            {
                SlotsParent.GetChild(i).GetComponent<Image>().sprite = null;
            }
        }

        if (BackgroundSprite != null)
        {
            BackgroundRT.GetComponent<Image>().sprite = BackgroundSprite;
        }
        else
        {
            BackgroundRT.GetComponent<Image>().sprite = null;
        }
    }

    public void SellModeActivator()//in case the user needed SellMode button, call this function
    {
        IsSellMode = !IsSellMode;
        if (IsSellMode)
        {
            SellModeImage.color = Color.green;
        }
        else
        {
            SellModeImage.color = Color.white;
        }
    }

    void ResetPosAndOccList()
    {
        float CurrentX = X1Y1.position.x;
        float CurrentY = X1Y1.position.y;
        float xDiff = X2Y1.position.x - X1Y1.position.x;
        float yDiff = X1Y2.position.y - X1Y1.position.y;

        for (int i = 0; i < MaxNumberOfItemsALLinventory; i++)
        {
            Vector2 ThePos = new Vector2(CurrentX, CurrentY);

            CurrentX += xDiff;
            if ((i + 1) % Columns == 0)
            {
                CurrentX = X1Y1.position.x;
                CurrentY += yDiff;
            }

            PositionsAndOccupation.Add(new CustomBoolIntVector2(false, 0, ThePos));
        }
    }

    void CreateItemsInTheShop(LootTable TableToGenerateItemsFrom)//create item in the shop from a LootTable
    {
        if (TableToGenerateItemsFrom.Items_DropChance.Count > (Rows * Columns))
        {
            List<ItemM> ItemsList = TableToGenerateItemsFrom.GenerateItemsFromLootTable(Rows * Columns);
            for (int i = 0; i < ItemsList.Count; i++)
            {
                if (ItemsList[i] != null)
                {
                    AddItemToShop(ItemsList[i]);
                }
            }
        }
        else
        {
            for (int i = 0; i < TableToGenerateItemsFrom.Items_DropChance.Count; i++)
            {
                if (TableToGenerateItemsFrom.Items_DropChance[i].TheItem != null)
                {
                    AddItemToShop(TableToGenerateItemsFrom.Items_DropChance[i].TheItem);
                }
            }
        }
    }

    public void RerollItemsInShop(LootTable TableToGenerateItemsFrom)//rerolls the shop (put a loot table to take items from)
    {
        if (TableToGenerateItemsFrom != null)
        {
            RemoveAllItemsFromShop();
            CreateItemsInTheShop(TableToGenerateItemsFrom);
        }
    }

    void RemoveAllItemsFromShop()//removes all items
    {
        List<int> DictShopInvKeys = new List<int>(PlayerBuyInventory.Keys);

        for (int i = 0; i < DictShopInvKeys.Count; i++)
        {
            RemoveItemFromShop(DictShopInvKeys[i]);
        }
    }


    public bool AddItemToShop(ItemM ItemToAdd)//bool to check if an item can be added or no
    {
        int TheIndexOfMe = TakeIndexOfPos();

        if (TheIndexOfMe > PositionsAndOccupation.Count)
        {
            Debug.Log("NO ENOUGH SPACE IN SHOP");
            return false;
        }

        GameObject NewItem = GameObject.Instantiate(ItemGoPrefab, ItemsParent);
        NewItem.transform.position = PositionsAndOccupation[TheIndexOfMe].aPos;
        ItemProps AccIP = NewItem.GetComponent<ItemProps>();
        AccIP.TakeInfo(ItemToAdd, TheIndexOfMe, ItemHome.PlayerBuyTab);
        CustomItemAndGo ItemAndGo = new CustomItemAndGo(ItemToAdd, NewItem);

        if (PlayerBuyInventory.ContainsKey(TheIndexOfMe))
        {
            PlayerBuyInventory[TheIndexOfMe] = ItemAndGo;
        }
        else
        {
            PlayerBuyInventory.Add(TheIndexOfMe, ItemAndGo);
        }

        return true;

    }


    public void RemoveItemFromShop(int indexOfItemRemoved)//removes a single item
    {
        PositionsAndOccupation[indexOfItemRemoved].IsOccupied = false;
        

        ItemProps AccIP = PlayerBuyInventory[indexOfItemRemoved].TheGameObject.GetComponent<ItemProps>();
        PlayerBuyInventory.Remove(indexOfItemRemoved);

        AccIP.DestroyItem();

    }

    int TakeIndexOfPos()
    {
        int TheIndex = 99999;

        for (int i = 0; i < PositionsAndOccupation.Count; i++)
        {
            if (PositionsAndOccupation[i].IsOccupied == false)
            {
                TheIndex = i;
                PositionsAndOccupation[i].IsOccupied = true;
                break;
            }
        }

        return TheIndex;
    }




    public bool BuyFromShop(int indexOfItemInShop)
    {
        //CHECK IF PLAYER HAS ENOUGH MONEY
        if (TestScenePlayerGold >= PlayerBuyInventory[indexOfItemInShop].TheItem.BuyPrice)
        {
            if (AccInv != null)
            {
                if (AccInv.AddItemToInventory(PlayerBuyInventory[indexOfItemInShop].TheItem))
                {
                    TestScenePlayerGold -= PlayerBuyInventory[indexOfItemInShop].TheItem.BuyPrice;
                    RemoveItemFromShop(indexOfItemInShop);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Debug.LogError("NO Inventory");
                return false;
            }
        }
        else
        {
            ErrorMessageText.instance.ShowMessage("No Enough Gold!");
            return false;
        }


    }

    void PrefabLoader()//loads needed prefabs
    {
        if (ItemGoPrefab == null)
        {
            ItemGoPrefab = Resources.Load<GameObject>("Prefabs/ItemInventoryGO");
        }
        if (ShopSlotPrefab == null)
        {
            ShopSlotPrefab = Resources.Load<GameObject>("Prefabs/ShopSlot");
        }
    }

    public void ChangeSizes()//changes sizes of background and slots
    {
        TransformsLoader();
        PrefabLoader();

        float BgWidth = (RightLeftSpace * 2) + (Columns * SlotSize) + ((Columns - 1) * SpacingBetweenSlots);
        float BgHeight = (TopBottomSpace * 2) + (Rows * SlotSize) + ((Rows - 1) * SpacingBetweenSlots);
        BackgroundRT.sizeDelta = new Vector2(BgWidth, BgHeight);

        float SlotsParentWidth = (Columns * SlotSize) + ((Columns - 1) * SpacingBetweenSlots);
        float SlotsParentHeight = (Rows * SlotSize) + ((Rows - 1) * SpacingBetweenSlots);

        SlotsParent.transform.localPosition = new Vector2(0, 0);
        SlotsParent.transform.localPosition = new Vector2(RightLeftMargin,TopBottomMargin);
        SlotsParent.GetComponent<GridLayoutGroup>().spacing = new Vector2(SpacingBetweenSlots, SpacingBetweenSlots);
        SlotsParent.GetComponent<GridLayoutGroup>().cellSize = new Vector2(SlotSize, SlotSize);
        SlotsParent.GetComponent<RectTransform>().sizeDelta = new Vector2(SlotsParentWidth, SlotsParentHeight);
    }

    public void CreateSlots()
    {
        int cCount = SlotsParent.childCount;

        for (int i = cCount - 1; i >= 0; i--)
        {
            DestroyImmediate(SlotsParent.GetChild(i).gameObject);
        }


        for (int i = 0; i < Columns * Rows; i++)
        {
            Instantiate(ShopSlotPrefab, SlotsParent);
        }
    }

    private void Update()
    {
        if (TestSceneGoldText != null)
        {
            TestSceneGoldText.text = "Gold: " + TestScenePlayerGold;
        }
    }
}
