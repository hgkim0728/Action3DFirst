using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float MoveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward);
    }
}
