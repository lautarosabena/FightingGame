using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchRaycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 1f)) {
            //Debug.Log(Jumping);
            
            
            
        }

        OnDrawGizmos();
        

        

       
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.forward * 1f);
    }
    
}
