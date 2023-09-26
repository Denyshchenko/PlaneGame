using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private float _speedOfPlane;
    [SerializeField] private float _gravityForce = 5;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _rotationSpeedToDefaultPosition = 7; 


     
    private Rigidbody _rigidBody;

    
    


    private void Start()
    { 
        _rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
        PlaneMovementController();
        PlaneRotation();
    }

    private void PlaneMovementController()
    {
       
        _rigidBody.AddForce(Physics.gravity * _gravityForce, ForceMode.Acceleration);
        _rigidBody.velocity = new Vector3(_floatingJoystick.Horizontal * _speedOfPlane, _floatingJoystick.Vertical  * _speedOfPlane, 0f);
        

        
    }

    private void PlaneRotation()
    {   
        if (_floatingJoystick.Vertical != 0)
            Rotation(_rotationSpeed);

        //default rotation if not moving 
        if (_floatingJoystick.Vertical == 0)
            Rotation(_rotationSpeedToDefaultPosition);        
    }


    private void Rotation(float rotationSpeed)
    {
        Vector3 inputDirection = new Vector3(0f, _floatingJoystick.Vertical, 0f);
        Quaternion targetRotation = Quaternion.LookRotation(inputDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
  
}
