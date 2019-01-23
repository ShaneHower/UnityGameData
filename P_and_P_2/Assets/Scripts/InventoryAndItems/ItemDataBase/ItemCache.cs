using System.Collections.Generic;
using UnityEngine;

public class ItemCache : MonoBehaviour {
    // TODO send ONLY the ID here. communication should be between usable item 
    // and item data

    //Game Objects and Components
    public GameObject inventory;

    // Scripts
    ItemData itemData;

    // Basic Data Types
    public List<int> items;
    public int itemId;
    public bool itemAdded;

    private void Start()
    {
        itemData = this.GetComponent<ItemData>();
    }

    // Update is called once per frame
    void Update () {
        if ((itemId != 0) && itemAdded)
        {
            items.Add(itemId);
            itemData.itemCache = items;
            itemAdded = false;

        }


	}
}
