using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Current;

    public float maxSpeed;
    private float _currentSpeed;
    public float limitX;
    public float xAxisSpeed;

    public GameObject ridingRollerPrefab;
    public List<RidingRoller> rollersList;

    void Start()
    {
        Current = this;
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


    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "AddRoller")
        {
            IncrementVolume(0.2f);
            Destroy(other.gameObject);

        }
    
    }

    public void IncrementVolume(float value)
    {
        if(rollersList.Count == 0)
        {
            if (value > 0)
            {
                CreateRoller(value);
            }
            else
            {

            }
        }
        else
        {
            rollersList[rollersList.Count - 1].IncrementRollerVolume(value);
        }

    }

    public void CreateRoller(float value)
    {
        RidingRoller createdRoller = Instantiate(ridingRollerPrefab, transform).GetComponent<RidingRoller>();
        rollersList.Add(createdRoller);
        createdRoller.IncrementRollerVolume(value);
    }

    public void DestroyRoller(RidingRoller roller)
    {
        rollersList.Remove(roller);
        Destroy(roller.gameObject);
    }
}
