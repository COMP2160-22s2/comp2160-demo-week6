using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lilypad : MonoBehaviour
{
    [SerializeField] private Transform sleepingFrogPrefab;
    private bool occupied = false;
    public bool Occupied 
    {
        get {
            return occupied;
        }

        set {
            if (occupied)
            {
                Debug.LogError($"{gameObject.name} is already occupied");
            }

            occupied = value;
            if (value)
            {
                Transform sleepingFrog = Instantiate(sleepingFrogPrefab);
                sleepingFrog.parent = transform;
                sleepingFrog.localPosition = Vector3.zero;
            }
        }
    }
}
