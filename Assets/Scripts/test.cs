using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject PJNEGRO;
    public Transform Teleport;

    void Update()
    {
     
      

    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            PJNEGRO.transform.position = Teleport.position;
            Debug.Log("asdasdadsa");
        }
    }
}