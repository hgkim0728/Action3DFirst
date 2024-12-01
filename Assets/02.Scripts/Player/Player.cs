using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    #region Move
    protected Rigidbody rigid;

    public float moveSpeed = 1.0f;
    public float rotationSpeed = 100f;
    public float gravity = -3f;
    #endregion

    #region Animation
    protected Animator animator;

    
    #endregion

    protected void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    protected void Update()
    {
        Move();
        AnimationStateCheck();
    }
}