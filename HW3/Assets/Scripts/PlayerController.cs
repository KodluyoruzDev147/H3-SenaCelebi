using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    public float maxSpeed;
    private float _currentSpeed;
    public float limitX;
    public float xAxisSpeed;

    void Start()
    {
        _currentSpeed = maxSpeed;



    }

    
    void Update()
    {
        float tempX = 0;
        float touchX = 0;
        
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchX = Input.GetTouch(0).deltaPosition.x / Screen.width;

        }else if (Input.GetMouseButton(0))
        {
            touchX = Input.GetAxis("Mouse X");
        }

        tempX = transform.position.x + xAxisSpeed * touchX * Time.deltaTime;
        tempX = Mathf.Clamp(tempX, -limitX, limitX);

        Vector3 newPosition = new Vector3(tempX, transform.position.y, transform.position.z + _currentSpeed * Time.deltaTime);
        transform.position = newPosition;

        



        
       



    }
}
