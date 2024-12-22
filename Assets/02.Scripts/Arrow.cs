using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float MoveSpeed;

    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * MoveSpeed);
    }
}
