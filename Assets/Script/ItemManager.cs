using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public ItemScriptableObject item;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = item.spriteItem;
    }

    private void OnColliderEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (item.permanantItem)
            {
                MenuPause.inventaire.ItemUnlocked[item.indexItem] = true;
                Destroy(gameObject);
            }
            else
            {
                if (item.nbrMoney != 0)
                {
                    MenuPause.inventaire.money += item.nbrMoney;
                    Destroy(gameObject);
                }
                else
                {
                    if (MenuPause.inventaire.healPack <= 3)
                    {
                        MenuPause.inventaire.healPack += 1;
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

}
