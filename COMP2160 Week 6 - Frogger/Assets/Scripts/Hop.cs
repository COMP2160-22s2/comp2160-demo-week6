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
    [SerializeField] private LayerMask groundLayer;

    private float hopTimer;
    private bool isHopping  = false;

    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        // set up starting position
        endPos = transform.localPosition;
        EndHop();
    }

    void Update()
    {        
        if (!IsOnScreen(transform.position))
        {
            // Die when leaving the screen
            Die("Left screen");
        }

        if (isHopping) {
            DoHop();
        }
        else 
        {
            Vector3 move = GetMove();
            if (move != Vector3.zero) 
            {
                StartHop(move);
            }            
        }
    }

    private Vector3 GetMove() 
    {
        Vector3 move = Vector3.zero;
        if (Input.GetButtonDown(InputAxes.Up))
        {
            move = Vector3.up;
        }
        else if (Input.GetButtonDown(InputAxes.Down))
        {       
            move = Vector3.down;
        }
        else if (Input.GetButtonDown(InputAxes.Left))
        {
            move = Vector3.left;
        }
        else if (Input.GetButtonDown(InputAxes.Right))
        {
            move = Vector3.right;
        }

        return move;
    }

    private bool IsOnScreen(Vector3 worldPos)
    {
        Collider2D dest = Physics2D.OverlapPoint(worldPos, screenLayer);
        return dest != null;
    }

    private void StartHop(Vector3 dir)
    {
        startPos = transform.localPosition;
        endPos = startPos + dir * hopDistance;

        Vector3 worldPos = transform.parent.TransformPoint(endPos);
        if (IsOnScreen(worldPos))
        {
            isHopping = true;
            hopTimer = 0;
        }
    }

    private void DoHop()
    {
        hopTimer += Time.deltaTime;
        if (hopTimer >= hopDuration)
        {
            EndHop();
        }
        else {
            float t = hopTimer / hopDuration;
            t = hopCurve.Evaluate(t);
            transform.localPosition = Vector3.Lerp(startPos, endPos, t);
        }

    }

    private Transform IsOnGround()
    {
        Collider2D dest = Physics2D.OverlapPoint(transform.position, groundLayer);
        return (dest == null ? null : dest.transform);        
    }

    private void EndHop()
    {
        transform.localPosition = endPos;
        isHopping = false;
        transform.parent = IsOnGround();

        if (transform.parent == null)
        {
            Die("Not on ground");
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isHopping && hurtLayer.Contains(collider.gameObject))
        {
            // Die when hit by a car
            Die($"hit {collider.gameObject.name}");
        }
    }

    private void Die(string reason)
    {
        Debug.Log($"Die: {reason}");
        Destroy(gameObject);
    }

}
