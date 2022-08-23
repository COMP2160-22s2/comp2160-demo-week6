using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordsOnPlay.Utils;

public class MoveCar : MonoBehaviour
{
    public float speed {get; set;} // m/s, +ve right, -ve left
    [SerializeField] private LayerMask roadLayer;

    void Update()
    {
        transform.Translate(speed * Vector3.right * Time.deltaTime);   
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (roadLayer.Contains(collider.gameObject))
        {
            Destroy(gameObject);
        }
    }
}
