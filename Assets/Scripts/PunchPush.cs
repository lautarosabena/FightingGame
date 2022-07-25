using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchPush : MonoBehaviour
{
    public Vector3 poss;
    public ParticleSystem trompada;
   
    public  int knock = 0;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hit()
    {
        Instantiate(trompada, poss, Quaternion.identity);
        trompada.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float force = 0;
        audio.Play();
        if (collision.collider.tag == "punio")
        {
            Debug.Log("golpe 1");
            knock = knock + 1;
            hit();
            //GetComponent<Rigidbody>().AddForce(Vector3.up * 500f);
            //Vector3 dir = collision.contacts[0].point - transform.position;
            //dir = -dir.normalized;
            //GetComponent<Rigidbody>().AddForce(dir * force);
            poss = collision.transform.position;
            //Debug.Log(knock);

        }

        
    }

    

    
}
