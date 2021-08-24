using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class TPP_PlayerControl : MonoBehaviour
{
    CharacterController controller;
    Animator animator;
    Transform mainCamera;

    //player
   
    [Header("Player Movement ")]
    [Space(10)]
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float speed;
    [SerializeField] float targetSpeed;
    [SerializeField] float horizontalVelocity;
    [SerializeField] float verticalVelocity;
    [SerializeField] Vector3 moveInput;
    [SerializeField] Vector3 _moveInput;
    [SerializeField] float speedChangeRate;
    [SerializeField] Vector3 moveDir;



  [Header("Player Rotation")]
    [Space(10)]
    [SerializeField] float _rotationVelocity;
    [SerializeField] float _smoothTimeRotation;
    [SerializeField]  float angledamp;
    [SerializeField] float angle;
    [SerializeField] float angledistance;
    [SerializeField] float currentAngle;
   

   
    [Header("Player Grounded")]
    [Space(10)]
    [SerializeField] bool isGrounded;
    [SerializeField] float groundOffset;
    [Range(0,1)]
    [SerializeField] float distanceToGround;
    [SerializeField] Vector3 hitDirection;
    [SerializeField] LayerMask ground;

   
    [Header("PlayerJump")]
    [Space(10)]
    [SerializeField] float jumpHeight;
    [SerializeField] float gravity;


    [Header("Animator")]
    [Space(10)]
    int IDSpeedToHash;
    int IDGroundedToHash;
    int IDPickupToHash;
    [SerializeField] float animationBlend;
    [SerializeField] float smoothTimeAnimation;

   public static bool aimPressed { get; private set; }
   public static bool shootPressed { get; private set; }
   public static bool reloadPressed { get; private set; }
   public static bool movePlayer { get; private set; }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        mainCamera = Camera.main.transform;

        IDSpeedToHash = Animator.StringToHash("Speed");
        IDGroundedToHash = Animator.StringToHash("IsGrounded");
        IDPickupToHash = Animator.StringToHash("IsPickup");
    }

    private void Update()
    {
        Grounded();
        Movement();
        Aiming();
        Pickup();
        Jump();
        Shoot();
        Reload();
    }
    void Reload()
    {
        reloadPressed = Input.GetKeyDown(KeyCode.R);
    }
    void Shoot()
    {
        shootPressed = Input.GetKey(KeyCode.Mouse0);
        if (shootPressed) transform.rotation = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y, 0);
    }
    void Aiming()
    {
        aimPressed = Input.GetKey(KeyCode.Mouse1);
        if (aimPressed && InventoryPlayer.weaponEquip)
        {
            animator.SetLayerWeight(1, 1);
            transform.rotation = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y, 0);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
    }
    void Pickup()
    {
        bool pickupPressed = Input.GetKeyDown(KeyCode.E);
        if (pickupPressed) animator.SetTrigger(IDPickupToHash);
    }

  
    void Grounded()
    {
        //various way to check ground

        // default property character controller also have check ground
        // isGrounded = controller.isGrounded;

        // by physics raycast and bound y of controller
        isGrounded = Physics.Raycast(controller.bounds.center - Vector3.up* controller.bounds.extents.y, -transform.up,  groundOffset);

        //by Messages Character controller : OnControllerColliderHit

        animator.SetBool(IDGroundedToHash, isGrounded); 
    }
    void Movement()
    {
       

        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        bool runningPressed = Input.GetKey(KeyCode.LeftShift);

        targetSpeed = runningPressed ? runSpeed : walkSpeed;

        movePlayer = moveInput.magnitude > 0.1f ? true : false;

        if (moveInput.magnitude > 0.1f)
        {
           
            //get current angle and target angle
            currentAngle = transform.eulerAngles.y;
            angle = Mathf.Atan2(moveInput.x, moveInput.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;

            
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


            //get horizontal and vertical velocity by input
            verticalVelocity = controller.velocity.y;
           
            horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z).magnitude;
            //float offset = 0.1f;

          //various way to lerp speed 
            //by character controller velocity
           /* if (horizontalVelocity < targetSpeed - offset || horizontalVelocity > speed - offset)
            {
                speed = Mathf.Lerp(horizontalVelocity, targetSpeed, Time.deltaTime * speedChangeRate);
            }*/

            //by speed 
            speed = Mathf.Lerp(speed, targetSpeed, Time.deltaTime * speedChangeRate);
        }

        else
        {
            targetSpeed = 0f;
            speed = targetSpeed;
        }
    
        //set anim
        animationBlend = Mathf.Lerp(animationBlend, speed,Time.deltaTime * speedChangeRate);
        animator.SetFloat(IDSpeedToHash, animationBlend);

         moveDir = Quaternion.Euler(0,angle,0) * Vector3.forward;
        //set movement and jump
        controller.Move(moveDir.normalized * (speed * Time.deltaTime ) + new Vector3(0,verticalVelocity,0)* Time.deltaTime);
    }
    void Jump()
    {
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
       
        if(isGrounded)
        {
            if(jumpPressed)  
            {
                animator.SetTrigger("IsJump");
              
            }
           if (verticalVelocity <0f)verticalVelocity = -3f;
        }

         verticalVelocity += gravity * Time.deltaTime;
       

    }
    public void JumpEvent()
    {
         verticalVelocity += Mathf.Sqrt(jumpHeight * -3f * gravity);
    }








    private void OnAnimatorIK(int layerIndex)
    {
        #region FOOT IK HANDLER
        animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, animator.GetFloat("IKFootRightWeight"));
        animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, animator.GetFloat("IKFootRightWeight"));
        animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, animator.GetFloat("IKFootLeftWeight"));
        animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, animator.GetFloat("IKFootLeftWeight"));

        RaycastHit hit;
        Ray ray = new Ray(animator.GetIKPosition(AvatarIKGoal.RightFoot) + Vector3.up , Vector3.down);
        if(Physics.Raycast(ray,out hit, distanceToGround +1f,ground))
        {
         
            if(hit.transform.tag=="Walkable")
            {
              
                Vector3 footPosition = hit.point;
                footPosition.y += distanceToGround;
                animator.SetIKPosition(AvatarIKGoal.RightFoot, footPosition);
                animator.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.LookRotation(transform.forward,hit.normal));
                
            }
        }

        ray = new Ray(animator.GetIKPosition(AvatarIKGoal.LeftFoot) + Vector3.up, Vector3.down);
        if(Physics.Raycast(ray,out hit,distanceToGround +2f,ground))
        {
            if(hit.transform.tag=="Walkable")
            {
              
                Vector3 footPosition = hit.point;
                footPosition.y += distanceToGround;
                animator.SetIKPosition(AvatarIKGoal.LeftFoot, footPosition);
                animator.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.LookRotation(transform.forward,hit.normal));
            }
        }
        #endregion

        #region HAND IK HANDLER

       /* animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, animator.GetFloat("IKHandLeftIK"));
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, animator.GetFloat("IKHandLeftIK"));
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, animator.GetFloat("IKHandRightIK"));
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, animator.GetFloat("IKHandRightIK"));*/

        #endregion




    }

    private void OnDrawGizmos()
    {
        /* Gizmos.color = Color.red;
       //  Gizmos.DrawRay(controller.bounds.center - Vector3.up * controller.bounds.extents.y, -transform.up * 100f);
         Gizmos.DrawRay(animator.GetIKPosition(AvatarIKGoal.RightFoot), Vector3.down * 1f);*/
       
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //check ground
       // hitDirection = hit.moveDirection;
        // isGrounded = hitDirection == -Vector3.up ? true : false;
    }

}
