using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float limitX;
    
    public float runningSpeed;
    public float xSpeed;
    private float _currentRunningSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _currentRunningSpeed = runningSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float newX = 0;
        float touchXDelta = 0;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)// If the user touches screen and that touched screen is moving 
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width; // Previous position && currrent position // screen.width
            
        }
        else if (Input.GetMouseButton(0)) // if mouse clicked
        {
            touchXDelta = Input.GetAxis("Mouse X"); // get info of X axis mouse
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime; //  how fast should go on X and moving on x axis
        newX = Mathf.Clamp(newX, -limitX, limitX);
        
        Vector3 newPosition = new Vector3(newX, transform.position.y,
            transform.position.z + _currentRunningSpeed * Time.deltaTime);
        transform.position = newPosition;
        
        
        
        
        
    }
}
