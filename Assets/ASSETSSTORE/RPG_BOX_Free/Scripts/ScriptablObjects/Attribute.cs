using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Attribute : ScriptableObject
{ 
    public string AttributeName;
    [Header("Example +50% STR >> +#VALUE#% STR")]
    public string AttributeDisplay; //Example +50% STR >> +#VALUE#% STR so the code replace #VALUE# with the value.
}

[System.Serializable]
public class ItemAttribute
{
    public Attribute MyAttribute;
    public int Value;

    public ItemAttribute(Attribute myAttribute, int value)
    {
        MyAttribute = myAttribute;
        Value = value;
    }
}






