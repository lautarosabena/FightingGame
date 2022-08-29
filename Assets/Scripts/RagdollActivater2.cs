using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RagdollActivater2 : MonoBehaviour
{
    public Collider MainCollider;
    public CharacterController PJ;
    public Collider[] AllColliders;
    public Transform player;
    public bool isRagdoll;
    public int condition2 = 0;
    //public Transform follower;
    ///public static int colliderfollow = 0;
    public float timerr = 5f;
    //public PlayerMovement2 p;
    public static bool quase = false;
    public bool morision = true;
    // Start is called before the first frame update
    public AudioSource SonidoChoque;
    public AudioSource SonidoChoque2;
    void Awake()
    {
        MainCollider = GetComponent<BoxCollider>();
        AllColliders = GetComponentsInChildren<Collider>(true);
        DoRagdoll2(false);
        MainCollider.enabled = true;
        //AllColliders[2].enabled = true;
        //SonidoChoque = GetComponent<AudioSource>();
    }

    private void Start()
    {
        quase = false;
    }

    // Update is called once per frame
    public void DoRagdoll2(bool isRagdoll)
    {
        
        foreach (var col in AllColliders)
        col.enabled = true;
        PJ.enabled = false;
        //MainCollider.enabled = !isRagdoll;
        GetComponent<Rigidbody>().useGravity = !isRagdoll;
        GetComponent<Animator>().enabled = !isRagdoll;
    }

    void Update() 
    {
        MainCollider.enabled = true;
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
        

        /*if (p.knock >= 15) 
        {
            quase = true;
            DoRagdoll2(true);
            //Debug.Log(timerr);
            gameObject.layer = LayerMask.NameToLayer("RAGDOLLOFF");
            timerr -= Time.deltaTime;
            if (timerr <= 0) 
            {
                Levantarse();
                reiniciartiempo();
                //colliderfollow = 1;
            } 
            
        } */

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

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "car")
        {
            //Debug.Log("Do something");
            DoRagdoll2(true);
            //Debug.Log(timerr);
            gameObject.layer = LayerMask.NameToLayer("RAGDOLLOFF");
            morision = false;
            quase = true;
            SonidoChoque.Play();
            SonidoChoque2.Play();



        }

        if (collision.gameObject.tag == "GAMEOVER")
        {
            //Debug.Log("sapoooooooooooo");
           
            // PUT HERE THE POINT AND CHANGE LEVEL FUNCTIONS


        }






    }

    void Levantarse() {
            quase = false;
            //p.knock = 0;
            //DoRagdoll2(true);
            DoRagdoll2(false);
            morision = true;
            //player.transform.position = PJ.transform.position;
            PJ.transform.position = player.transform.position + new Vector3(0, 5, 0);
            PJ.enabled = true;
            gameObject.layer = LayerMask.NameToLayer("RAGDOLL2");
            //colliderfollow = 0;
        }


    void reiniciartiempo() {
            timerr = 5f;
            PJ.enabled = true;
    }
}
