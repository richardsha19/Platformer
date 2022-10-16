using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject player;
    public float speed = 15f;
    public LineRenderer LR;

    private void Update()
    {

        if (this.gameObject.transform.parent == player.transform) {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
            if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine(shoot());
            }
        }
    }

    IEnumerator shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);//sends out ray, also prevents nullinforerror

        if (hitInfo.rigidbody!= null && hitInfo.rigidbody.CompareTag("SEnemy"))
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                Debug.Log("Hit");
                enemy.TakeDamage(3);//can access this way
            }

            LR.SetPosition(0, firePoint.position);
            if (enemy != null)
            {
                LR.SetPosition(1, hitInfo.point);
            }
        }
        else
        {
            LR.SetPosition(0, firePoint.position);
            LR.SetPosition(1, firePoint.position + firePoint.right * 50);
        }

        LR.enabled = true;

        yield return 0;

        LR.enabled = false;

    }
}
