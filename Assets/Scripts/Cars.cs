using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject car2;
    [SerializeField] private GameObject car3;
    [SerializeField] private GameObject car4;
    private bool started = true;
    private bool started2 = true;
    private int aut = 0;
    private int aut2 = 0;
    private float cont = 5;
    public Rigidbody carrr;
    [SerializeField] private GameObject[] cars;
    public AudioSource MusicLvl2;

    
    void Start()
    {
        //carSpawn();
        MusicLvl2.Play();
        
    }

    
    void Update()
    {
        cars = GameObject.FindGameObjectsWithTag("car");
        //car.transform.position = transform.position + Vector3.right * 10f * Time.deltaTime;
        cont -= Time.deltaTime;
        Timer();

        if (started == true)
        {
            switch (aut)
            {
                case 1:
                    car.transform.position = car.transform.position + Vector3.right * 40f * Time.deltaTime;
                    //Debug.Log("asd");
                    carrr.isKinematic = false;
                    break;
                case 2:
                    car2.transform.position = car2.transform.position + Vector3.right * 40f * Time.deltaTime;
                    //Debug.Log("asd");
                    break;
               
                
            }
        }

        if (started2 == true)
        {
            switch (aut2)
            {
                
                case 1:
                    car3.transform.position = car3.transform.position + Vector3.left * 40f * Time.deltaTime;
                    //Debug.Log("asd");
                    break;
                case 2:
                    car4.transform.position = car4.transform.position + Vector3.left * 40f * Time.deltaTime;
                    //Debug.Log("asd");
                    break;

            }
        }


        if (car.transform.position.x >= 35)
        {
            car.transform.position = new Vector3(-60, 1, -1);
            car.transform.rotation = Quaternion.Euler(0, 90, 0);
            carrr.isKinematic = true;
            started = false;
        }

        if (car2.transform.position.x >= 35)
        {
            car2.transform.position = new Vector3(-60, car2.transform.position.y, car2.transform.position.z);
            car2.transform.rotation = Quaternion.Euler(0, 90, 0);
            started = false;
        }

        if (car3.transform.position.x <= -60)
        {
            car3.transform.position = new Vector3(35, car3.transform.position.y, car3.transform.position.z);
            car3.transform.rotation = Quaternion.Euler(0, -90, 0);
            started2 = false;
        }

        if (car4.transform.position.x <= -60)
        {
            car4.transform.position = new Vector3(35, car4.transform.position.y, car4.transform.position.z);
            car4.transform.rotation = Quaternion.Euler(0, -90, 0);
            started2 = false;
        }

        /*void carSpawn()
        {
            spawners = GameObject.FindGameObjectsWithTag("spawners");

            foreach (GameObject cars in spawners)
            {
                if (aut == true)
                {
                    Instantiate(car, transform.position, Quaternion.identity);
                    aut = false;
                }

            }
        }
        */




    }



    public void Timer()
    {
        if (cont <= 0)
        {
            started = true;
            started2 = true;
            aut = Random.Range(1, 3);
            aut2 = Random.Range(1, 3);
            //Debug.Log(aut);
            //Debug.Log(aut2);
            cont = 6;
        }
    }
    
    

    



        


}
