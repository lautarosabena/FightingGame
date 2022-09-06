using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRed : MonoBehaviour
{
    //[SerializeField] private CharacterController Player;
    public Rigidbody rigidbody;
    public Rigidbody ExternalForce;
    private Vector3 currentMovement;
    public ParticleSystem trompada2;
    [SerializeField] private AudioSource audio;
    public Vector3 poss;
    void Start()
    {
        //Player.enabled = true;
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Joystick2Horizontal");
        float v = Input.GetAxisRaw("Joystick2Vertical");
        currentMovement = new Vector2(Input.GetAxisRaw("Joystick2Horizontal"), Input.GetAxisRaw("Joystick2Vertical")).normalized;
        rigidbody.AddForce(new Vector3(h, 0, v).normalized * Time.deltaTime * 3000f);
        rigidbody.AddForce(-Vector3.up.normalized * Time.deltaTime * 1000f);
        
        handleRotation();

    }

    void handleRotation()
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = new Vector3(currentMovement.x, 0, currentMovement.y);
        Vector3 positionToLookAt = currentPosition + newPosition;
        transform.LookAt(positionToLookAt);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "PJNEGRO")
        {
            rigidbody.AddForce(ExternalForce.transform.forward * 1000f);
            poss = collision.transform.position;
            Instantiate(trompada2, poss, Quaternion.identity);
            trompada2.Play();
            Debug.Log("asdasdadsa");
        }
    }
}
