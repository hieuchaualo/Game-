using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

   // private Player player;
    Animator animator;
    float speed = 3f ;
    static bool isRight = true;
    Rigidbody2D rb;
    int count = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<Player>();
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("isDie", false);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRight)
        {
            rb.velocity = new Vector2(Vector2.right.x * 3f, rb.velocity.y);
        } 
        else
        {
            rb.velocity = new Vector2(Vector2.left.x * 3f, rb.velocity.y);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            Flip();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag.Equals("bullet")){
            count +=1;
            if(count == 3)
            {
                animator.SetBool("isDie", true);
                Destroy(collision.gameObject);
                Destroy(animator.gameObject, 0.5f);
            }
               
            
        }  
    }

    

    private void Flip()
    {   
        Vector3 curScale = gameObject.transform.localScale;
        curScale.x *= -1;
        gameObject.transform.localScale = curScale;

        isRight = !isRight;
    }
        
    
}
