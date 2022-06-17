using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float distance1;
    private float distance2;
    private GameObject[] players;

    private void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 2)
        {
            distance1 = Vector2.Distance(transform.position, players[0].transform.position);
            distance2 = Vector2.Distance(transform.position, players[1].transform.position);
            if (distance1 <= distance2)
            {
                Move(players[0].transform.position);
            }
            else
            {
                Move(players[1].transform.position);
            }
        }
    }

    private void Move(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }
}
