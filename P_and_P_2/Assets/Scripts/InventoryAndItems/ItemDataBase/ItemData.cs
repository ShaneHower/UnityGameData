using System.Collections.Generic;
using System;
using UnityEngine;
using LitJson;
using System.IO;
using System.Linq;

public class ItemData : MonoBehaviour {
    // TODO handle the list of Ids here (recieved from ItemCache).

    // Game Objects and Components
    public GameObject inventory;

    // Scripts 
    public Inventory inv;
    public ItemCache cache;

    // Json Types
    public JsonData item;

    // Basic Data Types
    public Dictionary<string, string> packagedData;
    public List<int> itemCache;
    public string jsonString;
    public string type;
    public string itemName;
    public string masterDescr;
    public int id;
    public bool objAdded;

    int count;

    private void Start()
    {
        inv = inventory.GetComponent<Inventory>();
        cache = this.GetComponent<ItemCache>();
        count = 0;

    }

    // Update is called once per frame
    void Update () {
        foreach (int i in itemCache)
        {
            Debug.Log(String.Format("Item Cache:{0}", i));
        }
        // TODO Send all other data and display it in inventory
        if (inventory.activeInHierarchy)
        {
            foreach (int x in itemCache)
            {
                GetData(x);
                inv.PopulateInv(true, itemName);
            }

            // clear list in this script then clear list over in other script
            itemCache.Clear();
            cache.items.Clear();
        }
    }

    private void GetData(int x)
    {

        item = AccessJson("MasterItemSheet");
        foreach (int index in Enumerable.Range(0, item.Count))
        {
            count += 1;
            if ((int)item[index]["ID"] == x)
            {


                ItemMasterList itemMaster = new ItemMasterList(
                    (int)item[index]["ID"], (string)item[index]["Name"], (string)item[index]["Description"],
                    (string)item[index]["Flavor Text"], (string)item[index]["Name Hidden"],
                    (string)item[index]["Type"]);
                //Debug.Log((string)item[index]["Name"]);
                itemName = (string)item[index]["Name"];
                // prep to send to item cache
                //packagedData["ID"] = Convert.ToString(itemMaster.Id);
                //packagedData["Name"] = itemMaster.ItemName;
                //packagedData["Description"] = itemMaster.Descr;
                //packagedData["Flavor Text"] = itemMaster.FlvText;
                //packagedData["Name Hidden"] = itemMaster.NameHidden;

                // TODO should really use the TextBoxManager here instead of 
                // being redundent which means I have to generalize the TBM.
                if (itemMaster.NameHidden == "TRUE")
                {
                    masterDescr = "???" + "\n" + 
                         itemMaster.Descr + "\n" + itemMaster.FlvText + "\n";
                }
                else
                {
                    masterDescr = itemMaster.ItemName + "\n" +
                         itemMaster.Descr + "\n" + itemMaster.FlvText + "\n";
                }
                type = itemMaster.Type;
                break;
            }
        }

        if (type == "Quest")
        {

            foreach (int index in Enumerable.Range(0, item.Count))
            {
                item = AccessJson("QuestItems");
                if ((int)item[index]["ID"] == x)
                {
                    QuestItem questItem = new QuestItem((int)item[index]["ID"], (string)item[index]["Key"]);

                    //packagedData["Key"] = questItem.Key;
                    break;

                }

            }
        }

    }



    private JsonData AccessJson(string fileName)
    {
        jsonString = File.ReadAllText(Application.dataPath + String.Format("/Resources/Json/{0}.json", fileName));
        JsonData json = JsonMapper.ToObject(jsonString);
        return json;

    }


}
