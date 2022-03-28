using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 1f;

    Vector2 paddleToBallVector; 
    bool hasStarted = false;

    Rigidbody2D myRigidBody2D;
    AudioSource myAudioSource;

    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (hasStarted != true)  
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), 
                                            UnityEngine.Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            myAudioSource.Play();
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
