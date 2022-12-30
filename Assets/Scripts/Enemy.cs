using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    public float speed;
    public Transform target;
    public float minDistance;

    public void TakeDamage(int damage) {
        health -= damage;
    }

    private void Update()
    {
        if (health <= 0) {
            Destroy(gameObject);
        }

        ///Stop moving towards character once min distance is reached
        if (Vector2.Distance(transform.position, target.position) > minDistance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        } else
        {
            /// Add attack code here for dealing damage to player.
        }
    }

}