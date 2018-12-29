using UnityEngine;
using System.Collections.Generic;

public class ItemMasterList : MonoBehaviour
{
    // Json fields
    public int Id { get; set; }
    public string ItemName { get; set; }
    public string Descr { get; set; }
    public string FlvText { get; set; }
    public string NameHidden { get; set; }
    public string Type { get; set; }

    public ItemMasterList(int id, string itemName, string descr, string flvText, string nameHidden, string type)
    {
        this.Id = id;
        this.ItemName = itemName;
        this.Descr = descr;
        this.FlvText = flvText;
        this.NameHidden = nameHidden;
        this.Type = type;
    }


}
