using UnityEngine;

public class UsableItem : MonoBehaviour {

    // Game Objects and Components
    private Rigidbody2D rigb;
    public GameObject player;
    public GameObject inventory;

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
                ItemData data = inventory.GetComponent<ItemData>();
                data.id = itemId;
                data.objAdded = true;
                Destroy(this.gameObject);
            }
        }
    }
}
