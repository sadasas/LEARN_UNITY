using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class TPPControll : MonoBehaviour
{
    [Header("Player Move")]
    [SerializeField] float moveSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] float speedChangeRate;
    [Range(0.0f,0.3f)]
    [SerializeField] float smoothTimeRotation;
   

    [Header("Player Jump and Gravity")]
    [SerializeField] float gravity;
    [SerializeField] float jumpTimout;
    [SerializeField] float jumpHeight;

    [Header("Player Grounded")]
    [SerializeField] float groundedOffset;
    [SerializeField] bool Grounded;
    [SerializeField] float groundedRadius;
    public LayerMask groundLayers;
    public bool freeFall;
    public float _freeFallTimoutDelta;
    public float freeFallTimout;

    //player
    float _verticalVelocity;
    float _speed;
    float targetSpeed;
    float _animationBlend;
    float _targetRotation;
    float _rotationVelocity;
    float _jumpTimoutDelta;
     bool readyJump=false;

    bool sprintPressed;
    float currentHorizontalSpeed;

   
   
    

    
    
    

 

    //animationIDs
    int IDSpeedToHash;
    int IDJumpToHash;
    int IDFreeFallToHash;
    int IDGrounded;


    //get component
    CharacterController characterController;
    Animator animator;
    Transform mainCamera;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        mainCamera = Camera.main.transform;

        IDSpeedToHash = Animator.StringToHash("Speed");
        IDJumpToHash = Animator.StringToHash("Jump");
        IDFreeFallToHash = Animator.StringToHash("FreeFall");
        IDGrounded = Animator.StringToHash("Grounded");
    }

    private void Update()
    {
       CheckGrounded();
        Movement();
        Jump();
       


    }

    void Movement()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        sprintPressed = Input.GetKey(KeyCode.LeftShift);

        targetSpeed = sprintPressed ? sprintSpeed : moveSpeed;

        if (moveInput.magnitude <= 0f) targetSpeed = 0f;

        currentHorizontalSpeed = new Vector3(characterController.velocity.x, 0.0f, characterController.velocity.z).magnitude;

        float speedOffset = 0.1f;
        if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
        {
            _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * 1f, Time.deltaTime * speedChangeRate);
            _speed = Mathf.Round(_speed * 1000f) / 1000f;
        }
        else
        {
            _speed = targetSpeed;
        }
    
        _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * speedChangeRate);
        animator.SetFloat(IDSpeedToHash, _animationBlend);


        moveInput.Normalize();
        if (moveInput.magnitude>0.1f)
        {
            
            _targetRotation = Mathf.Atan2(moveInput.x, moveInput.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity, smoothTimeRotation);

            transform.rotation = Quaternion.Euler(0, angle, 0);

        }
        Vector3 moveDir = Quaternion.Euler(0f, _targetRotation, 0f) * Vector3.forward;
        Vector3 targetJump = new Vector3(0, _verticalVelocity, 0);
        characterController.Move(moveDir.normalized * (_speed * Time.deltaTime) + targetJump * Time.deltaTime );
    


    }

    void Jump()
    {
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
        if (Grounded)
        {
           
            if(_jumpTimoutDelta > 0.0f)
            {
                readyJump = false;
                _jumpTimoutDelta -= Time.deltaTime;
            }
            else
            {
                animator.SetBool(IDJumpToHash, jumpPressed);
                readyJump = true;
            }
        }

        else
        {
            _jumpTimoutDelta = jumpTimout;
            _verticalVelocity += -9.8f * Time.deltaTime;
        }


    }

    public void JumpEvent()
    {
        if(readyJump)
        _verticalVelocity += Mathf.Sqrt(jumpHeight * -3.0f * gravity);

    }

    void CheckGrounded()
    {

        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z);

        Grounded = Physics.CheckSphere(spherePosition, groundedRadius, groundLayers);

        if (Grounded)
        {
            if (_verticalVelocity < 0.0f)
            {
                _verticalVelocity = -2f;
            }
            _freeFallTimoutDelta = freeFallTimout;

            freeFall = false;

        }
        else
        {

            if (_freeFallTimoutDelta > 0.0f)
            {
                _freeFallTimoutDelta -= Time.deltaTime;
            }

            if (_freeFallTimoutDelta <= 0f)
            {
                freeFall = true;
                
            }
        }

        
         animator.SetBool(IDGrounded, Grounded);

         animator.SetBool(IDFreeFallToHash,freeFall);



    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3( transform.position.x, transform.position.y - groundedOffset, transform.position.z),groundedRadius);
    }
}
