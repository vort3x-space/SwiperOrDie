using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    Vector3 previous;
    float velocity;
    float posX;
    float speed = 5f;
    void Awake()
    {
        //transform.position = new Vector3(0, 0, 0);
        posX = 0;
        cam = GameObject.FindGameObjectWithTag("Way");
    }

    bool going;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && posX < 5)
        {
            posX += 2.5f;
        }
        if (Input.GetKeyDown(KeyCode.A) && posX > -5)
        {
            posX -= 2.5f;
        }

        else if (!going)
        {
            GoOn(true);
            going = true;
        }

    }
    void FixedUpdate()
    {
        Move();
    }
    public GameObject boss, cam;
    float smooth = 2.5f;
    float tiltAngle = 25.0f;
    public void GoOn(bool i)
    {
        if (i)
        {
            cam.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            forwardSpeed = 1;
        }
        else
        {
            cam.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            forwardSpeed = 0;
        }
    }
    float forwardSpeed = 1f;
    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(posX, transform.position.y, transform.position.z + forwardSpeed), speed * Time.deltaTime);
    }
}
