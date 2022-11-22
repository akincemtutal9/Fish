using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 playerVelocity;
    [SerializeField] private int speed;
    [SerializeField] private int rotateSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float jumpHeight;
    [SerializeField] private DynamicJoystick dynamicJoystick;
    private CharacterController controller;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float horizontalInput = dynamicJoystick.Horizontal;
        float verticalInput = dynamicJoystick.Vertical;

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        //Vector3 moveDirection = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        moveDirection.Normalize();
       
        controller.Move(moveDirection * (speed * Time.deltaTime));
        
        if(moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}