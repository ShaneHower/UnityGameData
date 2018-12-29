using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Game Objects
    private Rigidbody2D rigb;
    private Animator anim;

    // Other Data Types
    private int speed;
    public float x;
    public float y;
    public int isDodging;
    public bool stopMovement;

	// Use this for initialization
	void Start () {
        rigb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        speed = 3;
       
		
	}

    // Update is called once per frame
    void Update()
    {
        // Pause for Menus
        if (stopMovement)
        {
            Time.timeScale = 0;
        }

        else
        {
            // unpause
            Time.timeScale = 1;

            // key for running
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 6;
            }
            else
            {
                speed = 3;
            }

            // key for dodging 
            if (Input.GetKey(KeyCode.Space))
            {
                isDodging = 1;
            }
            else
            {
                isDodging = 0;
            }

            // getaxis raw returns if the button is being pressed
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");

            rigb.velocity = new Vector2(x * speed, y * speed);

            // sends values to the animator so it knows what to fire when
            anim.SetFloat("x", x);
            anim.SetFloat("y", y);
            anim.SetInteger("isDogding", isDodging);
        }

       
    } 
	
}
