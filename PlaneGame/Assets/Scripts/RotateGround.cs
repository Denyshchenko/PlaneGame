using UnityEngine;

public class RotateGround : MonoBehaviour
{


    [SerializeField] private float _rotationSpeed = 30.0f; 

    private void Update()
    { 
        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
    }

   
}
