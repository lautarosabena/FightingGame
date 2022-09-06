using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsFunctionality : MonoBehaviour
{
    public static int PointsPJN = 0;
    public static int PointsPJR = 0;
    [SerializeField] private GameObject Explosion;
    public static bool Explotadisimo;
    public int Explosiondamage;
    // Start is called before the first frame update
    void Start()
    {
        //PointsPJN = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PjNegro")
        {
            Explosiondamage = Random.Range(1, 5);
            PointsPJN++;
            Debug.Log(PointsPJN);
            Debug.Log("MONEDA NEGRO");
            Instantiate(Explosion, this.transform.position, Quaternion.identity);
            Explotadisimo = true;
            Destroy(gameObject);
            Respawner.pointsNegro = Respawner.pointsNegro - Explosiondamage;
        }

        if (other.gameObject.name == "PjRojo")
        {
            Explosiondamage = Random.Range(1, 5);
            PointsPJR++;
            Debug.Log(PointsPJN);
            Debug.Log("MONEDA ROJO");
            Instantiate(Explosion, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Respawner.pointsRojo = Respawner.pointsRojo - Explosiondamage;
        }
    }
}
