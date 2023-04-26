using System.Collections;
using UnityEngine;

public class armrotating : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationOffset = 90f;

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
        diff.Normalize();

        float rotz = Mathf.Atan2(diff.y, diff.x)*Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0f,0f,rotz + rotationOffset );

    }
}
