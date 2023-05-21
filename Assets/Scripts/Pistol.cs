using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject hitPrefab;
    public GameObject GunFlash;
    public GameObject SmokeEffect;

    public Transform muzzleFlashPosition;

    public float maxDistance = 100;

    public AudioSource audioSource;


    // Update is called once per frame
    void Update()
    {


        //called if user pressed mouse button 1 
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            audioSource.Play();

            ShootFlash();


            //Casts a lazer 
            var ray = new Ray(transform.position, transform.forward);


            if (Physics.Raycast(ray, out var hit, maxDistance))
            {
                //Create Smoke effect particles with random deviation
                var hitObjP = Instantiate(SmokeEffect, hit.point, Quaternion.Euler(0, 0, 0));
                hitObjP.transform.forward = hit.normal;
                hitObjP.transform.position += hit.normal * 0.02f;

            }

            //Create bullet hole prefabs with random deviation
            else
            {
                var hitObj = Instantiate(hitPrefab, hit.point, Quaternion.Euler(0, 0, 0));
                hitObj.transform.forward = hit.normal;
                hitObj.transform.position += hit.normal * 0.02f;

            }
        }

    }

        //gunflash function
        void ShootFlash()
        {
            //make a gun flash object for 0.1 seconds before destroying it 
            GameObject Flash = Instantiate(GunFlash, muzzleFlashPosition);
            Destroy(Flash, 0.1f);
        }






    }


