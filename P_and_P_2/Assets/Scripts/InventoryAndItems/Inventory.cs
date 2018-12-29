using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    // Game Objects and Components
    public GameObject itemBox;
    public GameObject item;

    // Other Data Types
    public bool objAdded;
    public string objName;
    public List<string> keys;
	
	// Update is called once per frame
	void Update () {
        PopulateInv();
        foreach(string i in keys)
        {
            Debug.Log(String.Format("Item in Keys: {0}", i));
        }
	}

    private void PopulateInv()
    {
        if (objAdded)
        {
            // instantiate the prefab
            var prefabItem = Resources.Load<GameObject>("Prefabs/Inventory_Item/Image");
            item = Instantiate(prefabItem);

            // load sprite to item
            var sprite = Resources.Load<Sprite>(String.Format("Art/Objects/small_items/{0}", objName));
            item.GetComponent<Image>().sprite = sprite;


            // traverese inventory slots, find the first empty one, make the 
            // child the prefab
            foreach (Transform child in itemBox.transform)
            {
                Debug.Log(String.Format("number of children in {0}: {1}", child.transform.name, child.transform.childCount));
                // is moving to next cell but deletes previous item in the process
                if (child.transform.childCount == 0)
                {
                    Debug.Log(child.name);
                    item.transform.parent = child;
                    // clone does not spawn in the right coordinates.  
                    // COORDINATES RELATIVE TO PARENT
                    item.transform.localPosition = new Vector2(0, 0);
                    item.name = objName;
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
