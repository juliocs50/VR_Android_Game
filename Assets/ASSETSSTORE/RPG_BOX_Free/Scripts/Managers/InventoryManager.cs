using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour 
{
    public static Dictionary<int, CustomItemAndGo> Inventory = new Dictionary<int, CustomItemAndGo>();//Dictionary of slots and items (main inventory)
    List<CustomBoolIntVector2> PositionsAndOccupation = new List<CustomBoolIntVector2>();//list for every position in the inventroy and is it occupied or not
    List<CustomItemIntInt> ListOfStackables = new List<CustomItemIntInt>();//list for stackable items

    int MaxNumberOfStacks = 99;

    public Sprite BackgroundSprite;
    public Sprite SlotSprite;

    Transform X1Y1;//first slot in first row
    Transform X2Y1;//second slot in first row
    Transform X1Y2;//first slot in second row

    Transform ItemsParent;
    Transform SlotsParent;

    RectTransform BackgroundRT;

    GameObject ItemGoPrefab;
    GameObject InventorySlotPrefab;

    public int Rows =3;
    public int Columns =3;
    public int SlotSize=100;
    public int SpacingBetweenSlots=30;
    public int TopBottomMargin;
    public int RightLeftMargin;
    public int TopBottomSpace=100;
    public int RightLeftSpace=100;

    int MaxNumberOfItemsALLinventory;


    void TransformsLoader()    //loads all the needed transforms
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
            BackgroundRT = transform.Find("InventoryBG").GetComponent<RectTransform>();
        }

    }

    private void Start()
    {
        TransformsLoader();
        PrefabLoader();
        MaxNumberOfItemsALLinventory = Columns*Rows;
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
        else if (Rows == 1 && SlotsParent.childCount > 1)
        {
            X1Y1 = SlotsParent.GetChild(0);
            X1Y2 = SlotsParent.GetChild(0);
            X2Y1 = SlotsParent.GetChild(1);
            ResetPosAndOccList();
        }
        else if (SlotsParent.childCount > Columns + 1)
        {
            X1Y1 = SlotsParent.GetChild(0);
            X1Y2 = SlotsParent.GetChild(Columns + 1);
            X2Y1 = SlotsParent.GetChild(1);
            ResetPosAndOccList();
        }
    }

    public void ChangeSprites()//change sprites of Background and Slot
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

            PositionsAndOccupation.Add(new CustomBoolIntVector2(false, 0, ThePos));//0 is if the user needed more than one tab for the inventory
        }
    }

    public bool AddItemToInventory(ItemM ItemToAdd)//bool to check can this item be added to the inventory or no
    {
        if (ItemToAdd.IsStackable)
        {
            for (int i = 0; i < ListOfStackables.Count; i++)
            {
                if (ListOfStackables[i].TheItem.itemName == ItemToAdd.itemName && ListOfStackables[i].ItemStacks < MaxNumberOfStacks)
                {
                    ListOfStackables[i].ItemStacks++;
                    Inventory[ListOfStackables[i].ItemNumberInInventory].TheGameObject.GetComponent<ItemProps>().ChangeStacks(ListOfStackables[i].ItemStacks);
                    return true;
                }
            }
        }
        int TheIndexOfMe = TakeIndexOfPos();
        if (TheIndexOfMe > PositionsAndOccupation.Count)//in case the index is more than the slots numbers
        {
            ErrorMessageText.instance.ShowMessage("No Enough space in inventory");
            return false;
        }
        GameObject NewItem = GameObject.Instantiate(ItemGoPrefab, ItemsParent);
        NewItem.transform.position = PositionsAndOccupation[TheIndexOfMe].aPos;
        ItemProps AccIP = NewItem.GetComponent<ItemProps>();
        AccIP.TakeInfo(ItemToAdd, TheIndexOfMe, ItemHome.Inventory);

        CustomItemAndGo ItemAndGo = new CustomItemAndGo(ItemToAdd, NewItem);
        if (Inventory.ContainsKey(TheIndexOfMe))
        {
            Inventory[TheIndexOfMe] = ItemAndGo;
        }
        else
        {
            Inventory.Add(TheIndexOfMe, ItemAndGo);
        }
        if (ItemToAdd.IsStackable)
        {
            ListOfStackables.Add(new CustomItemIntInt(ItemToAdd, 1, TheIndexOfMe));
        }
        return true;

    }

    public bool ReduceStackableSize(int indexOfStackable) //true means destroy the item, false means just reduce stack number
    {
        ItemM aItem = Inventory[indexOfStackable].TheItem;

        for (int i = 0; i < ListOfStackables.Count; i++)
        {
            if (ListOfStackables[i].TheItem.itemName == aItem.itemName && ListOfStackables[i].ItemStacks > 1)
            {
                ListOfStackables[i].ItemStacks--;
                Inventory[ListOfStackables[i].ItemNumberInInventory].TheGameObject.GetComponent<ItemProps>().ChangeStacks(ListOfStackables[i].ItemStacks);
                return false;
            }
            else if (ListOfStackables[i].TheItem.itemName == aItem.itemName && ListOfStackables[i].ItemStacks <= 1)
            {
                ListOfStackables.RemoveAt(i);
                return true;
            }
        }
        return true;
    }

    public void RemoveItemFromInventory(int indexOfItemRemoved) // removes the item completly from the inventory
    {
        PositionsAndOccupation[indexOfItemRemoved].IsOccupied = false;
        ItemProps AccIP = Inventory[indexOfItemRemoved].TheGameObject.GetComponent<ItemProps>();
        AccIP.DestroyItem();
        Inventory.Remove(indexOfItemRemoved);
    }

    int TakeIndexOfPos()
    {
        int TheIndex=99999;//basically infinty

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

    void PrefabLoader()//loads all needed prefabs
    {
        if (ItemGoPrefab == null)
        {
            ItemGoPrefab = Resources.Load<GameObject>("Prefabs/ItemInventoryGO");
        }
        if (InventorySlotPrefab == null)
        {
            InventorySlotPrefab = Resources.Load<GameObject>("Prefabs/InventorySlot");
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
        SlotsParent.transform.localPosition = new Vector2(RightLeftMargin, TopBottomMargin);
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
            Instantiate(InventorySlotPrefab, SlotsParent);
        }
    }
}

public class CustomBoolIntVector2
{
    public bool IsOccupied;
    public Vector2 aPos;
    public int TabNumber;

    public CustomBoolIntVector2(bool occ,int tab, Vector2 pos)
    {
        IsOccupied = occ;
        TabNumber = tab;
        aPos = pos;
    }
}

public class CustomItemAndGo
{
    public ItemM TheItem;
    public GameObject TheGameObject;

    public CustomItemAndGo(ItemM item, GameObject go)
    {
        TheItem = item;
        TheGameObject = go;
    }
}
public class CustomItemIntInt
{
    public ItemM TheItem;
    public int ItemStacks;
    public int ItemNumberInInventory;

    public CustomItemIntInt(ItemM item, int itemStacks,int itemNumber)
    {
        TheItem = item;
        ItemStacks = itemStacks;
        ItemNumberInInventory = itemNumber;
    }
}
