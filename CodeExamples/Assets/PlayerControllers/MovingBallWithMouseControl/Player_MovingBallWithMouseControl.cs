// from: https://normcore.io/documentation/guides/creating-a-player-controller.html#creating-a-singleplayer-player-controller

using UnityEngine;

namespace lmnk
{
    public class Player_MovingBallWithMouseControl : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 4.0f;
    [SerializeField] private float movementSpeed = 6.0f;
    [SerializeField] private float mouseYRotationLimit = 15.0f;
    
    // Camera
    public Transform cameraTarget;
    private float _mouseLookX;
    private float _mouseLookY;
    
    // Physics
    private Vector3 _targetMovement;
    private Vector3 _movement;

    private bool _jumpThisFrame;
    private bool _jumping;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        // Set physiscs timestep to 60 Hz
        Time.fixedDeltaTime = 1.0f / 60.0f;
        
        // Store a reference to the rigidbody for easy access
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Rotate camera using mouse
        RotateCamera();
        // Use WASD input and the camera look direction to calculate the movement target
        CalculateTargetMovement();
        
        // Check if we should jump this frame
        ShouldJump();
    }

    private void FixedUpdate()
    {
        // Move player based on the input
        MovePlayer();
    }
    
    private void ShouldJump()
    {
     // Jump if the spacebar was pressed this frame and we're not already jumping
     if (Input.GetKeyDown(KeyCode.Space) && !_jumping)
         _jumpThisFrame = true;
    }
    
    private void RotateCamera()
    {
        // Get the latest mouse movement. Multiply by mouseSensitivity
        _mouseLookX += Input.GetAxis("Mouse X") * mouseSensitivity;
        _mouseLookY += Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        // Clamp how far you can look up / down
        while (_mouseLookY < -180.0f) _mouseLookY += 360.0f;
        while (_mouseLookY > 180.0f) _mouseLookY -= 360.0f;
        _mouseLookY = Mathf.Clamp(_mouseLookY, -mouseYRotationLimit, mouseYRotationLimit);
        
        cameraTarget.localRotation = Quaternion.Euler(-_mouseLookY, _mouseLookX, 0.0f);
    }
    
    private void CalculateTargetMovement()
    {
        Vector3 inputMovement = new Vector3();
        inputMovement.x = Input.GetAxisRaw( "Horizontal" ) * movementSpeed;
        inputMovement.z = Input.GetAxisRaw( "Vertical" )   * movementSpeed;
        
        // Get the direction the camera is looking parallel to the ground plane
        Vector3 cameraLookForwardVector = ProjectVectorOntoGroundPlane( cameraTarget.forward );
        Quaternion cameraLookForward = Quaternion.LookRotation( cameraLookForwardVector );
        
        _targetMovement = cameraLookForward * inputMovement;
    }

    private static Vector3 ProjectVectorOntoGroundPlane(Vector3 vector)
    {   
        // Given a forward vector, get a y-axis rotation that points in the same direction that's parallel to the ground plane
        Vector3 planeNormal = Vector3.up;
        Vector3.OrthoNormalize(ref planeNormal, ref vector);
        return vector;
    }

    private void MovePlayer()
    {
        // Start with the current velocity
        Vector3 velocity = _rigidbody.velocity;
        
        // Smoothly animate towards the target movement velocity
        _movement = Vector3.Lerp(_movement, _targetMovement, Time.fixedDeltaTime * 5.0f);
        velocity.x = _movement.x;
        velocity.z = _movement.z;
        
        // Jump
        if (_jumpThisFrame)
        {
            // Instantaneously set the vertical velocity to 6.0 m/s
            velocity.y = 6.0f;
            
            // mark the player as currently jumping and clear the jump input
            _jumping = true;
            _jumpThisFrame = false;
        }
        
        // reset jump after the apex (top of jump reached)
        // enables double jump
        // one could make a different code e.g. set to false when collided with ground
        if (_jumping && velocity.y < -0.1f)  
            _jumping = false;
        
        // Set the velocity on the rigidbody
        _rigidbody.velocity = velocity;
    }
}
}