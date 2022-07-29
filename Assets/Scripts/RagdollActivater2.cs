using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RagdollActivater2 : MonoBehaviour
{
    public Collider MainCollider;
    public Collider[] AllColliders;
    public Transform player;
    public bool isRagdoll;
    public int condition2 = 0;
    //public Transform follower;
    ///public static int colliderfollow = 0;
    public float timerr = 5f;
    public PunchPush2 p;
    public static bool quase = false;
    public bool morision = true;
    // Start is called before the first frame update
    void Awake()
    {
        MainCollider = GetComponent<Collider>();
        AllColliders = GetComponentsInChildren<Collider>(true);
        DoRagdoll2(false);
        MainCollider.enabled = true;
    }

    // Update is called once per frame
    public void DoRagdoll2(bool isRagdoll)
    {
        
        foreach (var col in AllColliders)
        col.enabled = true;
        
        //MainCollider.enabled = !isRagdoll;
        GetComponent<Rigidbody>().useGravity = !isRagdoll;
        GetComponent<Animator>().enabled = !isRagdoll;
    }

    void Update() 
    {
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
        p = FindObjectOfType<PunchPush2>();
        //Debug.Log(PunchPush2.knock2);
         //Debug.Log(p.knock2);
        

        if (p.knock2 >= 15) 
        {
            quase = true;
            DoRagdoll2(true);
            Debug.Log(timerr);
            gameObject.layer = LayerMask.NameToLayer("RAGDOLLOFF");
            timerr -= Time.deltaTime;
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

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "car")
        {
            Debug.Log("Do something");
            DoRagdoll2(true);
            Debug.Log(timerr);
            gameObject.layer = LayerMask.NameToLayer("RAGDOLLOFF");
            morision = false;
            quase = true;


        }

        if (collision.gameObject.tag == "GAMEOVER")
        {
            Debug.Log("sapoooooooooooo");
           
            // PUT HERE THE POINT AND CHANGE LEVEL FUNCTIONS


        }






    }

    void Levantarse() {
            quase = false;
            p.knock2 = 0;
            DoRagdoll2(true);
            DoRagdoll2(false);
            morision = true;
            gameObject.layer = LayerMask.NameToLayer("RAGDOLL2");
            //colliderfollow = 0;
        }


    void reiniciartiempo() {
            timerr = 5f;
        }
}
