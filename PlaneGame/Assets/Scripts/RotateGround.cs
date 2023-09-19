using UnityEngine;

public class RotateGround : MonoBehaviour
{


    [SerializeField] private float rotationSpeed = 30.0f; 

    private void Update()
    { 
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

   
}
