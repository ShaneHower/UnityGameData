using UnityEngine;

public class UsableItem : MonoBehaviour {

    // Game Objects and Components
    private Rigidbody2D rigb;
    public GameObject player;
    public GameObject itemData;

    // Simple Data Types
    public int itemId;
    public bool objAdded;
    public bool inTrigger;

	void Start () {

        rigb = GetComponent<Rigidbody2D>();

	}
	
	void Update () {

        Interact();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            inTrigger = false;
        }

    }

    private void Interact()
    {
        if (inTrigger)
        {
            if (Input.GetKey(KeyCode.E))
            {
                ItemCache cache = itemData.GetComponent<ItemCache>();
                cache.itemId = itemId;
                cache.itemAdded = true;
                Destroy(this.gameObject);
            }
        }
    }
}
