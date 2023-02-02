using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject[] itemUI;

    public static Inventaire inventaire;
    // Start is called before the first frame update
    void Start()
    {
        inventaire = new Inventaire();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ActiveMenu();
        }

        for (int i = 0; i < inventaire.ItemUnlocked.Length; i++)
        {
            if (inventaire.ItemUnlocked[i] == true)
            {
                ActiveSprite(i);
            }
        }
    }

    void ActiveMenu() {

        if (menuPause != null)
        {
            menuPause.SetActive(!menuPause.activeSelf);
        }
        else
        {
            Debug.LogWarning("MenuPause is null");
        }
    }

    void ActiveSprite(int i)
    {
        Debug.Log("Outils Num: " + i + " active");
        itemUI[i].SetActive(true);
    }
}
