using System;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.006674f;
    public static List<Gravity> planetlist;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (planetlist == null)
        {
            planetlist = new List<Gravity>();
        }
        
        planetlist.Add(this);
    }
    
    private void FixedUpdate()
    {
        //call Attract
        foreach (var planet in planetlist)
        {
            if (planet != this)
                Attract(planet);
        }
    }

    void Attract(Gravity other)
    {
        Rigidbody otherRb = other.rb;

        Vector3 direction = rb.position - otherRb.position;
        //get distance in meter    
        float distance = direction.magnitude;
        //calculate Gravity force
        float forceMagnitude = G * ((rb.mass * otherRb.mass) / Mathf.Pow(distance, 2));
        Vector3 finalForce = forceMagnitude * direction.normalized;
        
        otherRb.AddForce(finalForce);
    }
}
