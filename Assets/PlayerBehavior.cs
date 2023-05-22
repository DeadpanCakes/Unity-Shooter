using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float maxSpeed;
    public GameObject bulletPrefab;
    public float secondsBetweenShots;

    float secondsSinceLastShot;

    // Start is called before the first frame update
    void Start()
    {
        secondsSinceLastShot = secondsBetweenShots;
        References.pc = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //WASD Movement
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Rigidbody playerBody = GetComponent<Rigidbody>();
        playerBody.velocity = inputVector * maxSpeed;

        Ray rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        playerPlane.Raycast(rayFromCameraToCursor, out float distanceFromCamera);
        Vector3 cursorPositon = rayFromCameraToCursor.GetPoint(distanceFromCamera);

        //Orient player on movement
        Vector3 orientation = cursorPositon;
        transform.LookAt(orientation);

        //Firing
        secondsSinceLastShot += Time.deltaTime;

        if (secondsSinceLastShot >= secondsBetweenShots && Input.GetButton("Fire1"))
        {
            Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
            secondsSinceLastShot = 0;
        }
    }
}
