using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector_Raycast : MonoBehaviour
{
    public bool grounded;
    public float length = 0.45f;
    public LayerMask mask;

    public List<Vector3> originPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grounded = false;
        for (int i = 0; i < originPoints.Count; i++)
        {
           RaycastHit2D hit = Physics2D.Raycast(transform.position + originPoints[i], Vector3.down, length, mask);
           if (hit.collider != null)
           {
                if(hit.collider.tag == "MPlatform")
                {
                    transform.parent = hit.transform;
                }
                else
                {
                    transform.parent = null;
                }
              grounded = true;
           }
        }
        if (!grounded)
        {
            transform.parent = null;
        }
    }
}
