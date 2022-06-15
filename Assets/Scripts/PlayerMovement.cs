using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            transform.position += input.normalized * moveSpeed * Time.fixedDeltaTime;
        }
    }
}
