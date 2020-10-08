using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    void OnCollisionEnter(Collision collisionInfo)
    {
        //Debug.Log("We hit " + collisionInfo.collider.name);
        if (collisionInfo.collider.tag == "Obstacle")
        {
            //Debug.Log("We hit an " + collisionInfo.collider.name + "!");
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            
        }
    }
}
