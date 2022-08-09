using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Respawner : MonoBehaviour
{
    public Transform PJNEGRO;
    public Transform PJROJO;
    public Transform respawn;
    public bool isRagdoll;
    public float timerr = 10;
    public int escena;
    public bool one;
    public bool two;
    public bool three;
    public int niveles = 0;
    public Text text;
    public Text scene;

    public static int points;
    private string level;
    private string pointsPrefsName = "points";
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
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        scene.text = currentScene.name.ToString();
        text.text = points.ToString();
        //Debug.Log(points);
        timerr -= Time.deltaTime;
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

        if (sceneName == "PilarGiratorio" && timerr <= 0 && two == true)
        {
            
            SceneManager.LoadScene("SampleScene");
            timerr = 10;
            Debug.Log("cambianod nivel uno");
            niveles = niveles + 1;
            
        }

        if (sceneName == "SampleScene" && timerr <= 0 && three == true)
        {
            
            SceneManager.LoadScene("CalleLevel");
            timerr = 10;
            Debug.Log("cambianod nivel calle");
            niveles = niveles + 1;
            

        }

        if (niveles == 3)
        {
            niveles = 4;
            SceneManager.LoadScene("MainMenu");
        }

        if (sceneName == "CalleLevel")
        {
            one = true;
            if (PJNEGRO.position.z >= 14 || PJNEGRO.position.z <= -18 || PJNEGRO.position.x <= -40 || PJNEGRO.position.x >= -4)
                    {
                        PJNEGRO.position = respawn.position;
                points = points + 1;
                        
                    }
            if (PJROJO.position.z >= 14 || PJROJO.position.z <= -18 || PJROJO.position.x <= -40 || PJROJO.position.x >= -4)
                    {
                        PJROJO.position = respawn.position;
                        
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
                PJNEGRO.position = respawn.position;
                points = points + 1;

            }
            if (PJROJO.position.y <= -10)
            {
                PJROJO.position = respawn.position;
                
            }
        } else
        {
            two = false;
        }

        if (sceneName == "SampleScene")
        {
            three = true;
            if (PJNEGRO.position.y <= -0)
            {
                PJNEGRO.position = respawn.position;
                points = points + 1;

            }
            if (PJROJO.position.y <= -0)
            {
                PJROJO.position = respawn.position;
                
            }
        }
        else
        {
            three = false;
        }



    }
    
    

    

    //private void LoadData()
   // {
       // int points = PlayerPrefs.GetInt("Puntos", 0);
       // level = PlayerPrefs.GetString(levelsPrefsName);
   // }
}
