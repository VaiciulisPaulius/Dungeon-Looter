using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    [SerializeField] Animator animator;

    float defaultSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        EnablePlayerMovement();
        defaultSpeed = speed;
    }

    private void OnEnable()
    {
        Player.OnPlayerDeath += DisablePlayerMovement;

    }

    private void OnDisable()
    {
        Player.OnPlayerDeath -= DisablePlayerMovement;

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
    public void DisablePlayerMovement()
    {
        animator.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
    }

    public void EnablePlayerMovement()
    {
        animator.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    public void SetPlayerSpeed(float newSpeed)
    {
        if (newSpeed >= 0) speed = newSpeed;
    }
    public void SetPlayerSpeedToDefault()
    {
        speed = defaultSpeed;
    }
    public void SetPlayerSpeedDefault(float newSpeed)
    {
        defaultSpeed = newSpeed;
    }
    public float GetPlayerSpeed()
    {
        return speed;
    }
}