﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Purpose: Handles players movement logic through the character controller.<para/>
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    // Sets speed and gravity
    public float speed = 6.0F;
    public float gravity = 20.0F;

    public CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        // Store reference to attached component
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Character is on ground (built-in functionality of Character Controller)
        if (controller.isGrounded)
        {
            // Use input up and down for direction, multiplied by speed
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        // Apply gravity manually
        moveDirection.y -= gravity * Time.deltaTime;
        // Move Character Controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}