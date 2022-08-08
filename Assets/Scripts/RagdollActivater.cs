using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RagdollActivater : MonoBehaviour
{
    public Collider MainCollider;
    public Collider[] AllColliders;
    public Transform player;
    public bool isRagdoll;
    public AudioSource SonidoChoque;
    public AudioSource SonidoChoque2;
    public int condition = 0;
    public float timerr = 5f;
    public PunchPush a;
    public static bool quase = false;
    public static bool sabanamogolico2 = false;
    public bool morision = true;
    //Rigidbody rigidbodii;
    // Start is called before the first frame update
    void Awake()
    {
        //rigidbodii = GetComponent<Rigidbody>();
        MainCollider = GetComponent<Collider>();
        AllColliders = GetComponentsInChildren<Collider>(true);
        DoRagdoll(false);
        MainCollider.enabled = true;
    }

    // Update is called once per frame
    public void DoRagdoll(bool isRagdoll)
    {
        foreach (var col in AllColliders)
        col.enabled = true;
        //MainCollider.enabled = !isRagdoll;
        GetComponent<Rigidbody>().useGravity = !isRagdoll;
        GetComponent<Animator>().enabled = !isRagdoll;
    }

    void Update() 
    {
        //Debug.Log(timerr);

        if (morision == false)
        {
            timerr -= Time.deltaTime;
            if (timerr <= 0)
            {
                Levantarse();
                reiniciartiempo();
                //colliderfollow = 1;
            }
        }
        a = FindObjectOfType<PunchPush>();

        if (a.knock >= 15) 
        {
            DoRagdoll(true);
            sabanamogolico2 = true;
            //Debug.Log(timerr);
            gameObject.layer = LayerMask.NameToLayer("RAGDOLLOFF");
            
            timerr -= Time.deltaTime;
            if (timerr <= 0) 
            {
                Levantarse();
                reiniciartiempo();
                //colliderfollow = 1;
            } 
            
        }


        
        
        /*if (Input.GetKeyDown(KeyCode.R))
        {
            MainCollider.transform.position = player.transform.position;
            gameObject.layer = LayerMask.NameToLayer("RAGDOLLOFF");
            //rigidbodii.AddForce(transform.up * 500f);
            
            
            DoRagdoll(true);
            Debug.Log("ASD");
            GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>().enabled = true;
            
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            
            DoRagdoll(false);
            MainCollider.enabled = !isRagdoll;
            Debug.Log("ASD");
            //GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>().enabled = true;
        } */

     




        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "car")
        {
            Debug.Log("Do something");
            DoRagdoll(true);
            Debug.Log(timerr);
            gameObject.layer = LayerMask.NameToLayer("RAGDOLLOFF");
            morision = false;
            sabanamogolico2 = true;
            SonidoChoque.Play();
            SonidoChoque2.Play();


        }
    }

    void Levantarse() {
            quase = false;
            a.knock = 0;
            DoRagdoll(true);
            DoRagdoll(false);
            sabanamogolico2 = false;
            morision = true;
            gameObject.layer = LayerMask.NameToLayer("RAGDOLL");
            //colliderfollow = 0;
        }


    void reiniciartiempo() 
        {
            timerr = 5f;
        }
}
