using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class LootTable : ScriptableObject
{
    public string LootTableName;
    public  List<ItemAndDropChance> Items_DropChance;

    //returns a list of all items in this loot table
    public List<ItemM> GetAllItems()
    {
        List<ItemM> ListToReturn = new List<ItemM>();
        for (int i = 0; i < Items_DropChance.Count; i++)
        {
            ListToReturn.Add(Items_DropChance[i].TheItem);
        }
        return ListToReturn;
    }

    //picks number of items from this loot table and takes into accout its chance
    public List<ItemM> GenerateItemsFromLootTable(int HowManyItems)
    {
        List<ItemM> ListToReturn = new List<ItemM>();

        if (Items_DropChance.Count > 0)
        {
            int TotalWeight = 0;

            for (int i = 0; i < Items_DropChance.Count; i++)
            {
                TotalWeight += Items_DropChance[i].DropChance;
            }
            for (int j = 0; j < HowManyItems; j++)
            {
                int TheRandom = Random.Range(1, TotalWeight + 1);
                int CurrentWeight = TotalWeight;

                for (int i = 0; i < Items_DropChance.Count; i++)
                {
                    CurrentWeight -= Items_DropChance[i].DropChance;
                    if (TheRandom > CurrentWeight)
                    {
                        ListToReturn.Add(Items_DropChance[i].TheItem);
                        break;
                    }
                }
            }
        }
        return ListToReturn;
    }

}

[System.Serializable]
public class ItemAndDropChance
{
    public ItemM TheItem;
    public int DropChance;

    public ItemAndDropChance(ItemM aItem, int aDropChance)
    {
        TheItem = aItem;
        DropChance = aDropChance;
    }
}