using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class PlayerMovement : MonoBehaviour
{
    PlayerInput input;
    Vector2 currentMovement;
    public Rigidbody m_Rigidbody;
    public float m_Speed = 1f;
    public int asd = 1;
    public int Jumping = 2;
    public int Punching = 1;
    private Vector3 inputVector;
    public float timer = 0;
    public GameObject obj;
    public float maxdist = 0;
    [SerializeField] private Animator animator;
    private Rigidbody[] rigidbodies;
    public int condition4 = 0;
    private Vector3 movimiento2;
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
    private Vector3 moveDirection = Vector3.zero;
    private bool Grounded = false;
    private Vector3 playerVelocity;

    [SerializeField] private PlayerInput PlayerInput;
    void Awake() 
    {
        input = new PlayerInput();
        input.CharacterControls.Movement.performed += ctx => {
            //currentMovement = ctx.ReadValue<Vector2>();
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

    // Update is called once per frame
    void Update()
    {
        
        //Sistema de golpes
        //Debug.Log(knock);
        Collider[] hitColliders = Physics.OverlapSphere(Punchs.transform.position, 2.5f);
        


        if (Input.GetKey(KeyCode.Joystick2Button2))
        {

            if (Punching == 1)
            {
                Punching = 2;

                animator.SetBool("PunchRight", true);
                animator.ResetTrigger("Taunt1");
                animator.ResetTrigger("Taunt2");
                animator.ResetTrigger("Taunt3");
                animator.ResetTrigger("Taunt4");
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
                        knock++;
                    }
                }
                Invoke("desactivator", 0.5f);
            }
        }
        else if (Input.GetKey(KeyCode.Joystick2Button3))
        {
            if (Punching == 1)
            {
                Punching = 2;

                animator.SetBool("PunchLeft", true);
                animator.ResetTrigger("Taunt1");
                animator.ResetTrigger("Taunt2");
                animator.ResetTrigger("Taunt3");
                animator.ResetTrigger("Taunt4");
                for (int i = 0; i < hitColliders.Length; i++)
                {
                    GameObject hitCollider = hitColliders[i].gameObject;
                    if (hitCollider.CompareTag("Player"))
                    {
                        Instantiate(trompada2, poss, Quaternion.identity);
                        trompada2.Play();
                        audio.Play();
                        Debug.Log("ASD");
                        knock++;
                    }
                }
                Invoke("desactivator", 0.5f);

            }
        }




        if (currentMovement.x != 0 || currentMovement.y != 0)
        {
            Debug.Log("test");
            animator.ResetTrigger("Taunt1");
            animator.ResetTrigger("Taunt2");
            animator.ResetTrigger("Taunt3");
            animator.ResetTrigger("Taunt4");
            animator.SetBool("IsRunning", true);
            //cantaunt = false;


        }
        else
        {

            animator.SetBool("IsRunning", false);
        }
        Debug.Log(cantaunt);
        if (currentMovement.x == 0 && currentMovement.y == 0)
        {
            if (Input.GetKeyUp(KeyCode.Joystick2Button4))
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
        if (cantaunt == false)
        {
            animator.ResetTrigger("Taunt1");
            animator.ResetTrigger("Taunt2");
            animator.ResetTrigger("Taunt3");
            animator.ResetTrigger("Taunt4");
        }

        if (Respawner.currentScene.name == "PlataformaLoca")
        {

            speed = 10f;




        } else
        {
            speed = 20f;
        }
        currentMovement = new Vector2(Input.GetAxisRaw("Joystick2Horizontal"), Input.GetAxisRaw("Joystick2Vertical")).normalized;
        transform.position += Vector3.up;
        transform.position -= Vector3.up;
        //condition4 = PunchPush2.knock2;
        //transform.position = transform.position + new Vector3(0, -10, 0) * Time.deltaTime;
        timer -= Time.deltaTime;
        if (timer <= 0) {
            Grounded = true;
            animator.SetBool("IsJumping", false);
                //Player.Move(new Vector3(0, -10f, 0 * Time.deltaTime));
        }

        //Debug.Log(timer);

        if (view.IsMine) {
            //transform.position = transform.position + new Vector3(0, -3f, 0) * Time.deltaTime;
        
            
            if (RagdollActivater.sabanamogolico2 == false)
            {

                float h = Input.GetAxisRaw("Joystick2Horizontal");
                float v = Input.GetAxisRaw("Joystick2Vertical");
                Player.Move(new Vector3(h, 0, v).normalized * Time.deltaTime * 30f);
                Player.Move(moveDirection * Time.deltaTime);
                //Player.Move(-Vector3.up.normalized * Time.deltaTime * 10f);
                //OnMovimiento();
                handleRotation();


                if (Input.GetKey(KeyCode.Joystick2Button2))
                {

                        if (Punching == 1)
                    {
                        Punching = 2;

                        animator.SetBool("PunchRight", true);
                        Invoke("desactivator", 0.5f);

                    }
                } else if (Input.GetKey(KeyCode.Joystick2Button3))
                    {
                        if (Punching == 1)
                        {
                            Punching = 2;

                            animator.SetBool("PunchLeft", true);
                            Invoke("desactivator", 0.5f);

                        }
                    }

            }




            //transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, speed * Time.deltaTime);

            //transform.rotation = obj.transform.rotation;

            if (currentMovement.x != 0 || currentMovement.y != 0) {
            //Debug.Log("test");
            animator.SetBool("IsRunning", true);

            
        } else {

            animator.SetBool("IsRunning", false);
        }


        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxdist)) 
            {
                //Debug.Log(Jumping);
                //playerVelocity.y = 0f;
                //Jumping = 1;
                Grounded = true;

                if (Input.GetKey(KeyCode.Joystick2Button0) || Input.GetKeyDown("space"))
                {

                    animator.SetBool("IsJumping", false);
                    moveDirection.y = 20f;
                    //transform.Translate(new Vector3(0, 150f, 0) * Time.deltaTime);
                    //playerVelocity.y += Mathf.Sqrt(1f * -3.0f * -10);
                    //playerVelocity.y += -10f * Time.deltaTime;

                    //m_Rigidbody.AddForce(Vector3.up * 100f);
                    //Jumping = 2;
                    //timer = 2f;
                    Debug.Log("salto");
                    
                }
                
                

            } else
            {
                moveDirection.y += -20f * Time.deltaTime;
                animator.SetBool("IsJumping", true);
                //animator.SetBool("IsJumping", false);
            }

        //OnDrawGizmos();
        }

        

       
    }


    /*void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * maxdist);
    }*/


    void handleRotation() {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = new Vector3(currentMovement.x, 0, currentMovement.y);
        Vector3 positionToLookAt = currentPosition + newPosition;
        transform.LookAt(positionToLookAt);
    }

    void OnMovimiento() 
    {
        //m_Rigidbody.AddForce(currentMovement * m_Speed); 
        //transform.position + currentMovement;
        //transform.Translate(currentMovement * Time.deltaTime * m_Speed);
        movimiento2 = new Vector3(currentMovement.x, 0, currentMovement.y).normalized;
        transform.position = transform.position + movimiento2 *  10f * Time.deltaTime;
        //m_Rigidbody.MovePosition(transform.position + movimiento2 *  10f * Time.deltaTime);
        //transform.Translate(Vector3.left * Time.deltaTime * m_Speed);
        Vector2 inputMovimiento = currentMovement;
        //Player.Move(movimiento2 * 10f * Time.deltaTime);
        inputVector = new Vector3(inputMovimiento.x, 0, inputMovimiento.y);
        
    }

    void OnJumpKeyboard1() 
    {
        //transform.Translate(Vector3.up * Time.deltaTime * 2000f);
        
        if (Jumping == 1 && timer <= 0) 
        {
            animator.SetBool("IsJumping", true); 
            //transform.Translate(new Vector3(0, 150f, 0) * Time.deltaTime);
            m_Rigidbody.AddForce(Vector3.up * 500f);
            Jumping = 2;
            timer = 1.15f;
            Debug.Log("salto");
            
            
        }
 
    }


    void OnPunchRightKeyboard1() {
        if (Punching == 1) 
        {
            Punching = 2;
            
            animator.SetBool("PunchRight", true);
            Invoke("desactivator", 0.5f);
            
        }
        
    }

    void OnPunchLeftKeyboard1() 
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



