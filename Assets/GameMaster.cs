using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    // Start is called before the first frame update
    public static void DestoryPlayer(Player p){
        Destroy(p.gameObject);
    }

    public static void KillPlayer(Player p){
        DestoryPlayer(p);
    }


    //for enemy settings
    public static void DestoryAlienship(AlienSpaceShip a)
    {
        Destroy(a.gameObject);
    }

    public static void KillAlienship(AlienSpaceShip a)
    {
        DestoryAlienship(a);
    }

    public static void DestoryGPABoss(bosscontroller a)
    {
        Destroy(a.gameObject);
    }

    public static void KillGPABoss(bosscontroller a)
    {
        DestoryGPABoss(a);
    }
}
