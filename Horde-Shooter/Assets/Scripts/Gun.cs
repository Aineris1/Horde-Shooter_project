using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    public GameObject GunFlash;


    public Transform muzzleFlashPosition;
    public AudioSource audioSource;


    public float maxDistance = 100;

    

    Camera cam;

    public void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;




        //called if user pressed mouse button 1 
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            //gun shot noise
            audioSource.Play();

            //gun muzzle flash
            ShootFlash();

            Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxDistance);


            if (hit.transform.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<Health>().Damage();
            }

        }

    }

        //muzzle flash function
        void ShootFlash()
        {
            //make a gun flash object for 0.1 seconds before destroying it 
            GameObject Flash = Instantiate(GunFlash, muzzleFlashPosition);
            Destroy(Flash, 0.1f);
        }






    }


