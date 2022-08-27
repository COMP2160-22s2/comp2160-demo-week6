using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordsOnPlay.Utils;

public class TurtleSink : MonoBehaviour
{
    [SerializeField] private Transform[] turtles = new Transform[3];
    [SerializeField] private Range upTimeRange;
    [SerializeField] private float downTime = 1;
    [SerializeField] private float sinkTime = 0.5f;

    private enum State { Up, Sinking, Down, Rising };
    private State state = State.Up;
    private float timer;
    private int groundLayer;

    void Start()
    {
        timer = upTimeRange.Random();
        groundLayer = LayerMask.NameToLayer("Ground");
    }

    void Update()
    {
        timer -= Time.deltaTime;

        switch (state) {
            case State.Up:
                if (timer <= 0)
                {
                    state = State.Sinking;
                    timer = sinkTime;
                }
                break;
                
            case State.Sinking:
                DoSink();

                if (timer <= 0)
                {
                    state = State.Down;
                    timer = downTime;
                }
                break;               

            case State.Down:
                DoDown();

                if (timer <= 0)
                {
                    state = State.Rising;
                    timer = sinkTime;
                }
                break;               

            case State.Rising:
                DoRise();

                if (timer <= 0)
                {
                    state = State.Up;
                    timer = upTimeRange.Random();
                }
                break;               
        }
    }

    private void DoSink()
    {
        ScaleTurtles(timer / sinkTime);
    }

    private void DoRise()
    {
        ScaleTurtles(1f - timer / sinkTime);
    }

    private void DoDown()
    {
        
    }


    private void ScaleTurtles(float size)
    {
        for (int i = 0; i < turtles.Length; i++)
        {
            turtles[i].localScale = size * Vector3.one;
        }
    }
}
