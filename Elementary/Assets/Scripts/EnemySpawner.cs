using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2; // Asigna tu prefab de enemigo aquí
    public int numberOfEnemies = 5;

    void Start()
    {

        StartCoroutine(SpawnEnemies());
       
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            int randomChoice = Random.Range(1, 3); // Genera 1 o 2

            if (randomChoice == 1)
            {
                Instantiate(enemyPrefab, GetRandomPosition(), Quaternion.identity);
            }
            else if (randomChoice == 2)
            {
                Instantiate(enemyPrefab2, GetRandomPosition(), Quaternion.identity);
            }

            yield return new WaitForSeconds(10f); // Espera 10 segundos
        }
    }


    Vector3 GetRandomPosition()
    {
        // Retorna una posición aleatoria; ajusta esto según tus necesidades
        return new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
    }
}