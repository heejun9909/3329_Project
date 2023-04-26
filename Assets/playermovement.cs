using UnityEngine;
using System.Collections;

public class playermovement : MonoBehaviour {

    [SerializeField] float      m_speed = 4.0f;
    [SerializeField] float      m_jumpForce = 7.5f;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private sensor       m_groundSensor;
    // private bool                m_grounded = true;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<sensor>();
    }
	
	// Update is called once per frame
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Jump") && !m_animator.GetBool("isJump")){
            m_body2d.AddForce(Vector2.up * m_jumpForce, ForceMode2D.Impulse);  
            m_animator.SetBool("isJump", true);
        }


        // //Check if character just landed on the ground
        // if (!m_grounded && m_groundSensor.State()) {
        //     m_grounded = true;
        //     m_animator.SetBool("Grounded", m_grounded);
        // }

        // //Check if character just started falling
        // if(m_grounded && !m_groundSensor.State()) {
        //     m_grounded = false;
        //     m_animator.SetBool("Grounded", m_grounded);
        // }

        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
            transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        else if (inputX < 0)
            transform.localScale = new Vector3(-3.0f, 3.0f, 3.0f);

        // Move
        m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

        // if (Input.GetKeyDown("space") && m_grounded) {
        //     m_body2d.AddForce(Vector2.up * m_jumpForce, ForceMode2D.Impulse); 
        //     m_grounded = false;
        //     m_animator.SetBool("Grounded", m_grounded);
        //     m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
        //     m_groundSensor.Disable(0.2f);
        // }else 
        if (Mathf.Abs(inputX) >Mathf.Epsilon){
            m_animator.SetBool("isRun", true);
        } else {
            m_animator.SetBool("isRun", false);
        }       
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (m_body2d.velocity.y < 0){
            Debug.DrawRay(m_body2d.position,Vector3.down, new Color(0,1,0));
            RaycastHit2D rayhit = Physics2D.Raycast(m_body2d.position,Vector3.down, 1.0f, LayerMask.GetMask("ground"));
            if (rayhit.collider != null){
                if (rayhit.distance< 1f){
                    m_animator.SetBool("isJump", false);
                }
            }
        } 
    }

}


