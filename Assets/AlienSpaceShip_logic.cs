using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Diagnostics;

public class AlienSpaceShip_logic : MonoBehaviour
{
    public AIPath aiPath;
    public float newSpeed;
    public float health;
    // Update is called once per frame
    void Update()
    {
        //reset the speed 
        aiPath.maxSpeed = newSpeed;
        //the path is going right
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1, 1);

        }
        //the path is going left
        else if (aiPath.desiredVelocity.x<=-0.01f)
        {
            transform.localScale = new Vector3(-1f, 1, 1);
        }

    }

    // OnCollisionEnter2D is called when a collision occurs
    void OnCollisionEnter2D(Collision2D collision)
    {
        UnityEngine.Debug.Log("testing");
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reduce health of the AlienSpaceShip
            health -= 1;

            // Check if health is depleted
            if (health <= 0)
            {
                // Destroy the AlienSpaceShip object
                Destroy(gameObject);
            }

            // Perform damage handling for player
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                // Call the DamagePlayer method with the desired damage value
                player.DamagePlayer(1000);
            }
        }
    }
}
