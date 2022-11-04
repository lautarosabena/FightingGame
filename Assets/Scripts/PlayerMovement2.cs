using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Photon.Pun;
public class PlayerMovement2 : MonoBehaviour
{
    PlayerInput input;
    public static Vector3 currentMovement;
    public Rigidbody m_Rigidbody;
    public Rigidbody REDRB;
    public float m_Speed;
    public int asd = 1;
    public int Jumping = 2;
    public int Punching = 1;
    public int Punching2 = 3;
    private Vector3 inputVector;
    //private Animator animator;
    public float timer = 0;
    public GameObject obj;
    public float maxdist = 0;
    [SerializeField] private Animator animator;
    private Rigidbody[] rigidbodies;
    public int condition3 = 0;
    private Vector3 movimiento;
    public float speed;
    int actualtaunt;
    private bool cantaunt = false;
    [SerializeField] private CharacterController Player;
    [SerializeField] private Transform Punchs;
    //public PlayerMovement2 p;
    public int knock;
    public Vector3 poss;
    public ParticleSystem trompada2;
    [SerializeField] private AudioSource audio;
    private Vector3 playerVelocity;
    private bool Grounded = false;
    private Vector3 moveDirection = Vector3.zero;
    public float timersalto;
    public bool attacking = true;

    [SerializeField] private PlayerInput PlayerInput;
    void Awake() 
    {
        
        input = new PlayerInput();
        input.CharacterControls.Teclado.performed += ctx => {
            //currentMovement = ctx.ReadValue<Vector2>();
            //currentMovement.Normalize();
            //Debug.Log(ctx.ReadValueAsObject());
            audio = GetComponent<AudioSource>();

        };
        
    }

    void OnEnable()
    {
        input.CharacterControls.Enable();
    }

    void OnDisable()
    {
        input.CharacterControls.Disable();
    }

    PhotonView view;

