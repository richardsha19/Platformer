using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTop : MonoBehaviour
{
    public GameObject Enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            Destroy(Enemy);
        }
    }
}
