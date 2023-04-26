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
}
