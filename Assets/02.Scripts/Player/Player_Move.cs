using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float rotationSpeed = 100f;

    private Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, -1, z);
        rigid.velocity = moveDir * moveSpeed;

        if(x != 0 || z != 0)
        {
            Rotate(moveDir);
        }
    }

    private void Rotate(Vector3 _moveDir)
    {
        Quaternion playerRotation = Quaternion.LookRotation(_moveDir, Vector3.up);
        playerRotation.z = 0;
        playerRotation.x = 0;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, 
            playerRotation, rotationSpeed * Time.deltaTime);
    }
}
