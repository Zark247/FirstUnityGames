using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rigidbody;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    bool left = false;
    bool right = false;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hello World!");
        //rigidbody.useGravity = false;
        
    }

    void Update()
    {
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            left = true;
        }
        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            right = true;
        }
        
    }

    // FixedUpdate is called once per frame for PHYSICS
    void FixedUpdate()
    {
        //Adds a forward force(x,y,z,forcemode) forward force(z)
        rigidbody.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (left == true)
        {
            //Left direction
            rigidbody.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            left = false;
        }
        else if (right == true)
        {
            //Right direction
            rigidbody.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            right = false;
        }
        if(rigidbody.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
