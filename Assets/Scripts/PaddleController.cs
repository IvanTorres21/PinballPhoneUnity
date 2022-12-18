using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{

    [SerializeField] private GameObject leftPaddle;
    [SerializeField] private GameObject rightPaddle;

    [SerializeField] private GameObject ball;

    private bool leftPaddleActive = false;
    private bool rightPaddleActive = false;

    [SerializeField] private PhysicsMaterial2D paddleMaterial;

    void Update()
    {
        
        if(Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(touchPos);
            Debug.Log(worldPos);
            if (worldPos.x >= 0 && !rightPaddleActive)
            {
                rightPaddleActive = true;
                StartCoroutine(UsePaddle(rightPaddle));
            } else if (worldPos.x < 0 && !leftPaddleActive)
            {
                leftPaddleActive = true;
                StartCoroutine(UsePaddle(leftPaddle));
            }
        }
    }


    private IEnumerator UsePaddle(GameObject paddle)
    {
        paddle.transform.GetChild(0).GetComponent<PolygonCollider2D>().sharedMaterial = paddleMaterial;
        paddle.GetComponent<Animator>().Play("Move");
        yield return new WaitForSeconds(0.2f);
        paddle.GetComponent<Animator>().Play("New State");
        paddle.transform.GetChild(0).GetComponent<PolygonCollider2D>().sharedMaterial = null;
        if (paddle == leftPaddle)
            leftPaddleActive = false;
        else
            rightPaddleActive = false;
    }
}
