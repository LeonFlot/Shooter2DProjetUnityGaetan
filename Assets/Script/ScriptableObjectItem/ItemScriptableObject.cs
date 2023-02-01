using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData")]
public class ItemScriptableObject : ScriptableObject
{
    public Sprite spriteItem;
    public int indexItem;
    public int nbrMoney;
    public bool permanantItem;

}
