using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soporte1 : MonoBehaviour
{
    public float speed;
    public Vector3 asd;
    public Vector3 asd2;
    public GameObject sabanatiragoma;
    public bool sabanamogolico = false;
    public float timer;
    public float asd3 = 6;
    public float maxdist;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        asd = new Vector3(1, 8, -7);
        asd2 = new Vector3(1, 1, -7);
    }

    // Update is called once per frame
    void Update()
    {
        
        sabanatiragoma.transform.Rotate(Vector3.back * 60f * Time.deltaTime);

        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * maxdist);
    }
    private void sabanamogolicoenfermito()
    {
        
            sabanamogolico = true;
       
    }

    private void facuamigazofacheraso()
    {
        
           
            sabanamogolico = false;
       
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "car")
        {
            Debug.Log("Do something");
        }





    }

}
