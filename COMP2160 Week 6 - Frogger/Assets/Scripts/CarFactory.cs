using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordsOnPlay.Utils;

public class CarFactory : MonoBehaviour
{
    [SerializeField] private MoveCar carPrefab;
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
            MoveCar car = Instantiate(carPrefab);
            car.transform.position = transform.position;
            car.speed = speed;            

            timer += period.Random();
        }
    }
}
