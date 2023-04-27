using System.Collections;
using UnityEngine;
using Pathfinding;

public class bosscontroller : MonoBehaviour
{

    [System.Serializable]
    public class Boss
    {
        public int MaxHealth = 500;
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

    public Boss BS = new Boss();
    public HealthbarScript healthBar;
    [Header("Optional: ")]
    [SerializeField]

    public AIPath aiPath;
    public Sprite angryStageSprite;
    public Sprite initialStageSprite;
    public float stage1_speed;
    public float stage2_speed;
    private SpriteRenderer spriteRenderer;
    private bool stage2 = false;


    void Start()
    {
        BS.Init();

        //for photo update
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = initialStageSprite;

        //setting the health bar
        healthBar.SetMaxHealth(BS.MaxHealth);

    }

    void Update()
    {
        if (BS.curHealth <= BS.MaxHealth/2 && angryStageSprite != null)
        {
            stage2 = true;
            //change stage,photo
            spriteRenderer.sprite = angryStageSprite;
            aiPath.maxSpeed = stage2_speed;



        }
        else
        {

            //stage 1, random move
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            transform.Translate(randomDirection.normalized * stage1_speed * Time.deltaTime, Space.World);
        }

    }

    // OnCollisionEnter2D is called when a collision occurs
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is the player
        if (collision.collider.CompareTag("Player"))
        {
            // Perform damage handling for player
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                if (stage2)
                {
                    player.DamagePlayer(10);
                }
                else
                {
                    player.DamagePlayer(5);
                }
            }
        }
    }

    public void DamageBoss(int d)
    {
        BS.curHealth -= d;
        if (BS.curHealth <= 0)
        {
            GameMaster.KillGPABoss(this);
        }

        healthBar.SetHealth(BS.curHealth);
    }


}

