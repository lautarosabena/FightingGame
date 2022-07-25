using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFixer : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = obj.transform.rotation;
        //transform.position = transform.position + new Vector3(0, -10, 0) * Time.deltaTime;
    }
}
