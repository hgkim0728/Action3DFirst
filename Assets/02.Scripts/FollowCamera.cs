using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform playerTrs;

    void Start()
    {
        playerTrs = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 point = playerTrs.position;
        point.y += 6.5f;
        point.z -= 8.5f;
        transform.position = point;
    }
}
