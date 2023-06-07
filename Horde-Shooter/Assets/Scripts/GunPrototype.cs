using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunPrototype : MonoBehaviour
{
    public Transform spawnPoint;
    public float distance = 10f;

    public GameObject muzzle;
    public GameObject impact;

    public AudioSource audioSource;


    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
            Shoot();
    }

    //Method to Shoot

    public void Shoot()
    {
        RaycastHit hit;
        RaycastHit hit_2;
        RaycastHit hit_3;
        RaycastHit hit_4;

        ShootFlash();

        audioSource.Play();

        

                            //point of origin      //direction     //hitinfoLocation //max distance the ray can travel
        if (Physics.Raycast(cam.transform.position,cam.transform.forward + new Vector3(0.1f, 0f, 0f), out hit, distance))
        {


            GameObject Impact = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(Impact, 0.1f);

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            //Apply damage 
            if(hit.transform.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<Health>().Damage();
            }
            
            

        }

        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, 0f, 0.1f), out hit_2, distance))
        {
            GameObject Impact = Instantiate(impact, hit_2.point, Quaternion.LookRotation(hit_2.normal));
            Destroy(Impact, 0.1f);

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

           if (hit_2.transform.CompareTag("Enemy"))
            {
                hit_2.transform.GetComponent<Health>().Damage();
           }

        }

       if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, 0.1f, 0f), out hit_3, distance))
       {
            GameObject Impact = Instantiate(impact, hit_3.point, Quaternion.LookRotation(hit_3.normal));
            Destroy(Impact, 0.1f);


            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit_3.distance, Color.yellow);

            if (hit_3.transform.CompareTag("Enemy"))
            {
                hit_3.transform.GetComponent<Health>().Damage();
            }
        }

       if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, 0.1f, 0f), out hit_4, distance))
        {
            GameObject Impact = Instantiate(impact, hit_4.point, Quaternion.LookRotation(hit_4.normal));
            Destroy(Impact, 0.1f);

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit_4.distance, Color.yellow);

            if (hit_4.transform.CompareTag("Enemy"))
           {
               hit_4.transform.GetComponent<Health>().Damage();
           }
        }

    }

    //gunflash function
    void ShootFlash()
    {
        //make a gun flash object for 0.1 seconds before destroying it 
        GameObject Flash = Instantiate(muzzle, spawnPoint);
        Destroy(Flash, 0.1f);
    }

   
}

   




