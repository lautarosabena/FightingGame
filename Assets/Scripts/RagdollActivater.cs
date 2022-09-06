using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RagdollActivater : MonoBehaviour
{
    public Collider MainCollider;
    public Collider[] AllColliders;
    public Rigidbody[] AllRigidbodies;
    public CharacterController PJ;
    public Transform player;
    public bool isRagdoll;
    public AudioSource SonidoChoque;
    public AudioSource SonidoChoque2;
    public bool fixer = false;
    public int condition = 0;
    public float timerr = 5f;
    public PlayerMovement2 a;
    public static bool quase = false;
    public static bool sabanamogolico2 = false;
    public bool morision = true;
    private Vector3 poss;
    public bool chan2;

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
        fixer = false;
        foreach (var col in AllColliders)
        {
            col.enabled = true;
            PJ.enabled = false;
            //MainCollider.enabled = !isRagdoll;
            GetComponent<Rigidbody>().useGravity = !isRagdoll;
            GetComponent<Animator>().enabled = !isRagdoll;
        }

        foreach (var rig in AllRigidbodies)
        {
            rig.isKinematic = false;
            //rig.AddForce(transform.up * 500f);
        }
    }

    private void Start()
    {
        sabanamogolico2 = false;
        fixer = true;
    }

    void Update() 
    {
        chan2 = Respawner.reseter2;
        if (chan2 == true)
        {
            Levantarse();
            reiniciartiempo();
            chan2 = false;
            Debug.Log("CAMBIASOOOOOOOOOOOOOOOOOOOOOOO");
        }
        if (Input.GetKeyDown("space"))
        {
            DoRagdoll(true);
        }
        Debug.Log(Respawner.reseter);
        if (Respawner.reseter == true)
        {
            Levantarse();
            reiniciartiempo();
            Respawner.reseter = false;
            Debug.Log("CAMBIASOOOOOOOOOOOOOOOOOOOOOOO");
        }

        if (fixer == true)
        {

            foreach (var rig in AllRigidbodies)
            {
                rig.isKinematic = true;
            }

        }
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
        a = FindObjectOfType<PlayerMovement2>();

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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coins")
        {
            Respawner.pointsNegro = Respawner.pointsNegro + 1;
            DoRagdoll(true);
            poss = other.transform.position;
            foreach (var rig in AllRigidbodies)
            {
                rig.AddForce(poss * 150f);
                Debug.Log("FUERZFUERZ");
                //rig.AddForce(transform.up * 500f);
            }
            gameObject.layer = LayerMask.NameToLayer("RAGDOLLOFF");
            morision = false;
            sabanamogolico2 = true;
            //Respawner.pointsRojo = Respawner.pointsRojo + 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "car")
        {
            Respawner.pointsNegro = Respawner.pointsNegro + 1;
            //Debug.Log("Do something");
            DoRagdoll(true);
            poss = collision.transform.position;
            foreach (var rig in AllRigidbodies)
            {
                rig.AddForce(poss * 150f);
                Debug.Log("FUERZFUERZ");
                //rig.AddForce(transform.up * 500f);
            }
            //Debug.Log(timerr);
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
            //PJ.transform.position = player.transform.position + new Vector3(0, 5, 0);
            PJ.enabled = true;
            gameObject.layer = LayerMask.NameToLayer("RAGDOLL");
            fixer = true;
        //colliderfollow = 0;
    }


    void reiniciartiempo() 
        {
            timerr = 5f;
            PJ.enabled = true;
        }
}
