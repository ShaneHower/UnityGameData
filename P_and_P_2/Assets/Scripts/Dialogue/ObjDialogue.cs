using UnityEngine;
using System.Collections.Generic;

public class ObjDialogue : MonoBehaviour {

    // Game Objects
    private Rigidbody2D rigb;
    public GameObject dialogBox;
    public GameObject player;
    public GameObject inventory;

    // Scripts
    public TextBoxManager textBox;

    // Other Data Types
    public bool inBox;
    public List<string> keys;

	// Use this for initialization
	void Start () {

        rigb = GetComponent<Rigidbody2D>();
        textBox = dialogBox.GetComponent<TextBoxManager>();

        dialogBox.SetActive(false);
        		
	}
	
	// Update is called once per frame
	void Update () {

        ReadOrTalk(this.name);
        CheckForObjOfInterest();
        
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            inBox = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            inBox = false;
        }
    }

    private void ReadOrTalk(string refToFetchTxt)
    {
        if (inBox)
        {
            if (Input.GetKey(KeyCode.E))
            {
                dialogBox.SetActive(true);
                textBox.objName = refToFetchTxt;
            }
        }
        else
        {
            dialogBox.SetActive(false);
        }
    }

    private void CheckForObjOfInterest()
    {
        Inventory invScript = inventory.GetComponent<Inventory>();
        keys = invScript.keys;
        foreach(string i in keys)
        {
            textBox.displayOptions = true;
            ReadOrTalk(i);
            
        }
    }
}
