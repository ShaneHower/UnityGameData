using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {

    public int Id { get; set; }
    public string Key { get; set; }

    public QuestItem(int id, string key)
    {
        this.Id = id;
        this.Key = key;
    }
}
