using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
   

    private void Update()
    {
        float horirontalInput = Input.GetAxis("Horizontal");
      
        transform.Rotate(Vector3.up, horirontalInput * rotationSpeed * Time.deltaTime);
       
    }
}
