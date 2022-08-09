using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public float timer;
    public int PJ1Wins;
    public int PJ2Wins;
    // Start is called before the first frame update
    void Start()
    {
        PJ1Wins = 10;
        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        LevelFinished();
        timer -= Time.deltaTime;
        LoadData();
    }

    public void LevelFinished()
    {
        if (timer <= 0)
        {
            if (PJ1Wins > PJ2Wins)
            {
                //Debug.Log("Ganador P1");
            } else if (PJ2Wins > PJ1Wins)
            {
                //Debug.Log("Ganadpr P2");
            }
        }
    }

    private void LoadData()
    {
        PJ1Wins = Respawner.points;
        
        int points = PlayerPrefs.GetInt("Puntos");
        Debug.Log(PJ1Wins);
        
    }


}
