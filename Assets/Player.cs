using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   private Animator            m_animator;
    private Rigidbody2D         m_body2d;
	[System.Serializable]
	public class PlayerStats {
		public int health = 100;
	}

	public PlayerStats ps = new PlayerStats();

	public int fallBoundary = -10;
    void Start(){
        m_animator = GetComponent<Animator>();
    }

	void Update () {
		if (transform.position.y <= fallBoundary)
			DamagePlayer (9999999);
	}

    public void DamagePlayer(int d){
        ps.health -= d;
        if (ps.health <= 0){
            m_animator.SetBool("isDead", true);
            GameMaster.KillPlayer(this);
        }
    }
}
