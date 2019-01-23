using UnityEngine;

public class InventoryMenu : MonoBehaviour {

    // Game Objects and Components
    public GameObject inventory;
    public GameObject player;

    // Scripts
    public PlayerMovement moveScript;

	// Use this for initialization
	void Start () {
        moveScript = player.GetComponent<PlayerMovement>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!inventory.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                inventory.SetActive(true);
                moveScript.stopMovement = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                inventory.SetActive(false);
                moveScript.stopMovement = false;
            }
        }
	}
}
