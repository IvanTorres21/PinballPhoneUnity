using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bouncer"))
        {
            gameManager.score += 10;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.ballAmount--;
        Destroy(this.gameObject);
    }
}
