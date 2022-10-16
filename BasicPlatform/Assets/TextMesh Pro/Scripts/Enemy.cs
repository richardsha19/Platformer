using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float distance;
    public BoxCollider2D Box1;

    public int Ehealth = 9;

    private bool movingRight = true;

    public Transform groundDetection;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance); //transform.position, 
        if (groundInfo.collider == false|| groundInfo.collider == true && groundInfo.transform.CompareTag("Lava"))
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0); //angle at which the enemy is moving
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

        if(Ehealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        Ehealth -= damage;
    }//must apply a material to line object for the line to render for some reason
}
