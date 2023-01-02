using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{

    Vector3 targetPosition;
    public float speed;
    public LayerMask whatIsSolid;
    public int damage;
    public float distance;

    private void Start()
    {
        ///Find player position and make that the target.
        targetPosition = FindObjectOfType<PlayerController>().transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        Debug.Log(transform.position + "  " + targetPosition);
       ///Destroy projectile once the target has been reached
       if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y)
       {
        DestroyGameObject();
       }

       ///Destroy projectile on collision
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null){
            if (hitInfo.collider.CompareTag("Player")){
            Debug.Log("Player must take damage!");
            hitInfo.collider.GetComponent<Health>().TakeDamage(damage);
            }
            DestroyGameObject();
        }
    }

    void DestroyGameObject(){
        Destroy(gameObject);
    }    
}
