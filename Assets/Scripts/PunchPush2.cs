using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchPush2 : MonoBehaviour
{
    public Vector3 poss;
    
    public ParticleSystem trompada2;
    public int knock2 = 0;
    private AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
       /* if (RagdollActivater2.colliderfollow == 1) {
            
            knock2 = 0;
            RagdollActivater2.colliderfollow = 0;
            Debug.Log(RagdollActivater2.colliderfollow);
        }
        */
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        float force = 0;
            
        if (collision.collider.tag == "punio2")
        {
            audio.Play();
            knock2 = knock2 + 1;
            hit2();
            Debug.Log("golpe2");
            //Vector3 dir = collision.contacts[0].point - transform.position;
            //dir = -dir.normalized;
            //GetComponent<Rigidbody>().AddForce(dir * force);
            poss = collision.transform.position;
            //Debug.Log(knock);

        }

        
    }

    public void hit2()
    {
        Instantiate(trompada2, poss, Quaternion.identity);
        trompada2.Play();
    }
}
