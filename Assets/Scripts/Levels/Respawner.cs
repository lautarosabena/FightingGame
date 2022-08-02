using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Respawner : MonoBehaviour
{
    public Transform body;
    public Transform pj;
    public Transform respawn;
    public 
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        //Debug.Log(sceneName);
        if (body.position.y <= 0) {
           pj.position = respawn.position;
           Debug.Log(pj); 
        }

        if (sceneName == "CalleLevel")
        {
            if (body.position.z >= 14 || body.position.z <= -18 || body.position.x <= -40 || body.position.x >= -4)
                    {
                        pj.position = respawn.position;
                        Debug.Log(pj);
                    }
        }

        

    }
}
