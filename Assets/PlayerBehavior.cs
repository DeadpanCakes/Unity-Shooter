using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float maxSpeed;
    public List<WeaponBehavior> weapons = new List<WeaponBehavior>();
    public int currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        References.pc = gameObject;
        currentWeapon = 0;
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
        if (Input.GetButton("Fire1"))
        {
            //Trigger Fire On Weapon
            weapons[currentWeapon].Fire(cursorPositon);
        }

        //Cycle Weapons
        if (Input.GetButton("Fire2"))
        {
            if (currentWeapon < weapons.Count)
            {
                currentWeapon++;
            }
            else
            {
                currentWeapon = 0;
            }
        }
    }
}
