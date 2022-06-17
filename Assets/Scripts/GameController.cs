using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private LineRenderer line;
    private GameObject[] players;
    public float distance;

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

        Debug.Log(Vector3.Angle((players[0].transform.position - players[1].transform.position), Vector3.right)); 
    }
}
