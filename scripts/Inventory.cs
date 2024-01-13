using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static string[] Items;
    public static int n;
    public GameObject image,InventoryDisplay;
    public static bool newInsert = false;
    public GameObject slot1, slot2, slot3, slot4, slot5, slot6;
    public static bool clearInventory=false;
    bool inventoryOn = false;
    //3-blackCrystal
    //5=RedCrystal
    //6 GreenCrystal
    public Text desc; 
    // Start is called before the first frame update
    void Start()
    {
        Items = new string[10];
        n = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (clearInventory) { 
            //slot1.SetActive(false);
            //slot2.SetActive(false);
            slot3.SetActive(false);
            slot4.SetActive(false);
            slot5.SetActive(false);
            slot6.SetActive(false);

            clearInventory= false;
        }

        if (Input.GetKeyDown(KeyCode.E)) { 
            inventoryOn= !inventoryOn;  
        }
        if (inventoryOn)
        {
            InventoryDisplay.SetActive(true);

        }
        else {

            InventoryDisplay.SetActive(false);
            desc.text = "";
        }
        if ( newInsert && Input.GetKeyDown(KeyCode.X)) {

            image.SetActive(false);
            VisibleInInventory(Items[n-1]);
            newInsert = false;
            Time.timeScale = 1 ;
        }
    }

    public static void InsertToInventory(string obj) {
        Items[n] = obj;
        //Time.timeScale = 0;
        n++;
        newInsert = true;
        
    }

    void VisibleInInventory(string name) {
        if (name == "Aloshium")
        {
            slot3.SetActive(true);
        }
        else if (name == "Daddyium") {

            slot5.SetActive(true);

        }
        else if (name == "Gundamium")
        {

            slot6.SetActive(true);

        } else if (name == "BlackCrystal1"|| name == "BlackCrystal3"|| name == "BlackCrystal2") { 
            slot4.SetActive(true);
        }
    }

    public void BlackCrystalDesc() {
        if (slot4.activeInHierarchy)
        {
            desc.text = "absorbing all energy around it, basically a black hole, used as cooler for the Spaceship";
        }
    }
    public void AloshiumDesc() {
        if (slot3.activeInHierarchy)
        {
            desc.text = "Aloshium : Rare ore found which makes u taller and grander";
        }
    }

    public void MeDesc()
    {
        if (slot6.activeInHierarchy)
        {
            desc.text = "Gundamium : Element makes you good at valorant finally";
        }
    }

    public void KODesc()
    {
        if (slot5.activeInHierarchy)
        {
            desc.text = "Daddyium : u can guess";
        }
    }

    public void pickAxeDesc()
    {
        if (PlayerPrefs.GetInt("Pickaxe", 0) == 3)
        {
            desc.text = "The DOOMSLAYER";
        }
        else
        {
            desc.text = "PickAxe : your trusty pickaxe to mine any samples or hold your own in a sticky situation. why no guns? budget cuts, yes";
        }
    }
    public void torchDesc() {
        desc.text = "Torch 10000 : There were no budget cuts here, giving the best lighting humanity has to offer, lighting up even nearby planets with a single torch.";
;    }

}
