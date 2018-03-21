using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSControl : MonoBehaviour {
    public CharacterController charcontroller;
    public Vector3 movement;
    public GameObject head;
    public GameObject weapon;
    Vector3 weaponstartpos;
    float headangle;
    int mask = 260;//100000100
    public LineRenderer laser;
   // Use this for initialization
    void Start () {
        weaponstartpos = weapon.transform.localPosition;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
        Control();
        WeaponControl();
        

    }
    /// <summary>
    /// controle da mira da arma,coice,forca da bala e laser
    /// </summary>
    void WeaponControl()
    {
        weapon.transform.localPosition = Vector3.Lerp(weapon.transform.localPosition, weaponstartpos, Time.deltaTime * 10);
        RaycastHit hit;
        if (Physics.Raycast(head.transform.position, head.transform.forward, out hit, 1000))
        {
            laser.SetPosition(1, weapon.transform.InverseTransformPoint(hit.point));
        }

        if (Input.GetButtonDown("Fire1"))
        {
            weapon.transform.localPosition -= Vector3.forward * 0.1f;
            if (Physics.Raycast(head.transform.position, head.transform.forward, out hit, 1000, ~mask))
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(head.transform.forward * 1000, hit.point);
               
            }
        }
    }

    void Control()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), -1, Input.GetAxis("Vertical"));
        if (Input.GetButton("Jump"))
        {
            movement += Vector3.up * 2;
        }


        charcontroller.Move(transform.TransformDirection(movement) * 10 * Time.deltaTime);
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0)); 


        headangle -= Input.GetAxis("Mouse Y");
        headangle = Mathf.Clamp(headangle, -50, 50);
        head.transform.localRotation = Quaternion.Euler(headangle, 0, 0);
    }
}
