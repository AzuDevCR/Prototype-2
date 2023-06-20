using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float xRange = 20;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -xRange) {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange) {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space)) {
            //Debug.Log("Phew, Phew, Phew");
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        sprintfunction();
        
    }

    void sprintfunction() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            speed = 40.0f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            speed = 20.0f;
        }
    }
}
