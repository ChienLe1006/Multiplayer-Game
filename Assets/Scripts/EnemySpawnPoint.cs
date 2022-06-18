using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        GameObject enemy = GameController.instance.GetEnemyPool();
        enemy.transform.position = transform.position;
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        StartCoroutine(SpawnEnemy());
    }
}
