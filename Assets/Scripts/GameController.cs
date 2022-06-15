using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    private GameObject[] players;

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
            float distance = Vector2.Distance(players[0].transform.position, players[1].transform.position);
            if (distance < 5)
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
    }
}
