using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startSpeed;
    public Rigidbody Rigbd;
    public GameObject ballHelper;

    private float force = 10;

   
    private float StartSpeed
    {
        get => startSpeed;
        set
        {
            if (startSpeed > 0f)
            {
                startSpeed = value;
            }

        }
    }

    public int PlayerCollisionCounter { get => playerCollisionCounter; set => playerCollisionCounter = value; }
    public int LoseCollisionCounter { get => loseCollisionCounter; set => loseCollisionCounter = value; }
    public float Force
    {
        get => force;

        set
        {
            if (force > 0f && force >= 100f)
            {
                force = value;
            }

        }
        
    }
    private int playerCollisionCounter = 0;
    private int loseCollisionCounter = 0;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Playertag")
        {
            // return;
            Debug.Log("Collided player");

            // GameObject ballHelper = GameObject.FindWithTag("BallHelperTag");
            playerCollisionCounter++;
            Rigbd.velocity = (Rigbd.position - ballHelper.transform.position).normalized * 10.0f;
        }



        if (collision.gameObject.tag == "LoseZone")
        {
            //return;
            loseCollisionCounter++;
            Debug.Log("LozeZone");
        }

    }

    public int CounterCollisionLoze()
    {
        return loseCollisionCounter;
    }
    public int CounterCollisionPlayer()
    {
        return playerCollisionCounter;
    }

    public Vector3 getVelocity()
    {
        return Rigbd.velocity;
    }

    void Update()
    {
        // Makes the reflected object appear opposite of the original object,


        Rigbd.velocity = Rigbd.velocity.normalized * Force;


        Rigbd.angularVelocity = Rigbd.velocity;
        // the second argument, upwards, defaults to Vector3.up
        //Quaternion rotation = Quaternion.LookRotation(Rigbd.velocity, Vector3.up);

        // Rotate our transform a step closer to the target's.

        Quaternion deltaRotation = Quaternion.Euler(Vector3.Cross(Vector3.up, Rigbd.velocity).normalized * Time.deltaTime);
        Rigbd.MoveRotation(deltaRotation);


        if (Input.GetButtonDown("Fire1"))  // Rigbd.Move 
        {
            Rigbd.isKinematic = false;

            Rigbd.AddForce(new Vector3(Random.Range(1f, 300f), 0, Random.Range(1f, 300f)));

        }
       
        if (Input.GetButtonDown("Fire2"))
        {
            force = force + 10f;
            Debug.Log("Add 10 force");
        }
    }
}

