using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float PlatformSpeed = 0.1f;
    [SerializeField]
    private bool aiPlay;
    [SerializeField]
    private float offset;
    private GameObject ball;
    private float GetPlatformSpeed
    {
        get
        {
            return PlatformSpeed;
        }

        set
        {
            if (PlatformSpeed > 0f)
            {
                PlatformSpeed = value;
            }
            Debug.Log("Value a speed of ball incorrect (need natural value)");
        }
    }

    private Vector3 playerPos; //= new Vector3(0, 0.5f, -7);
    private void Start()
    {
        playerPos = GetComponent<Platform>().transform.position;
        if (aiPlay)
        {
            ball = FindObjectOfType<Ball>().gameObject;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!aiPlay)// for test
        {
            float xPositiot = transform.position.x + (Input.GetAxis("Mouse X") * GetPlatformSpeed);
            playerPos = new Vector3(Mathf.Clamp(xPositiot, -7.5f, 7.5f), playerPos.y, playerPos.z);
            transform.position = playerPos;
        }
        else
        {
            float xPositiot = transform.position.x;
            float ballPosOfsetMax = ball.transform.position.x + offset;
            float ballPosOfsetMin = ball.transform.position.x - offset;
            if (xPositiot >= ballPosOfsetMin && xPositiot <= ballPosOfsetMax)
            {

            }
            else
            {
                xPositiot = ball.transform.position.x * GetPlatformSpeed;
                playerPos = new Vector3(Mathf.Clamp(xPositiot, -7.5f, 7.5f), playerPos.y, playerPos.z);
                transform.position = playerPos ;
            }
            //else if (xPositiot < ball.transform.position.x)
            //{

            //        xPositiot = transform.position.x + GetPlatformSpeed;
            //        playerPos = new Vector3(Mathf.Clamp(xPositiot, -7.5f, 7.5f), playerPos.y, playerPos.z);
            //        transform.position = playerPos * Time.deltaTime; ;

            //}


        }


    }

}