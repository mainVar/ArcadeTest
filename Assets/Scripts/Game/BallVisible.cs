using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVisible : MonoBehaviour
{
  
    public Ball ball;


    void Update()
    {
        Vector3 ballVelocity = ball.getVelocity();
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, ballVelocity).normalized;
        float rotationSpeed = ballVelocity.magnitude;
        transform.Rotate(rotationAxis, rotationSpeed, Space.World);
    }
}
