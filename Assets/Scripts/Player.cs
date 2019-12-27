using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 4f;
    public float jumpPower = 10;
    public LayerMask groundLayer;
    public GameObject mainCamera;
    private Rigidbody2D rigidbody2D;
    private Animator anim;
    private bool isGrounded;
    private float elapsedTime;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        elapsedTime += Time.deltaTime;
        isGrounded = Physics2D.Linecast (
            transform.position + transform.up * 1,
            transform.position - transform.up * 0.05f,
            groundLayer
        );

        if(Input.GetKeyDown("space")) {
            if(isGrounded) {
                anim.SetBool("Dash", false);
                anim.SetTrigger("Jump");
                isGrounded = false;
                rigidbody2D.AddForce(Vector2.up * (jumpPower + 20*elapsedTime));
            }
        }

        float velY = rigidbody2D.velocity.y;
        bool isJumping = velY > 0.1f ? true : false;
        bool isFalling = velY < -0.1f ? true : false;
        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isFalling", isFalling);

        if(elapsedTime > 30.0) {
            SceneManager.LoadScene("Result");
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if(x != 0) {
            rigidbody2D.velocity = new Vector2(x * speed, rigidbody2D.velocity.y);
            Vector2 temp = transform.localScale;
            temp.x = x;
            transform.localScale = temp;
            anim.SetBool("Dash", true);
        }else {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            anim.SetBool("Dash", false);
        }
    }
}
