using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{  public float rspeed =80f;
    Rigidbody movement;
    // Start is called before the first frame update
    void Start()
    {
        movement =GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse Y");
         transform.Rotate(Vector3.left, mouseX*rspeed);
            
           // Quaternion targetRotation = movement.rotation*
           // StartCoroutine(SmoothRotate(targetRotation));
        
    }
        
    }

