using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Joystick2Horizontal");
        float v = Input.GetAxisRaw("Joystick2Vertical");
        transform.position += new Vector3(h, 0, v) * Time.deltaTime * 10f;
    }
}
