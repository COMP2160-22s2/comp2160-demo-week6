using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordsOnPlay.Utils;

public class Lane : MonoBehaviour
{
    [SerializeField] private Move movePrefab;
    [SerializeField] private float speed;
    [SerializeField] private int minDistance;
    [SerializeField] private int maxDistance;
    
    private System.Random rng = new System.Random();

    private float timer = 0;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Move move = Instantiate(movePrefab);
            move.transform.position = transform.position;
            move.speed = speed;            

            int distance = rng.Next(minDistance, maxDistance + 1);
            timer += distance / Mathf.Abs(speed);
        }
    }
}
