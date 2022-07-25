using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public Transform body;
    public Transform pj;
    public Transform respawn;
    public 
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (body.position.y <= 0) {
           pj.position = respawn.position;
           Debug.Log(pj); 
        }
        
    }
}
