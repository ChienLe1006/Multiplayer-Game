using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class Enemy : MonoBehaviour
{
    private SkeletonAnimation skeletonAnimation;
    private Skeleton skeleton;

    [SerializeField] private float moveSpeed;
    private float distance1;
    private float distance2;
    private GameObject[] players;

    private void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        skeleton = skeletonAnimation.skeleton;
    }

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

    public void Explode()
    {
        GameObject explosionFx = GameController.instance.GetExplosionFxPool();
        explosionFx.SetActive(true);
        explosionFx.transform.position = transform.position;
        skeleton.SetColor(Vector4.zero);
        GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(Helper.StartAction(() =>
        {
            explosionFx.SetActive(false);
            gameObject.SetActive(false);
        }, 0.5f));
    }
}
