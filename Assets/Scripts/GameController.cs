using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private LineRenderer line;
    [SerializeField] private GameObject[] players;
    public float distance;
    public float angle;

    private List<GameObject> enemies;
    private int enemyPool = 20;
    [SerializeField] private GameObject originEnemy;
    [SerializeField] private GameObject[] enemySpawnPoints;

    private List<GameObject> explosionFxs;
    private int fxPool = 20;
    [SerializeField] private GameObject originFx;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        line.positionCount = 2;
        SetEnemyPool();
        SetExplosionFxPool();
    }

    private void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 1)
        {
            line.gameObject.SetActive(false);
        }
        else
        {
            distance = Vector2.Distance(players[0].transform.position, players[1].transform.position);
            if (distance < 8)
            {
                line.gameObject.SetActive(true);
                line.SetPosition(0, players[0].transform.position);
                line.SetPosition(1, players[1].transform.position);
            }
            else
            {
                line.gameObject.SetActive(false);
            }
        }

        if (players.Length == 2)
        {
            for (int i = 0; i < enemySpawnPoints.Length; i++)
            {
                enemySpawnPoints[i].SetActive(true);
            }

            if (players[0].transform.position.y >= players[1].transform.position.y)
            {
                angle = Vector3.Angle((players[0].transform.position - players[1].transform.position), Vector3.right);
            }
            else
            {
                angle = Vector3.Angle((players[1].transform.position - players[0].transform.position), Vector3.right);
            }
        }
    }

    private void SetEnemyPool()
    {
        enemies = new List<GameObject>();
        for (int i = 0; i < enemyPool; i++)
        {
            GameObject enemy = Instantiate(originEnemy);
            enemy.SetActive(false);
            enemies.Add(enemy);
        }
    }

    public GameObject GetEnemyPool()
    {
        foreach (GameObject enemy in enemies)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }
        GameObject obj = Instantiate(originEnemy);
        obj.SetActive(true);
        enemies.Add(obj);
        return obj;
    }

    private void SetExplosionFxPool()
    {
        explosionFxs = new List<GameObject>();
        for (int i = 0; i < fxPool; i++)
        {
            GameObject fx = Instantiate(originFx);
            fx.SetActive(false);
            enemies.Add(fx);
        }
    }

    public GameObject GetExplosionFxPool()
    {
        foreach (GameObject fx in explosionFxs)
        {
            if (!fx.activeInHierarchy)
            {
                fx.SetActive(true);
                return fx;
            }
        }
        GameObject obj = Instantiate(originFx);
        obj.SetActive(true);
        explosionFxs.Add(obj);
        return obj;
    }
}