    void Start()
    {
        rigidbodies = transform.GetComponentsInChildren<Rigidbody>();
        //SetEnabled(false);
        view = GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        Player.enabled = true;
    }

        
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(Punchs.transform.position, 2.5f);
    }
    void Update()
    {
        //REDRB.useGravity = false;
        timersalto -= Time.deltaTime;
        //Debug.Log(timersalto);
        //Debug.Log("Grounded" + Grounded);
        //Sistema de golpes
        //Debug.Log(knock);
        Collider[] hitColliders = Physics.OverlapSphere(Punchs.transform.position, 2.5f);

        Player.Move(moveDirection * Time.deltaTime);
        //Player.Move(playerVelocity * Time.deltaTime);
        //Punching = 2;

        


        if (cantaunt == false)
        {
            
            animator.ResetTrigger("Taunt1");
            animator.ResetTrigger("Taunt2");
            animator.ResetTrigger("Taunt3");
            animator.ResetTrigger("Taunt4");
            //Debug.Log("Desactivando");
        }

        if (currentMovement.x != 0 || currentMovement.y != 0)
        {
            
            animator.SetBool("IsRunning", true);
            cantaunt = false;


        }
        else
        {

            animator.SetBool("IsRunning", false);
        }
        //Debug.Log(cantaunt);
        if(currentMovement.x == 0 && currentMovement.y == 0)
        {
            if (Input.GetKeyUp(KeyCode.Joystick1Button4))
            {
                cantaunt = true;
                int actualtaunt;
                actualtaunt = Random.Range(0, 4);
                switch (actualtaunt)
                {
                    case 0:
                        animator.SetTrigger("Taunt1");
                        break;
                    case 1:
                        animator.SetTrigger("Taunt2");
                        break;
                    case 2:
                        animator.SetTrigger("Taunt3");
                        break;
                    case 3:
                        animator.SetTrigger("Taunt4");
                        break;
                }
                Debug.Log(actualtaunt);
            }
        }
        
        

        
        

        currentMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        transform.position += Vector3.up;
        transform.position -= Vector3.up;
        //Debug.Log(RagdollActivater.sabanamogolico);
        //condition3 = PunchPush.knock;
        //transform.position = transform.position + new Vector3(0, -10, 0) * Time.deltaTime;
        timer -= Time.deltaTime;
        if (timer <= 0) {
            Grounded = true;
            animator.SetBool("IsJumping", false);
            
            //Player.Move(new Vector3 (0, -10f, 0));
            //animator.SetBool("IsJumping", true);

        }

        //Debug.Log(timer);

        
            //transform.position = transform.position + new Vector3(0, -3f, 0) * Time.deltaTime;
         if (RagdollActivater2.quase == false) 
         {
                
                float h = Input.GetAxisRaw("Horizontal");
                float v = Input.GetAxisRaw("Vertical");
                
                //Player.Move(Vector3.forward * Time.deltaTime * 10f);
                Player.Move(new Vector3(h, 0, v).normalized * Time.deltaTime * 20f);
                //Player.Move(-Vector3.up.normalized * Time.deltaTime * 10f);
                //playerVelocity.y += -10f * Time.deltaTime;
                //transform.position = transform.position + (new Vector3(h, 0, v).normalized * Time.deltaTime * 10f);
                //OnMovement();
                //OnTeclado();


                
                handleRotation();
            if (Input.GetKey(KeyCode.Joystick1Button3) || Input.GetKeyDown("space"))
            {

                if (Punching == 1)
                {
                    Punching = 2;
                    Punching2 = 4;
                    animator.SetBool("PunchRight", true);

                    for (int i = 0; i < hitColliders.Length; i++)
                    {
                        GameObject hitCollider = hitColliders[i].gameObject;
                        if (hitCollider.CompareTag("Player"))
                        {
                            poss = hitCollider.transform.position;
                            Instantiate(trompada2, poss, Quaternion.identity);
                            trompada2.Play();
                            audio.Play();
                            Debug.Log("ASD");
                            knock = knock + 5;
                            //REDRB.isKinematic = false;
                            //REDRB.AddForce(-poss * 150f);
                            //REDRB.AddForceAtPosition(poss - transform.position * 50f, transform.position, ForceMode.Impulse);
                        }
                    }

                    //REDRB.isKinematic = true;
                    Invoke("desactivator", 0.5f);
                    Invoke("desactivator2", 1.5f);
                }
            }
            else if (Input.GetKey(KeyCode.Joystick1Button2))
            {
                if (Punching2 == 3)
                {
                    Punching2 = 4;

                    animator.SetBool("PunchLeft", true);

                    for (int i = 0; i < hitColliders.Length; i++)
                    {
                        GameObject hitCollider = hitColliders[i].gameObject;
                        if (hitCollider.CompareTag("Player"))
                        {
                            Instantiate(trompada2, poss, Quaternion.identity);
                            trompada2.Play();
                            audio.Play();
                            Debug.Log("ASD");
                            knock = knock + 2;
                        }
                    }
                    Invoke("desactivator", 0.5f);


                }
            }




        }
            
        
        

        
        //transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, speed * Time.deltaTime);

        //transform.rotation = obj.transform.rotation;

        


        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxdist)) 
        {

            if (Input.GetKey(KeyCode.Joystick1Button0) && timersalto <= 0)
            {
                timersalto = 3f;
                Debug.Log("PISOO");
                animator.SetBool("IsJumping", false);
                moveDirection.y = 10f;

               

            }
        } else
         {
            //timersalto = 2f;
            moveDirection.y += -20f * Time.deltaTime;
            animator.SetBool("IsJumping", true);



        }

        //OnDrawGizmos();
        }

        

       
    


    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * maxdist);
    }


    void handleRotation() {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = new Vector3(currentMovement.x, 0, currentMovement.y);
        Vector3 positionToLookAt = currentPosition + newPosition;
        transform.LookAt(positionToLookAt);
    }

    void OnTeclado() 
    {
        //m_Rigidbody.AddForce(currentMovement * m_Speed); 
        //transform.position + currentMovement;
        //transform.Translate(currentMovement * Time.deltaTime * m_Speed);
        movimiento = new Vector3(currentMovement.x, 0, currentMovement.y).normalized;
        //movimiento.Normalize();
        //transform.Translate (movimiento *  m_Speed * Time.deltaTime);
        //m_Rigidbody.MovePosition(transform.position + movimiento *  10f * Time.deltaTime);
        Player.Move(movimiento * 10f * Time.deltaTime);
        transform.position = transform.position + movimiento *  10f * Time.deltaTime;
        //transform.Translate(Vector3.left * Time.deltaTime * m_Speed);
        Vector2 inputMovimiento = currentMovement;
        inputVector = new Vector3(inputMovimiento.x, 0, inputMovimiento.y);
        inputVector.Normalize();
        //Debug.Log(movimiento);
        
    }

    void OnJumpKeyboard() 
    {
        //transform.Translate(Vector3.up * Time.deltaTime * 2000f);
        
        if (Jumping == 1 && timer <= 0) 
        {
            animator.SetBool("IsJumping", true); 
            //transform.Translate(new Vector3(0, 150f, 0) * Time.deltaTime);
            m_Rigidbody.AddForce(Vector3.up * 1000f);
            Jumping = 2;
            timer = 1.15f;
            Debug.Log("salto");
            
            
        }
 
    }

    void Tauntss()
    {
        
        
      if(Input.GetKeyUp(KeyCode.Joystick1Button4))
        {
            actualtaunt = Random.Range(0, 4);
            Debug.Log(actualtaunt);
        }
                
        

    }

    void OnPunchRightKeyboard() {
        if (Punching == 1) 
        {
            Punching = 2;
            
            animator.SetBool("PunchRight", true);
            Invoke("desactivator", 0.5f);
            
        }
        
    }

    void OnPunchLeftKeyboard() 
    {
        if (Punching == 1) 
        {
            
            Punching = 2;
            
            animator.SetBool("PunchLeft", true);
            Invoke("desactivator", 0.5f);
            
        }

    }

    void desactivator() {
        animator.SetBool("PunchRight", false);
        animator.SetBool("PunchLeft", false);
        Punching2 = 3;
        //REDRB.isKinematic = true;

    }

    void desactivator2()
    {
        Punching = 1;

    }




    //void SetEnabled(bool enabled)
    //{
    //bool isKinematic = !enabled;
    //bool gravityenable = enabled;
    //foreach (Rigidbody rigidbody in rigidbodies)
    //{
    //Debug.Log(rigidbody);
    // rigidbody.isKinematic = isKinematic;

    //  }

    //animator.enabled = !enabled;
    // }





}



