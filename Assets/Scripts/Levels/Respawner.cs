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
    public static bool reseter = false;
    public static bool tremendo = false;
    public static int NewLvl = 1;
    int CurrentLvl = 0;
    public GameObject pauseScreen;

    public static int pointsRojo;
    public static int pointsNegro;
    public static int levelsplayed;
    private string level;
    private string pointsRojoPrefsName = "pointsRojo";
    private string pointsNegroPrefsName = "pointsNegro";
    private string levelsPrefsName = "levels";
    public static Scene currentScene;
    private bool isPaused = false;

    private void Awake()
    {
       // LoadData();
    }


    public 
    // Start is called before the first frame update
    void Start()
    {
        PJNEGROCH.enabled = true;
        PJROJOCH.enabled = true;
        //LoadData();
        one = true;
        two = true;
        three = true;
    }

    void ChangeLevel()
    {
        
        NewLvl ++;
        
      
       
      
            switch (NewLvl)
            {
                case 1:
                    SceneManager.LoadScene("PlataformaLoca");
                    CurrentLvl = 1;
                    niveles++;
                    
                    break;
                case 2:
                    SceneManager.LoadScene("PilarGiratorio");
                    CurrentLvl = 2;
                    niveles++;
                    break;
                case 3:
                    SceneManager.LoadScene("CalleLevel");
                    CurrentLvl = 3;
                    niveles++;
                    break;
                case 4:
                    SceneManager.LoadScene("AutitosChocadores");
                    CurrentLvl = 4;
                    niveles++;
                    break;
                case 5:
                    SceneManager.LoadScene("Monedacas");
                    CurrentLvl = 5;
                    niveles++;
                    break;
                case 6:
                    if (NewLvl == 6 && pointsNegro > pointsRojo)
                    {
                        SceneManager.LoadScene("PJNEGROWIN");
                        niveles = 0;
                        pointsNegro = 0;
                        pointsRojo = 0;
                        NewLvl = 1;
                    } 
                    if(NewLvl == 6 && pointsNegro < pointsRojo)
                    {
                        SceneManager.LoadScene("PJROJOWIN");
                        niveles = 0;
                        pointsNegro = 0;
                        pointsRojo = 0;
                        NewLvl = 1;
                
                    } 
                    if (NewLvl == 6 && pointsNegro == pointsRojo)
                    {
                        SceneManager.LoadScene("EMPATESCENE");
                        niveles = 0;
                        pointsNegro = 0;
                        pointsRojo = 0;
                        NewLvl = 1;
                    }
                    break;

            }
        
        
    }

    
    // Update is called once per frame
    void Update()
    {

        if (timerr <= 0)
        {
            ChangeLevel();
        }

        if (Input.GetKeyDown("e"))
        {
            ChangeLevel();
            Debug.Log("CAMBIASODELEVEL" + CurrentLvl);
        }


        if (isPaused == false && Input.GetKeyUp(KeyCode.Joystick1Button7) || Input.GetKeyUp(KeyCode.Joystick1Button7))
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
            isPaused = true;
            
            
        }

        if (isPaused == true && Input.GetKeyUp(KeyCode.Joystick1Button1) || Input.GetKeyUp(KeyCode.Joystick1Button1))
        {
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
            isPaused = false;
        }




        if (pointsRojo < 0)
        {
            pointsRojo = 0;
        }

        if (pointsNegro < 0)
        {
            pointsNegro = 0;
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

        if (NewLvl == 6 && pointsNegro > pointsRojo)
        {
            SceneManager.LoadScene("PJNEGROWIN");
            niveles = 0;
            pointsNegro = 0;
            pointsRojo = 0;
        } 
        if(NewLvl == 6 && pointsNegro < pointsRojo)
        {
            SceneManager.LoadScene("PJROJOWIN");
            niveles = 0;
            pointsNegro = 0;
            pointsRojo = 0;
        } 
        if (NewLvl == 6 && pointsNegro == pointsRojo)
        {
            SceneManager.LoadScene("EMPATESCENE");
            niveles = 0;
            pointsNegro = 0;
            pointsRojo = 0;
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
                reseter = true;
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
                tremendo = true;
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
                PJNEGRO.transform.position = respawn.position;
                PJNEGROCH.enabled = true;
                pointsRojo ++;

            }

            if(RagdollActivater2.quase == true && PJNEGROBody.position.y <= -10)
            {
                PJNEGROCH.enabled = false;
                
                PJNEGROCH.transform.position = respawn.position;
                PJNEGROBody.transform.position = respawn.position;
                PJNEGROCH.enabled = true;
                
                RagdollActivater2.quase = false;
                pointsRojo++;
                reseter = true;
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
                //PJROJOCH.transform.position = respawn.position + new Vector3(0, 30, 0);
                PJROJOCH.enabled = true;
                pointsNegro ++;
                tremendo = true;
            }

        } else
        {
            two = false;
        }

        if (sceneName == "AutitosChocadores")
        {
            two = true;
            if (PJNEGRO.position.y <= -10)
            {
                //PJNEGROCH.enabled = false;
                PJNEGRO.transform.position = respawn.position;
                //PJNEGROCH.enabled = true;
                pointsRojo++;

            }

            


            if (PJROJO.position.y <= -10)
            {
                //PJROJOCH.enabled = false;
                PJROJO.transform.position = respawn.position;
                //PJROJOCH.enabled = true;
                pointsNegro++;
            }

            

        }
        

        if (sceneName == "PlataformaLoca")
        {
            three = true;
            if (PJNEGRO.position.y <= -0)
            {
                PJNEGROCH.enabled = false;
                PJNEGRO.transform.position = respawn.position;
                PJNEGROCH.enabled = true;
                pointsRojo ++;

            }

            if (RagdollActivater2.quase == true && PJNEGROBody.position.y <= -0)
            {
                PJNEGROCH.enabled = false;

                PJNEGROCH.transform.position = respawn.position;
                PJNEGROBody.transform.position = respawn.position;
                PJNEGROCH.enabled = true;

                RagdollActivater2.quase = false;
                pointsRojo++;
                reseter = true;
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
                tremendo = true;
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
