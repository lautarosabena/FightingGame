using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBlack : MonoBehaviour
{
    //[SerializeField] private CharacterController Player;
    public Rigidbody rigidbody;
    public Rigidbody ExternalForce;
    private Vector3 currentMovement;

    void Start()
    {
        //Player.enabled = true;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        currentMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

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
        if (collision.collider.tag == "PJROJO")
        {
            rigidbody.AddForce(ExternalForce.transform.forward * 300f);
            Debug.Log("asdasdadsa");
        }
    }
}
