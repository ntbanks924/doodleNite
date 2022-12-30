using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour{
    
    //offset in case weapon sprite is facing up
    public float offset;
    
    public GameObject projectile;
    public Transform shotPoint;

    //shot frequency
    private float timeBtwShots;
    public float startTimeBtwShots;
    
    void Update()
    {
       // Handles the weapon hand rotation to point toward cursor
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots <= 0) {
            if (Input.GetMouseButton(0)) 
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else {
            timeBtwShots -= Time.deltaTime;
        }



    }
}
