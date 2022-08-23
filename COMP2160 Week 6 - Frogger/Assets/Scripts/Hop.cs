using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordsOnPlay.Utils;

public class Hop : MonoBehaviour
{
    [SerializeField] private AnimationCurve hopCurve;
    [SerializeField] private float hopDuration = 0.5f; // seconds
    [SerializeField] private float hopDistance = 1;
    [SerializeField] private LayerMask screenLayer;
    [SerializeField] private LayerMask hurtLayer;

    private float hopTimer;
    private bool isHopping  = false;

    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        
    }

    void Update()
    {        
        if (isHopping) {
            DoHop();
        }
        else 
        {
            if (Input.GetButtonDown(InputAxes.Up))
            {
                StartHop(Vector3.up);
            }
            else if (Input.GetButtonDown(InputAxes.Down))
            {
                StartHop(Vector3.down);
            }
            else if (Input.GetButtonDown(InputAxes.Left))
            {
                StartHop(Vector3.left);
            }
            else if (Input.GetButtonDown(InputAxes.Right))
            {
                StartHop(Vector3.right);
            }
        }
    }

    private void StartHop(Vector3 dir)
    {
        isHopping = true;
        startPos = transform.localPosition;
        endPos = transform.localPosition + dir * hopDistance;
        hopTimer = 0;
    }

    private void DoHop()
    {
        hopTimer += Time.deltaTime;
        if (hopTimer > hopDuration)
        {
            EndHop();
        }
        else {
            float t = hopTimer / hopDuration;
            t = hopCurve.Evaluate(t);
            transform.localPosition = Vector3.Lerp(startPos, endPos, t);
        }

    }

    private void EndHop()
    {
        transform.localPosition = endPos;
        isHopping = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (hurtLayer.Contains(collider.gameObject))
        {
            // Die when hit by a car
            Die();
        }
    }



    void OnTriggerExit2D(Collider2D collider)
    {
        if (screenLayer.Contains(collider.gameObject))
        {
            // Die when leaving the screen
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
