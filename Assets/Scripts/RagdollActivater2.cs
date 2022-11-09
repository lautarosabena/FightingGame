using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RagdollActivater2 : MonoBehaviour
{
    public Collider MainCollider;
    public CharacterController PJ;
    public Collider[] AllColliders;
    public Rigidbody[] AllRigidbodies;
    public Transform player;
    public bool isRagdoll;
    public int condition2 = 0;
    //public Transform follower;
    ///public static int colliderfollow = 0;
    public float timerr = 3f;
    //public PlayerMovement2 p;
    public static bool quase = false;
    public static bool sabana = false;
    public bool morision = true;
    // Start is called before the first frame update
    public AudioSource SonidoChoque;
    public AudioSource SonidoChoque2;
    public bool fixer = false;
    public PlayerMovement b;
    public Vector3 poss;
    public Vector3 respawn;
    public bool chan;
    public GameObject respawnmodel = GameObject.FindGameObjectWithTag("respawnmodel");
    public GameObject respawnmodel2 = GameObject.FindGameObjectWithTag("respawnmodel2");
    public GameObject respawnmodel3 = GameObject.FindGameObjectWithTag("respawnmodel3");
    public GameObject positioncheck;
    public float timerinmortal = 3;
    public bool lastnumber = false;
    public int change = 0;
    public bool recentknock = false;
    public float thetimer = 50f;

    void Awake()
    {
        chan = false;
        MainCollider = GetComponent<BoxCollider>();
        AllColliders = GetComponentsInChildren<Collider>(true);
        DoRagdoll2(false);
        MainCollider.enabled = true;
        //AllColliders[2].enabled = true;
        //SonidoChoque = GetComponent<AudioSource>();
        respawnmodel.SetActive(false);
        respawnmodel2.SetActive(true);
    }

    private void Start()
    {
        quase = false;
        fixer = true;
        thetimer = 50f;
    }

    // Update is called once per frame
    public void DoRagdoll2(bool isRagdoll)
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
            respawn = rig.transform.position + Vector3.up * 10;
            //rig.AddForce(transform.up * 500f);
        }
        MainCollider.enabled = false;
        respawnmodel.SetActive(true);
        respawnmodel2.SetActive(true);

        thetimer = 0.3f;

        



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
        } else 
        {
            gameObject.layer = LayerMask.NameToLayer("RAGDOLL2");
            respawnmodel2.SetActive(true);
            respawnmodel3.SetActive(false);
        }
        //Debug.Log(thetimer);
       

        thetimer -= Time.deltaTime;
        if (thetimer <= 0)
        {
            lastnumber = !lastnumber;
        }
        respawnmodel.transform.position = positioncheck.transform.position - new Vector3(0, 0, 0);
        if (Input.GetKeyDown("t"))
        {
            b.knock = 15;
        }
        //Debug.Log(chan);
        
        chan = Respawner.reseter;
        if (chan == true)
        {
            Levantarse();
            reiniciartiempo();
            chan = false;
            timerr = 5f;
            Respawner.reseter = false;
            //Debug.Log("CAMBIASOOOOOOOOOOOOOOOOOOOOOOO");
        }
        b = FindObjectOfType<PlayerMovement>();
        if (fixer == true)
        {
            
            foreach (var rig in AllRigidbodies)
            {
                rig.isKinematic = true;
                
            }
            
        }
        //MainCollider.enabled = true;
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

        //Debug.Log(timerr);
        //p = FindObjectOfType<PlayerMovement2>();
        //Debug.Log(PunchPush2.knock2);
         //Debug.Log(p.knock2);
        

        if (b.knock >= 15) 
        {
            quase = true;
            DoRagdoll2(true);
            //Debug.Log(timerr);
            gameObject.layer = LayerMask.NameToLayer("RAGDOLLOFF");
            timerr -= Time.deltaTime;
            //respawnmodel2.SetActive(false);
            respawnmodel.SetActive(true);
            if (timerr <= 0) 
            {
                Levantarse();
                reiniciartiempo();
                
                //colliderfollow = 1;
            } 
            
        } 

        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            
            MainCollider.transform.position = player.transform.position;
            gameObject.layer = LayerMask.NameToLayer("RAGDOLLOFF");
            DoRagdoll2(true);
            Debug.Log("RAGDOLL ACTIVO");
            GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>().enabled = true;
            //MainCollider = follower.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            DoRagdoll2(false);
            MainCollider.enabled = !isRagdoll;
            Debug.Log("RAGDOLL INACTIVO");
            //GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>().enabled = true;
        }
        */
        

        

        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coins")
        {
            DoRagdoll2(true);
            poss = other.transform.position;
            foreach (var rig in AllRigidbodies)
            {
                rig.AddForce(poss * 150f);
                Debug.Log("FUERZFUERZ");
                //rig.AddForce(transform.up * 500f);
            }
            gameObject.layer = LayerMask.NameToLayer("RAGDOLLOFF");
            morision = false;
            quase = true;

        }

            
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "car")
        {
            Respawner.pointsRojo++;
            DoRagdoll2(true);
            poss = collision.transform.position;
            foreach (var rig in AllRigidbodies)
            {
                rig.AddForce(poss * 100f);
            }
            gameObject.layer = LayerMask.NameToLayer("RAGDOLLOFF");
            morision = false;
            quase = true;
            SonidoChoque.Play();
            SonidoChoque2.Play();



        }

        if (collision.gameObject.tag == "Coins")
        {
            
            Respawner.pointsRojo++;
            poss = collision.transform.position;
            Debug.Log("asdasdasdasd");
            DoRagdoll2(true);
            foreach (var rig in AllRigidbodies)
            {
                rig.AddForce(poss * 150f);
                Debug.Log("FUERZFUERZ");
            }
            morision = false;
            quase = true;
            
            

        }






    }

    void Levantarse() {
            quase = false;
            b.knock = 0;
            DoRagdoll2(true);
            DoRagdoll2(false);
            sabana = false;
            morision = true;
            MainCollider.transform.position = respawn;
            PJ.enabled = true;
            gameObject.layer = LayerMask.NameToLayer("RAGDOLL2");
            fixer = true;
            MainCollider.enabled = true;
            respawnmodel.SetActive(false);
            recentknock = true;
            timerinmortal = 3;
            Debug.Log("REINICIO" + b.knock);
    }


    void reiniciartiempo() {
            timerr = 3f;
            PJ.enabled = true;
    }
}
