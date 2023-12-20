using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject collectibleObject;
    public GameObject enemyObject;
    public float areaRange = 20f;
    public int coinAmount = 10;
    public bool isGameActive = false;
    public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCollectibleObject();
    }

    public void StartSpawner()
    {
        isGameActive = true;
        StartCoroutine(CreateRandomAmountOfEnemies());
    }

    void SpawnRandomEnemy()
    {
        Instantiate(enemyObject, CreateRandomSpawnPosition(), enemyObject.transform.rotation);
    }

    public void SpawnCollectibleObject()
    {
        for (int i = 0; i < coinAmount; i++)
        {
            Instantiate(collectibleObject, CreateRandomSpawnPosition(), collectibleObject.transform.rotation);
        }

        coinAmount = 1;
    }

    Vector3 CreateRandomSpawnPosition()
    {
        float xValue = Random.Range(-areaRange, areaRange);
        float zValue = Random.Range(-areaRange, areaRange);
        Vector3 randomPosition = new Vector3(xValue, 1f, zValue);

        return randomPosition;
    }

    IEnumerator CreateRandomAmountOfEnemies()
    {
        while (isGameActive)
        {
            int amountOfTime = Random.Range(1, 8);
            yield return new WaitForSeconds(amountOfTime);

            int amountofEnemies = Random.Range(1, 3);
            for (int i = 0; i < amountofEnemies; i++)
            {
                SpawnRandomEnemy();
            }
        }
    }
}