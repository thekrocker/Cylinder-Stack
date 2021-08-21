using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSpawner : MonoBehaviour
{
    public GameObject startReference, endReference;
    public BoxCollider hiddenPlatform;
    void Start()
    {
        Vector3 direction = endReference.transform.position - startReference.transform.position;
        float distance = direction.magnitude;
        direction = direction.normalized;
        hiddenPlatform.transform.forward = direction;
        hiddenPlatform.size = new Vector3(hiddenPlatform.size.x, hiddenPlatform.size.y, distance); // Collider's dimension is cool now. Time to locate.

        // WE need to put it in the middle of the reference. So we created a start ref, then made a formula to make it middle. 
        hiddenPlatform.transform.position = startReference.transform.position + (direction * distance / 2) + (new Vector3(0, -direction.z, direction.y) * hiddenPlatform.size.y / 2); 
        // it's a formula that if we change platform's height, so that hidden platform will also equalize with it. 
        // NOTE!!: If you want to change platform's weight, DO NOT forget to change "END" object with it.!
    }


}
