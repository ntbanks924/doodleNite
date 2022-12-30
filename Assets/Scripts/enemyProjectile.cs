using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{

    Vector3 targetPosition;
    public float speed;

    private void Start()
    {
        targetPosition = FindObjectOfType<PlayerController>().transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        Debug.Log(transform.position + "  " + targetPosition);
       ///Destroy projectile once the target has been hit
       if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y)
       {
        DestroyGameObject();
       }

    }

    void DestroyGameObject(){
        Destroy(gameObject);
    }    
}
