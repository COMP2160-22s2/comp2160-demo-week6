using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordsOnPlay.Utils;

public class Move : MonoBehaviour
{
    public float speed {get; set;} // m/s, +ve right, -ve left
    [SerializeField] private LayerMask screenLayer;

    void Update()
    {
        transform.Translate(speed * Vector3.right * Time.deltaTime);   
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (screenLayer.Contains(collider.gameObject))
        {
            // just left the screen, destroy
            Destroy(gameObject);
        }
    }
}
