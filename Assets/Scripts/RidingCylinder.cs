using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidingCylinder : MonoBehaviour
{
    private bool _filled;
    private float _value;
    // Start is called before the first frame update




    public void IncrementCylinderVolume(float value)
    {
        _value += value;
        if (_value > 1) // if the cylinder is its biggest form
        {
            // Make the cylinder's scale = 1, and create another cylinder according how much bigger than 1.

            float leftValue = _value - 1; // for example 1.34 will give us 0.34
            int cylinderCount = PlayerController.Current.cylinders.Count;
            
            transform.localPosition = new Vector3(transform.localPosition.x,-0.5f * (cylinderCount - 1) - 0.25f ,transform.localPosition.z);
            transform.localScale = new Vector3(0.5f, transform.localScale.y, 0.5f); // calculated on Editor. 
            

            PlayerController.Current.CreateCylinder(leftValue);
            

        } else if (_value < 0)
        {
            //char should destroy the cylinder.
            PlayerController.Current.DestroyCylinder(this);
            
        }

        else // if lower than 1, and higher than 0... add cylinder scale.
        {
            // upgrade cylinder's scale. ( make it a little bigger.) 
            int cylinderCount = PlayerController.Current.cylinders.Count;
            
            transform.localPosition = new Vector3(transform.localPosition.x,-0.5f * (cylinderCount - 1) - 0.25f * _value ,transform.localPosition.z);
            transform.localScale = new Vector3(0.5f * _value, transform.localScale.y, 0.5f * _value); // calculated on Editor. 
            
            
        }
    }
}
