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
    public float timerr = 3f;
    public PlayerMovement2 a;
    public static bool quase = false;
    public static bool sabana = false;
    public bool morision = true;
    private Vector3 poss;
    public Vector3 respawn;
    public bool chan2;
    public GameObject respawnmodel = GameObject.FindGameObjectWithTag("respawnmodel");
    public GameObject respawnmodel2 = GameObject.FindGameObjectWithTag("respawnmodel2");
    public GameObject respawnmodel3 = GameObject.FindGameObjectWithTag("respawnmodel3");
    public GameObject positioncheck;
    public float timerinmortal = 3;
    public bool lastnumber = false;
    public int change = 0;
    public bool recentknock = false;
    public float thetimer = 50f;

    //Rigidbody rigidbodii;
    // Start is called before the first frame update
    void Awake()
    {
        chan2 = false;

        //rigidbodii = GetComponent<Rigidbody>();
        MainCollider = GetComponent<Collider>();
        AllColliders = GetComponentsInChildren<Collider>(true);
        DoRagdoll(false);
        MainCollider.enabled = true;
        respawnmodel.SetActive(false);
        respawnmodel2.SetActive(true);
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
            respawn = rig.transform.position + Vector3.up * 10;
        }
        MainCollider.enabled = false;

        respawnmodel.SetActive(true);
        respawnmodel2.SetActive(true);

        thetimer = 0.3f;
    }

    private void Start()
    {
        sabana = false;
        fixer = true;
    }

    void Update() 
    {
        timerinmortal -= Time.deltaTime;
        if (timerinmortal >= 0)
        {
            gameObject.layer = LayerMask.NameToLayer("INMORTAL");
            if (thetimer <= 0 && recentknock == true)
            {


                if (lastnumber == true)
                {
                    respawnmodel2.SetActive(true);
                    respawnmodel3.SetActive(false);
                    thetimer = 0.3f;
                }

                if (lastnumber == false)
                {
                    respawnmodel3.SetActive(true);
                    respawnmodel2.SetActive(false);
                    thetimer = 0.3f;
                }


            }
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("RAGDOLL2");
            respawnmodel2.SetActive(true);
            respawnmodel3.SetActive(false);
        }

        thetimer -= Time.deltaTime;
        if (thetimer <= 0)
        {
            lastnumber = !lastnumber;
        }
        respawnmodel.transform.position = positioncheck.transform.position - new Vector3(0, 0, 0);
        if (Input.GetKeyDown("t"))
        {
            a.knock = 15;
        }

        chan2 = Respawner.tremendo;
        if (chan2 == true)
        {
            Levantarse();
            reiniciartiempo();
            
            Debug.Log("CAMBIASOOOOOOOOOOOOOOOOOOOOOOOROJO");
            Respawner.tremendo = false;
            chan2 = false;
        }
        
        //Debug.Log(Respawner.reseter);
        

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
            sabana = true;
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
                //Debug.Log("FUERZFUERZ");
                //rig.AddForce(transform.up * 500f);
            }
            gameObject.layer = LayerMask.NameToLayer("RAGDOLLOFF");
            morision = false;
            sabana = true;
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
                rig.AddForce(poss * 100f);
                //Debug.Log("FUERZFUERZ");
                //rig.AddForce(transform.up * 500f);
            }
            //Debug.Log(timerr);
            gameObject.layer = LayerMask.NameToLayer("RAGDOLLOFF");
            morision = false;
            sabana = true;
            SonidoChoque.Play();
            SonidoChoque2.Play();
            

        }

        
    }

    void Levantarse() {
            quase = false;
            a.knock = 0;
            DoRagdoll(true);
            DoRagdoll(false);
            sabana = false;
            morision = true;
            MainCollider.transform.position = respawn;
            //PJ.transform.position = player.transform.position + new Vector3(0, 5, 0);
            PJ.enabled = true;
            gameObject.layer = LayerMask.NameToLayer("RAGDOLL");
            fixer = true;
            MainCollider.enabled = true;
            respawnmodel.SetActive(false);
            recentknock = true;
            timerinmortal = 3;
        //colliderfollow = 0;
    }


    void reiniciartiempo() 
        {
            timerr = 3f;
            PJ.enabled = true;
        }
}
