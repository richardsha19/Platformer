using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private bool jumpKeyDown = false;
    private float horizontalInput;

    private float health = 10;
    public int level;
    private bool EnemyBounceOff = false;

    private Rigidbody2D rigidbodyComponent; //saves time rather than calling it every time
    public bool isGrounded = false;
    [SerializeField] private Transform groundCheckTransform; //Can use transform to get camera to follow you
    [SerializeField] private LayerMask playerMask;
    public bool jumpBoost;

    public Transform holdPlace;

    static int coinCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        jumpBoost = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && isGrounded == true)
        {
            jumpKeyDown = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");//Axis named horizontal

    }

    //FixedUpdate is called once every physics update (100 times per second)
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector2(horizontalInput * 2, rigidbodyComponent.velocity.y);
        //Whenever in air, error message, nullreferenceexception cause there is no object interacting with it
        /*if (Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, playerMask).shapeCount == 0)
        {
            return;
        }*/

        Debug.Log(health);
        if (jumpKeyDown)
        {
            float jump = 5f;
            if (jumpBoost)
            {
                jump *= 2;
            }
            rigidbodyComponent.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            jumpKeyDown = false;
            jumpBoost = false;
            isGrounded = false;
        }

        if (EnemyBounceOff)
        {
            float jump = 2f;
            rigidbodyComponent.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            EnemyBounceOff = false;
        }

        if (health <= 0)
        {
            SceneManager.LoadScene(level);
            health = 10;
        }
        //not applying a force, applying it directly
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            coinCounter++;
        }

        if (other.gameObject.layer == 8)
        {
            jumpBoost = true;
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("SEnemy"))
        {
            health--;
            Debug.Log(health);
        }
        if (other.gameObject.CompareTag("Top"))
        {
            EnemyBounceOff = true;
        }
        if (other.gameObject.CompareTag("HealthPack"))
        {
            health += 2;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Gun"))
        {
            other.gameObject.transform.position = holdPlace.position;//picking up gun
            other.gameObject.transform.parent = this.gameObject.transform;
        }
    }

    public int GetCoinCounter()
    {
        return coinCounter;
    }
    
    public void setCoinCounter(int newValue)
    {
        coinCounter = newValue;
    }
}
