using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour
{   
    public LayerMask wattohit;
    public float  fr = 0;
    public int damage = 10;
    float firetime = 0;
    Transform firepoint;
    public Transform bullettrailprefab;
    float effectspawntime = 0;
    public float effectrate = 10;


    // Start is called before the first frame update
    void Awake()
    {
        firepoint = transform.Find("firepoint");
        if (firepoint == null){
            Debug.LogError("No firepoint");

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fr == 0){
            if (Input.GetButtonDown("Fire1")){
                Shoot();
            }

        }else{
            if (Input.GetButton("Fire1") && Time.time> firetime){
                firetime = Time.time + 1/fr;
                Shoot();
            }
        }
    }
    void Shoot(){
        Vector2 mousepos = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firepointpos = new Vector2(firepoint.position.x,firepoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast (firepointpos, mousepos -firepointpos, 100,wattohit);
        if (Time.time >= effectspawntime){
            effect();
            effectspawntime = Time.time + 1/effectrate ; 
        }
        Debug.DrawLine (firepointpos, (mousepos - firepointpos)*100, Color.cyan);
        if (hit.collider != null){
            Debug.DrawLine (firepointpos, hit.point, Color.red);
 
            //check which enemy hit
            AlienSpaceShip alienSpaceShip = hit.collider.GetComponent<AlienSpaceShip>();
            if (alienSpaceShip != null)
            {
                alienSpaceShip.DamageAlienship(damage);
                Debug.Log("We hit " + hit.collider.name + " and did " + damage + " damage.");
            }

            bosscontroller BS = hit.collider.GetComponent<bosscontroller>();
            if (BS != null)
            {
                BS.DamageBoss(damage);
                Debug.Log("We hit " + hit.collider.name + " and did " + damage + " damage."+ BS.BS.curHealth +" Health remain");

            }

            //Debug.Log("We hit " + hit.collider.name + " and did " + damage + " damage.");
        }
    } 
    void effect(){
        Instantiate (bullettrailprefab, firepoint.position, firepoint.rotation);
    }

}
