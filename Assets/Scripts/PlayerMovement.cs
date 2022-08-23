using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class PlayerMovement : MonoBehaviour
{
    public Transform target;
    
    PlayerInput input;
    Vector2 currentMovement;
    public Rigidbody m_Rigidbody;
    public float m_Speed = 1f;
    public int asd = 1;
    public int Jumping = 2;
    public int Punching = 1;
    private Vector3 inputVector;
    private Vector2 asdd;
    //private Animator animator;
    public float timer = 0;
    public GameObject obj;
    public float maxdist = 0;
    [SerializeField] private Animator animator;
    private Rigidbody[] rigidbodies;
    public int condition4 = 0;
    private Vector3 movimiento2;
    public float speed;
    [SerializeField] private CharacterController Player2;

    
    [SerializeField] private PlayerInput PlayerInput;
    void Awake() 
    {
        input = new PlayerInput();
        input.CharacterControls.Movement.performed += ctx => {
        //currentMovement = ctx.ReadValue<Vector2>();
        //Debug.Log(ctx.ReadValueAsObject());
        
        
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Respawner.currentScene.name == "SampleScene")
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
                animator.SetBool("IsJumping", false); 
            }

        //Debug.Log(timer);

        if (view.IsMine) {
            //transform.position = transform.position + new Vector3(0, -3f, 0) * Time.deltaTime;
        
            
            if (RagdollActivater.sabanamogolico2 == false)
            {

                float h = Input.GetAxisRaw("Joystick2Horizontal");
                float v = Input.GetAxisRaw("Joystick2Vertical");
                Player2.Move(new Vector3(h, 0, v).normalized * Time.deltaTime * 30f);
                Player2.Move(-Vector3.up.normalized * Time.deltaTime * 10f);
                //OnMovimiento();
                handleRotation();

                if (Input.GetKey(KeyCode.Joystick2Button0))
                {
                    Debug.Log("entrada 1");
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
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxdist)) {
            //Debug.Log(Jumping);
            
            Jumping = 1;
            
        }

        OnDrawGizmos();
        }

        

       
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



