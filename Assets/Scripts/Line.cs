using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public static Line instance;
    private LineRenderer line;
    private BoxCollider2D myCol;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        myCol = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        transform.position = (line.GetPosition(0) + line.GetPosition(1)) / 2;
        myCol.size = new Vector2(GameController.instance.distance, myCol.size.y);
    }
}
