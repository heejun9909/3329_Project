using System.Collections;
using UnityEngine;
using Pathfinding;
using System.Diagnostics;
using System;

public class AlienSpaceShip : MonoBehaviour
{
    public AIPath aiPath;
    public float newSpeed;

    [System.Serializable]
    public class AlienStats
    {
        public int MaxHealth = 100;
        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, MaxHealth); }
        }
        public void Init()
        {
            curHealth = MaxHealth;
        }
    }

    public AlienStats AS = new AlienStats();

    [Header("Optional: ")]
    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {
        AS.Init();

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(AS.curHealth, AS.MaxHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //reset the speed 
        aiPath.maxSpeed = newSpeed;
    }

    // OnCollisionEnter2D is called when a collision occurs
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is the player
        if (collision.collider.CompareTag("Player"))
        {
            // Reduce health of the AlienSpaceShip
            AS.curHealth -= 1;

            // Check if health is depleted
            if (AS.curHealth <= 0)
            {
                // Destroy the AlienSpaceShip object
                Destroy(gameObject);
            }

            // Perform damage handling for player
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                // Call the DamagePlayer method with the desired damage value
                player.DamagePlayer(10);
                //maybe destroy itself too
                DamageAlienship(9999);
            }
        }
    }

    public void DamageAlienship(int d)
    {
        AS.curHealth -= d;
        if (AS.curHealth <= 0)
        {
            GameMaster.KillAlienship(this);
        }
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(AS.curHealth, AS.MaxHealth);
        }
    }

}
