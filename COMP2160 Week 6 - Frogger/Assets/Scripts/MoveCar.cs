using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float speed = 2; // m/s, +ve right, -ve left

    void Update()
    {
        transform.Translate(speed * Vector3.right * Time.deltaTime);   
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
