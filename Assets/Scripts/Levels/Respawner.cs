using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Respawner : MonoBehaviour
{
    public Transform PJNEGRO;
    public CharacterController PJNEGROCH;
    public CharacterController PJROJOCH;
    public Transform PJNEGROBody;
    public Transform PJROJO;
    public Transform PJROJOBody;
    public Transform respawn;
    public bool isRagdoll;
    public float timerr = 10;
    public int escena;
    public bool one;
    public bool two;
    public bool three;
    public static int niveles = 0;
    public TextMeshProUGUI PuntosRojoText;
    public TextMeshProUGUI PuntosNegroText;
    public TextMeshProUGUI scene;
    public TextMeshProUGUI TimerText;
    public float PjNegroTimer;
    public float PjRojoTimer;

    public static int pointsRojo;
    public static int pointsNegro;
    public static int levelsplayed;
    private string level;
    private string pointsRojoPrefsName = "pointsRojo";
    private string pointsNegroPrefsName = "pointsNegro";
    private string levelsPrefsName = "levels";
    public static Scene currentScene;


    private void Awake()
    {
       // LoadData();
    }


    public 
    // Start is called before the first frame update
    void Start()
    {
        //LoadData();
        one = true;
        two = true;
        three = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
            
        }
        //Debug.Log(niveles);
        currentScene = SceneManager.GetActiveScene();
        scene.text = currentScene.name.ToString();
        PuntosRojoText.text = pointsRojo.ToString();
        //Debug.Log(pointsRojo);
        PuntosNegroText.text = pointsNegro.ToString();
        //Debug.Log(pointsNegro);
        timerr -= Time.deltaTime;
        TimerText.text = timerr.ToString("00");
        //Debug.Log(niveles);
        
        string sceneName = currentScene.name;
        //Debug.Log(sceneName);
        //PJNEGRO = GameObject.FindGameObjectWithTag("PJNEGRO").transform;

        if (sceneName == "CalleLevel" && timerr <= 0 && one == true)
        {
            SceneManager.LoadScene("PilarGiratorio");
            timerr = 10;
            Debug.Log("cambianod nivel pilar");
            niveles = niveles +1;
            
        }

        if (niveles == 3 && pointsNegro > pointsRojo)
        {
            SceneManager.LoadScene("PJNEGROWIN");
            niveles = 0;
            pointsNegro = 0;
            pointsRojo = 0;
        } 
        if(niveles == 3 && pointsNegro < pointsRojo)
        {
            SceneManager.LoadScene("PJROJOWIN");
            niveles = 0;
            pointsNegro = 0;
            pointsRojo = 0;
        } 
        if (niveles == 3 && pointsNegro == pointsRojo)
        {
            SceneManager.LoadScene("EMPATESCENE");
            niveles = 0;
            pointsNegro = 0;
            pointsRojo = 0;
        }

        if (sceneName == "PilarGiratorio" && timerr <= 0 && two == true)
        {
            
            SceneManager.LoadScene("PlataformaLoca");
            timerr = 10;
            Debug.Log("cambianod nivel uno");
            niveles = niveles + 1;
        
            
        }

        if (sceneName == "PlataformaLoca" && timerr <= 0 && three == true)
        {
            
            SceneManager.LoadScene("CalleLevel");
            timerr = 10;
            Debug.Log("cambianod nivel calle");
            niveles = niveles + 1;
            

        }

        /*if (niveles == 3)
        {
            niveles = 4;
            SceneManager.LoadScene("MainMenu");
        }*/

        if (sceneName == "CalleLevel")
        {
            one = true;
            if (PJNEGRO.position.z >= 14 || PJNEGRO.position.z <= -18 || PJNEGRO.position.x <= -40 || PJNEGRO.position.x >= -4)
                    {
                PJNEGROCH.enabled = false;
                PJNEGROCH.transform.position = respawn.position;
                PJNEGROCH.enabled = true;
                pointsRojo ++;
                Debug.Log("ASD");
                
                
               
                    }
            
            /*if (PJNEGROBody.position.z >= 14 || PJNEGROBody.position.z <= -18 || PJNEGROBody.position.x <= -40 || PJNEGROBody.position.x >= -4)
                    {
                        PJNEGROBody.position = respawn.position;
                        pointsRojo = pointsRojo + 1;
                        
                                                                                          
                    }      
            */
            if(RagdollActivater2.quase == true && PJNEGROBody.position.z >= 14 || PJNEGROBody.position.z <= -18 || PJNEGROBody.position.x <= -40 || PJNEGROBody.position.x >= -4)
            {
                //PJNEGROBody.position = respawn.position;
                //pointsRojo = pointsRojo + 1;
                PJNEGROCH.enabled = false;
                PJNEGROCH.transform.position = respawn.position;
                PJNEGROCH.enabled = true;
                pointsRojo ++;
                                
            }      

            if (PJROJO.position.z >= 14 || PJROJO.position.z <= -18 || PJROJO.position.x <= -40 || PJROJO.position.x >= -4)
                    {
                        PJROJOCH.enabled = false;
                        PJROJOCH.transform.position = respawn.position;
                        PJROJOCH.enabled = true;
                        pointsNegro ++;
                                               
                    }
            
            if(RagdollActivater.sabanamogolico2 == true && PJROJOBody.position.z >= 14 || PJROJOBody.position.z <= -18 || PJROJOBody.position.x <= -40 || PJROJOBody.position.x >= -4)
            {
                PJROJOCH.enabled = false;
                PJROJOCH.transform.position = respawn.position;
                PJROJOCH.enabled = true;
                pointsNegro ++;
                                
            }    
             

        } else
        {
            one = false;
        }

        if (sceneName == "PilarGiratorio")
        {
            two = true;
            if (PJNEGRO.position.y <= -10)
            {
                PJNEGROCH.enabled = false;
                PJNEGROCH.transform.position = respawn.position;
                PJNEGROCH.enabled = true;
                pointsRojo ++;

            }

            if(RagdollActivater2.quase == true && PJNEGROBody.position.y <= -10)
            {
                PJNEGROCH.enabled = false;
                RagdollActivater2.quase = false;
                PJNEGROCH.transform.position = respawn.position;
                PJNEGROCH.enabled = true;
                pointsRojo ++;
                                
            }
               
        
            if (PJROJO.position.y <= -10)
            {
                PJROJOCH.enabled = false;
                PJROJOCH.transform.position = respawn.position;
                PJROJOCH.enabled = true;
                pointsNegro ++;
            }

            if(RagdollActivater.sabanamogolico2 == true && PJROJOBody.position.y <= -10)
            {
                PJROJOCH.enabled = false;
                PJROJOCH.transform.position = respawn.position;
                PJROJOCH.enabled = true;
                pointsNegro ++;
                                
            }

        } else
        {
            two = false;
        }

        if (sceneName == "PlataformaLoca")
        {
            three = true;
            if (PJNEGRO.position.y <= -0)
            {
                PJNEGROCH.enabled = false;
                PJNEGROCH.transform.position = respawn.position;
                PJNEGROCH.enabled = true;
                pointsRojo ++;

            }
            if(RagdollActivater2.quase == true && PJNEGROBody.position.y <= -0)
            {
                RagdollActivater2.quase = false;
                PJNEGROCH.enabled = false;
                PJNEGROCH.transform.position = respawn.position;
                PJNEGROCH.enabled = true;
                pointsRojo ++;
                                
            }
            if (PJROJO.position.y <= -0)
            {
                PJROJOCH.enabled = false;
                PJROJOCH.transform.position = respawn.position;
                PJROJOCH.enabled = true;
                pointsNegro ++;
                
            }
            if(RagdollActivater.sabanamogolico2 == true && PJROJOBody.position.y <= -0)
            {
                PJROJOCH.enabled = false;
                PJROJOCH.transform.position = respawn.position;
                PJROJOCH.enabled = true;
                pointsNegro ++;
                                
            }
        }
        else
        {
            three = false;
        }



    }
    
    

    

    //private void LoadData()
   // {
       // int pointsRojo = PlayerPrefs.GetInt("Puntos", 0);
       // level = PlayerPrefs.GetString(levelsPrefsName);
   // }
}
