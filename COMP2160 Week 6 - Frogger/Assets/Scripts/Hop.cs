using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hop : MonoBehaviour
{
    public AnimationCurve hopCurve;
    public float hopDuration = 0.5; // seconds
    public float hopDistance = 1;
    private float hopTimer;
    private bool isHopping  = false;

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
            t = hopCurve.Eval(t);

            transform.localPosition = Vector3.Lerp(startPos, endPos);
        }

    }

    private void EndHop()
    {
        transfrom.localPosition = endPos;
        isHopping = false;
    }
}
