using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordsOnPlay.Utils;

public class Lane : MonoBehaviour
{
    [SerializeField] private Move movePrefab;
    [SerializeField] private float speed;
    [SerializeField] private Range period;
    
    private float timer;

    void Start()
    {
        timer = period.Random();        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Move move = Instantiate(movePrefab);
            move.transform.position = transform.position;
            move.speed = speed;            

            timer += period.Random();
        }
    }
}
