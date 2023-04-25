using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class AlienSpaceShip_logic : MonoBehaviour
{
    public AIPath aiPath;
    
    // Update is called once per frame
    void Update()
    {
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
}
