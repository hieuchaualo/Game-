using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    Animator animator;
    bool canJump;
    Rigidbody2D rb;
    int force = 1;
    float jumpAmount = 7f;
    static bool isRight = false;
    private static bool existPlayer;
    public string startPoint;
    bool attacking = false;
    [SerializeField] GameObject gun;
    [SerializeField] Transform shootingPoint;
    [SerializeField] GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator.SetBool("isDie", false);   
        Flip();
        DontDestroyOnLoad(transform.gameObject);
        if (!existPlayer)
        {
            existPlayer = true;
            DontDestroyOnLoad(transform.gameObject);
            Debug.Log("Camera Loaded");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {




        var horizontalVal = Input.GetAxis("Horizontal");

        if (horizontalVal > 0 && !isRight)
        {
            Flip();
        }

        if (horizontalVal < 0 && isRight)
        {
            Flip();
        }
        if (horizontalVal != 0) {
            rb.velocity = new Vector2(horizontalVal * 10f, rb.velocity.y);
            animator.SetBool("isMoving", true);
            // GameManager.Instance.AudioRun();
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            //GameManager.Instance.AudioJump();
            rb.AddForce(Vector2.up * jumpAmount , ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.X) && !attacking)
        {
            attacking = true;
            StartCoroutine(AttackDelay());
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }

        // animator.SetBool("isRunning", false);
        // animator.SetBool("isMoving", false);
        // var xVal = Input.GetAxis("Horizontal");

        // if (Mathf.Abs(xVal) <0.01)
        // {
        //     animator.SetBool("isMoving", false);
        // }

        // if ( Mathf.Abs(xVal) > 0.01)
        // {
        //     animator.SetBool("isMoving", true);
        // }
       
        // //rb.velocity = new Vector3(xVal*speed, rb.velocity.y);

        // if (Input.GetKeyDown(KeyCode.Space) && canJump)
        // {
        //     // GameManager.Instance.AudioJump();
        //     float jumpVelocity = 10f;
        //     rb.velocity = Vector2.up *jumpVelocity;
        //     animator.SetBool("isJumping", true);
        // }

    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag.Equals("Ground")){
            canJump = true ;
        }

        if(collision.gameObject.tag.Equals("Space")){
            canJump = true ;
        }



        
        // }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            canJump = false ;
            animator.SetBool("isJumping", false);
        }
        
    }

    private void Flip()
    {
        Vector3 curScale = gameObject.transform.localScale;
        curScale.x *= -1;
        gameObject.transform.localScale = curScale;

        isRight = !isRight;
    }

    public void DeadAnim()
    {
        // if(collision.gameObject.tag.Equals("Bomb")){
        //     Debug.Log("hihi");
            animator.SetBool("isDie", true);
        
    }

    IEnumerator AttackDelay()
    {
        
            //GameManager.Instance.AudioJump();
            animator.ResetTrigger("Attack");
            animator.SetTrigger("Attack");
            animator.SetBool("isAttacking", true);
            yield return new WaitForSeconds(0.1f);
            gun.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            animator.SetBool("isAttacking", false);
            gun.SetActive(false);
            attacking = false;

    }


    // private void OnTriggerEnter2D(Collider2D other) {
    //     if (other.gameObject.tag.Equals("stone")) 
    //     {
    //         Destroy(other.gameObject, 0.5f);
    //         GameManager.Instance.Coin++;
    //         GameUI.Instance.SetTextCoin();
    //     }
    // }

    

}
    