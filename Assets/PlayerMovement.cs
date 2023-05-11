using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    [SerializeField] Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", xAxis);
        animator.SetFloat("Vertical", yAxis);

        Vector2 movement = new Vector2(xAxis, yAxis);

        animator.SetFloat("Speed", movement.sqrMagnitude);

        rb.velocity = movement.normalized * speed;
    }
}