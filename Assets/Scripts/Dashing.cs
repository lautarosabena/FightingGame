using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform playerCam;
    private Rigidbody rb;
    private CarBlack pm;
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
    public KeyCode dashKey = KeyCode.LeftShift;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<CarBlack>();
    }

    private void Update()
    {
        if (dashCdTimer > 0)
        {
            dashCdTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown("space"))
        {
            Dash();
            isActive = true;
        } else if (Input.GetKeyUp(KeyCode.Joystick1Button2) || Input.GetKeyUp("space"))
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

        Invoke(nameof(ResetDash), dashDuration);
        
    }

    private void ResetDash()
    {
        
    }
}
