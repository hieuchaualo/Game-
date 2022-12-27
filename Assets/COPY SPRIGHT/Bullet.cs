using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right *speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
               
            
        }  
    
}