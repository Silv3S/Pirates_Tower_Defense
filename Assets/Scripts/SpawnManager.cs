using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] Enemies;

    float timeBetweenWaves = 7f;
    float countdown = 2f;
    int waveNumber = 0;
    bool spawnEnemies = true;

    int[,] waves = {{0, 0, 0, 4, 4},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 1},
                    {0, 0, 0, 1, 1},
                    {0, 0, 1, 1, 1},
                    {0, 0, 1, 1, 2},
                    {1, 1, 1, 1, 2},
                    {1, 1, 2, 2, 2},
                    {2, 2, 2, 2, 2},
                        };

 

    

    void Update()
    {



        if (!(spawnEnemies))
        {
            return;
        }

        if (countdown <= 0f)
        {
            spawnEnemies = false;
            StartCoroutine(SpawnWave());;
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < 5; i++)
        {
            if (waves[waveNumber, i] < 3)
            {
                Instantiate(Enemies[waves[waveNumber, i]]);
                yield return new WaitForSeconds(2.0f);
            }
        }
        spawnEnemies = true;
        waveNumber++;

        if (waveNumber == 9)
        {
            waveNumber = 0;
            Enemy.healthMultiplier *= 2;
        }

    }
}
