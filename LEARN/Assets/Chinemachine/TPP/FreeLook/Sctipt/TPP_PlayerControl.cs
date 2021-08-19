using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class TPP_PlayerControl : MonoBehaviour
{
    CharacterController controller;
    Animator playerAnimControll;



    //player
   
    [Header("Player Movement")]
    [Space(10)]
    [SerializeField] float speed;
    [SerializeField] float horizontalVelocity;
    [SerializeField] float verticalVelocity;
    [SerializeField] float angledistance;
    [SerializeField] float _rotationVelocity;
    [SerializeField] float _smoothTimeRotation;
    [SerializeField]  float angledamp;
    [SerializeField] float angle;
    [SerializeField] float currentAngle;
    [SerializeField]  Vector3 moveInput;
    [SerializeField]  Vector3 _moveInput;

   
    [Header("Player Grounded")]
    [Space(10)]
    [SerializeField] bool isGrounded;
    [SerializeField] float groundOffset;
    [SerializeField] Vector3 hitDirection;

   
    [Header("PlayerJump")]
    [Space(10)]
    [SerializeField] float jumpHeight;
    [SerializeField] float gravity;
    


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerAnimControll = GetComponent<Animator>();
    }

    private void Update()
    {
        Grounded();
        Movement();
        Jump();
    }

    void Grounded()
    {
        //various way to check ground

        // default property character controller also have check ground
       // isGrounded = controller.isGrounded;

        // by physics raycast and bound y of controller
        isGrounded = Physics.Raycast(controller.bounds.center - Vector3.up* controller.bounds.extents.y, -transform.up,  groundOffset);

        //by Messages Character controller : OnControllerColliderHit
       
        
           
    }

   
    void Movement()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if (moveInput.magnitude > 0.1f)
        {
            //get current angle and target angle
            currentAngle = transform.eulerAngles.y;
            angle = Mathf.Atan2(moveInput.x, moveInput.z) * Mathf.Rad2Deg;

            
            angledamp = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref _rotationVelocity, _smoothTimeRotation);

            //set target rotation
            Quaternion targetRotation = Quaternion.Euler(0, angledamp, 0);
            Quaternion _targetRotation = Quaternion.Euler(0, angle, 0);

            // get angle distance betwenn current rotation and target rotation
            angledistance = Quaternion.Angle(transform.rotation, targetRotation);

            //various way to rotate
            //rotation by degress around axis
            //transform.rotation = Quaternion.AngleAxis(angledamp, Vector3.up);

            //rotation by euler
            transform.rotation = Quaternion.Euler(0f, angledamp, 0f);

            //rotation by forward direction 
            //transform.rotation =  Quaternion.LookRotation(moveInput);

            //rotation by quaternion
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _smoothTimeRotation);


            //get horizontal velocity by input

            verticalVelocity = controller.velocity.y;
          
            horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z).magnitude;
        }
        controller.Move(moveInput * (speed * Time.deltaTime )+ new Vector3(0, verticalVelocity, 0) * Time.deltaTime);
    }

    void Jump()
    {
        
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
       
        if(isGrounded)
        {
            if(jumpPressed)
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

        }

        if (verticalVelocity > 0.0f) verticalVelocity += gravity * Time.deltaTime;
        if (verticalVelocity <0.0f) verticalVelocity = 0.0f;

       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(controller.bounds.center - Vector3.up * controller.bounds.extents.y, -transform.up * 100f);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //check ground
       // hitDirection = hit.moveDirection;
        // isGrounded = hitDirection == -Vector3.up ? true : false;
    }

}
