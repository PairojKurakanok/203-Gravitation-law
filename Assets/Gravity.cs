using System;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Attract(Gravity other)
    {
        Rigidbody otherRb = other.rb;

        Vector3 direction = rb.position - otherRb.position;
        //get distance in meter    
        float distance = direction.magnitude;
        //calculate Gravity force
        float forceMagnitude =
    }
}
