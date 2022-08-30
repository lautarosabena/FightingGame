using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAndBomb : MonoBehaviour
{
    private float timer;
    [SerializeField] private GameObject Coin;
    [SerializeField] private GameObject Bomb;
    [SerializeField] private Transform spawnTrigger;
    //[SerializeField] private Vector3 test;
    // Start is called before the first frame update
    void Start()
    {
        timer = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnBombOrCoin();
            timer = Random.Range(1, 3);
        }
    }

    private void SpawnBombOrCoin()
    {
        int randomizer;
        randomizer = Random.Range(1, 10);
        Debug.Log(randomizer);
        bool isbomb = false;
        if (randomizer > 4)
        {
            isbomb = false;
        }
        else if (randomizer < 4)
        {
            isbomb = true;
        }
        Vector3 spawnPosition = new Vector3(-27 + Random.insideUnitSphere.x * 30,
                 5, 0 + Random.insideUnitSphere.z * 30);
        if (!isbomb)
        {
            Instantiate(Coin, spawnPosition, Quaternion.identity);
        } else if (isbomb)
        {
            Instantiate(Bomb, spawnPosition, Quaternion.identity);
        }
    }
}
