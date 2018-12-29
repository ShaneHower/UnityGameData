using System;
using UnityEngine;
using LitJson;
using System.IO;
using System.Linq;

public class ItemData : MonoBehaviour {

    // Json Types
    public JsonData item;

    // Basic Data Types
    public string jsonString;
    public string type;
    public string itemName;
    public int id;
    public bool objAdded;

	// Update is called once per frame
	void Update () {
        item = AccessJson("MasterItemSheet");
        if (!(id == 0))
        {
            foreach (int index in Enumerable.Range(0, item.Count))
            {
                if ((int)item[index]["ID"] == id)
                {
                    //TODO Generlize this mess. avoid a million loops. error coming up but doesn't break program 
                    ItemMasterList itemMaster = new ItemMasterList(
                        (int)item[index]["ID"], (string)item[index]["Name"], (string)item[index]["Description"],
                        (string)item[index]["Flavor Text"], (string)item[index]["Name Hidden"],
                        (string)item[index]["Type"]);
                    itemName = itemMaster.ItemName;

                    //Debug.Log(itemMaster.Id);
                    //Debug.Log(itemMaster.ItemName);
                    //Debug.Log(itemMaster.Descr);
                    //Debug.Log(itemMaster.FlvText);
                    //Debug.Log(itemMaster.NameHidden);
                    //Debug.Log(itemMaster.Type);
                    type = itemMaster.Type;
                    break;
                }
            }

            if (type == "Quest")
            {
                item = AccessJson("QuestItems");
                foreach (int index in Enumerable.Range(0, item.Count))
                {
                    if ((int)item[index]["ID"] == id)
                    {
                        QuestItem questItem = new QuestItem((int)item[index]["ID"], (string)item[index]["Key"]);
                        Debug.Log(questItem.Key);
                        break;

                    }

                }
            }

            if (objAdded)
            {
                SendData();
            }

            id = 0;
        }
	}

    private void SendData()
    {
        // not sure if I should be explicit here.
        Inventory inv = this.GetComponent<Inventory>();
        inv.objAdded = objAdded;
        inv.objName = itemName;

    }

    private JsonData AccessJson(string fileName)
    {
        jsonString = File.ReadAllText(Application.dataPath + String.Format("/Resources/Json/{0}.json", fileName));
        JsonData json = JsonMapper.ToObject(jsonString);
        return json;

    }
}
