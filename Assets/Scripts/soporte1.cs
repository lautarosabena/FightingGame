using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soporte1 : MonoBehaviour
{
    public float speed;
    public Vector3 asd;
    public Vector3 asd2;
    public GameObject sabanatiragoma;
    public bool sabanamogolico = false;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        asd = new Vector3(0, 1, 0);
        asd2 = new Vector3(0, -5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.zero;
        sabanatiragoma.transform.Rotate(Vector3.back * 35f * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            sabanamogolico = false;

        }

        if (timer <= -3)
        {
            sabanamogolico = true;
            timer = 3;

        }
        if (sabanamogolico == true)
        {
            sabanatiragoma.transform.position = sabanatiragoma.transform.position + (Vector3.up.normalized * speed * Time.deltaTime);
        }
        else
        {
            sabanatiragoma.transform.position = sabanatiragoma.transform.position + (-Vector3.up.normalized * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "car")
        {
            Debug.Log("Do something");
        }





    }

}
