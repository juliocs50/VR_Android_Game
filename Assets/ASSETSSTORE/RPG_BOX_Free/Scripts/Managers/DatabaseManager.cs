using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour {

    public static List<ItemM> Items = new List<ItemM>(); 
    public static List<LootTable> LootTables = new List<LootTable>();
    public static List<Attribute> Attributes = new List<Attribute>();


    private void Awake()
    {
        Items = new List<ItemM>(Resources.LoadAll<ItemM>("ItemsBases")); // Load all items
        LootTables=new List<LootTable>(Resources.LoadAll<LootTable>("LootTables"));// Load all LootTables
        Attributes = new List<Attribute>(Resources.LoadAll<Attribute>("Attributes"));// Load all Attributes
    }
}
