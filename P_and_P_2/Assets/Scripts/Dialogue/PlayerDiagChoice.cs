using UnityEngine;

public class PlayerDiagChoice : MonoBehaviour {

    // Game Objects
    public GameObject dialBox;
    public GameObject interactable;
    public Animator anim;

    // Scripts
    TextBoxManager txtBoxMgmt;

    // other data type
    public string interName;

	// Use this for initialization
	void Start () {
        txtBoxMgmt = dialBox.GetComponent<TextBoxManager>();

	}
	
	// Update is called once per frame
	void Update () {
        interactable = GameObject.FindWithTag(interName);
        anim = interactable.GetComponent<Animator>();

    }

    public void Yes()
    {
        txtBoxMgmt.displayOptions = false;
        dialBox.SetActive(false);
        anim.SetInteger("Open", 1);
        anim.SetInteger("Open", 2);
    }

    public void No()
    {
        dialBox.SetActive(false);
    }

    // TODO have the textboxmanager sending obj name, however it's sending the key,
    // have to write in the data base in order to grab what the key opens.
    // send name to inventory see if any items are the key for it then destroy
}
