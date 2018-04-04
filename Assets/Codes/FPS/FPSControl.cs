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
    bool fire;
    public AudioSource audioshoot;
    public ParticleSystem muzzle;
    public ParticleSystem fragment;
    public GameObject holePrefab;
    float timergun = 0;
    // Use this for initialization
    void Start () {
        weaponstartpos = weapon.transform.localPosition;
        Cursor.lockState = CursorLockMode.Locked;
        fragment.transform.parent = null;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && timergun > 0.05f)
        {
            fire = true;
            timergun = 0;
        }
        else
        {
            fire = false;
            timergun += Time.deltaTime;
        }
        //fire = Input.GetButton("Fire1");
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
        if (fire)
        {
            GameObject hole = Instantiate(holePrefab, hit.point+ hit.normal*0.01f, Quaternion.LookRotation(-hit.normal));
            hole.transform.parent = hit.collider.transform;
            audioshoot.Play();
            muzzle.Emit(1);
            
            weapon.transform.localPosition -= Vector3.forward * 0.1f;
            if (Physics.Raycast(head.transform.position, head.transform.forward, out hit, 1000))
            {
                fragment.transform.position = hit.point;
                fragment.Play();
                Rigidbody rdb = hit.collider.gameObject.GetComponent<Rigidbody>();
                if (rdb)
                {
                    KillZombie(hit);
                    rdb.AddForceAtPosition(head.transform.forward * 1000, hit.point);
                }
               
            }
        }
    }

    void KillZombie(RaycastHit hit)
    {
        if (hit.collider.CompareTag("Zombie"))
        {
            hit.collider.gameObject.SendMessageUpwards("KillMe");
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
