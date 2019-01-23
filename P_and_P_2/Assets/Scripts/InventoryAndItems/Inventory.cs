using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    // TODO Incorporate all other data to display in UI. 

    // Game Objects and Components
    public GameObject itemBox;
    public GameObject item;
    public Text itemDataText;

    // Other Data Types
    public List<string> keys;
    public List<string> itemsToAdd;

    int count;

    public void PopulateInv(bool objAdded, string itemName)
    {
        // runs through an item cache, which is all items that have been collected
        // while not active.
        if (objAdded)
        {
            Debug.Log(String.Format("ItemName: {0}", itemName));
            // instantiate the prefab
            var prefabItem = Resources.Load<GameObject>("Prefabs/Inventory_Item/Image");
            item = Instantiate(prefabItem);

            // load sprite to item
            var sprite = Resources.Load<Sprite>(String.Format("Art/Objects/small_items/{0}", itemName));
            item.GetComponent<Image>().sprite = sprite;


            // traverese inventory slots, find the first empty one, make the 
            // child the prefab
            foreach (Transform child in itemBox.transform)
            {

                count += 1;
                // is moving to next cell but deletes previous item in the process
                if (child.transform.childCount == 0)
                {
                    //Debug.Log(String.Format("In if statement: {0}", child.name));
                    item.transform.parent = child;
                    // clone does not spawn in the right coordinates.  
                    // COORDINATES RELATIVE TO PARENT
                    item.transform.localPosition = new Vector2(0, 0);
                    item.name = itemName;
                    objAdded = false;
                    UpdateSearchableList(item);
                    break;
                }
            }

        }

    }

    // will be used to check if the character has a key to something.
    // I'm thinking this is more efficient than travesing the entire Heirarchy.
    private void UpdateSearchableList(GameObject addedItem)
    {
        if (!keys.Contains(addedItem.name))
        {
            keys.Add(addedItem.name);
        }
    }
}
