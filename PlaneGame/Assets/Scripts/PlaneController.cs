using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick floatingJoystick;
    [SerializeField] private float speedOfPlane;
    [SerializeField] private float gravityForce = 5;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxRotationAngle = 45.0f;
    
    private Rigidbody rigidBody;
    private float rotationSpeedToDefaultPosition = 7; 



    private void Start()
    { 
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        PlaneMovementController();
        PlaneRotation();

    }
    

    private void PlaneMovementController()
    {
        rigidBody.AddForce(Physics.gravity * gravityForce, ForceMode.Acceleration);
        rigidBody.velocity = new Vector3(floatingJoystick.Horizontal * speedOfPlane, floatingJoystick.Vertical * speedOfPlane, 0f);
    }

    private void PlaneRotation()
    {
        if (floatingJoystick.Vertical != 0)
        {
            Vector3 inputDirection = new Vector3(0f, floatingJoystick.Vertical, 0f);
            Quaternion targetRotation = Quaternion.LookRotation(inputDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        }

        //default position if not moving 
        if (floatingJoystick.Vertical == 0)
        {
            Vector3 inputDirections = new Vector3(0f, floatingJoystick.Vertical, 0f);
            Quaternion targetRotations = Quaternion.LookRotation(inputDirections);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotations, rotationSpeedToDefaultPosition * Time.deltaTime);  
        }
    }
}
