using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour
{
    public int level;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.CompareTag("End")){
            if (collision.CompareTag("Player"))
            {
                SceneManager.LoadScene(level + 1);
            }
        }else if (this.CompareTag("Lava")||this.CompareTag("Spike"))
        {
            if (collision.CompareTag("Player"))
            {
                SceneManager.LoadScene(level);
            }
        }
    }
}
