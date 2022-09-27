using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing2 : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform playerCam;
    private Rigidbody rb;
    private CarRed pm;
    public ParticleSystem BoostVFX;
    public AudioSource BoostSFX;

    [Header("Dashing")]
    public float dashForce;
    public float dashUpwardForce;
    public float dashDuration;
    public bool isActive;

    [Header("Cooldown")]
    public float dashCd;
    private float dashCdTimer;

    [Header("Input")]
    public KeyCode dashKey = KeyCode.Space;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<CarRed>();
    }

    private void Update()
    {
        if (dashCdTimer > 0)
        {
            dashCdTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button2) )
        {
            Dash();
            isActive = true;
        } else if (Input.GetKeyUp(KeyCode.Joystick2Button2))
        {
            isActive = false;
        }


        if (dashCdTimer <= 0)
        {

        }

        if (isActive == false)
        {
            BoostVFX.Stop();
            return;
        }
    }

    private void Dash()
    {
        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashUpwardForce;
        rb.AddForce(forceToApply, ForceMode.Impulse);
        BoostVFX.Play();
        BoostSFX.Play();
        Debug.Log("Dash Rojo");

        Invoke(nameof(ResetDash), dashDuration);
        
    }

    

    private void ResetDash()
    {
        
    }
}
