using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public float distance;
    public LayerMask whatIsSolid;
    public float lifeTime;
    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile",lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);
        if (hitInfo.collider != null){
            if (hitInfo.collider.CompareTag("Enemy")){
                Debug.Log("Enemy must take damage!");
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            DestroyProjectile();
        }
        
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
