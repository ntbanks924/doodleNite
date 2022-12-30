using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    public float speed;
    public Transform target;
    public float minDistance;

    public GameObject projectile;
    public float timeBetweenShots;
    private float nextShotTime;

    public int aiType;

    public void TakeDamage(int damage) {
        health -= damage;
    }

    private void Update()
    {
        if (health <= 0) {
            Destroy(gameObject);
        }


        if (aiType == 1){
            ///Move away from character to maintain min distance
            if (Vector2.Distance(transform.position, target.position) < minDistance) 
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
            } 

            ///Pew pew pew
            if (Time.time > nextShotTime){
                Instantiate(projectile, transform.position, Quaternion.identity);
                nextShotTime = Time.time + timeBetweenShots;
            }
        }

        else if (aiType == 2) {
            ///chase player
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);                
        }
        

    }

}