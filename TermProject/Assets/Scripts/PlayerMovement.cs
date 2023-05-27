using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    private bool isJumping;
    private bool isGrounded;
    private bool isRolling = false;
    private bool isBlocking = false;

    private Transform cameraTransform;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float jumpHeight;

    [SerializeField]
    private float gravityMultiplier;

    [SerializeField]
    private float jumpButtonGracePeriod;

    [SerializeField]
    private float jumpHorizontalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GameObject.Find("Main Camera").transform;
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B) && isGrounded && !isRolling)
        {
            animator.SetBool("isBlocking", true);
            isBlocking = true;
        } else
        {
            animator.SetBool("isBlocking", false);
            isBlocking = false;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
        {
            inputMagnitude /= 2;
        }

        animator.SetFloat("Input Magnitude", inputMagnitude, 0.05f, Time.deltaTime);

        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        float gravity = Physics.gravity.y * gravityMultiplier;

        if (isJumping && ySpeed > 0 && !Input.GetButton("Jump"))
        {
            gravity *= 2;
        }

        ySpeed += gravity * Time.deltaTime;

        if (characterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if (Input.GetButtonDown("Jump") && !isRolling)
        {
            jumpButtonPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            animator.SetBool("isGrounded", true);
            isGrounded = true;
            animator.SetBool("isJumping", false);
            isJumping = false;
            animator.SetBool("isFalling", false);

            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = Mathf.Sqrt(jumpHeight * -3 * gravity);
                animator.SetBool("isJumping", true);
                isJumping = true;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
                animator.SetBool("isBlocking", false);
                isBlocking = false;
            }
        } else
        {
            characterController.stepOffset = 0;
            animator.SetBool("isGrounded", false);
            isGrounded = false;
            
            if ((isJumping && ySpeed < 0) || ySpeed < -5)
            {
                animator.SetBool("isFalling", true);
            }

        }

        if (movementDirection != Vector3.zero)
        {
            if ((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && !isRolling && isGrounded)
            {
                StartCoroutine(WaitOneSecondForRoll());
            }

            animator.SetBool("isWalking", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        } else
        {
            animator.SetBool("isWalking", false);
        }

        if (!isGrounded)
        {
            Vector3 velocity = movementDirection * inputMagnitude * jumpHorizontalSpeed;
            velocity.y = ySpeed;
            characterController.Move(velocity * Time.deltaTime);
        }
    }

    private void OnAnimatorMove()
    {
        if (isGrounded)
        {
            Vector3 velocity = animator.deltaPosition;
            velocity.y = ySpeed * Time.deltaTime;
            characterController.Move(velocity);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        } else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    private IEnumerator WaitOneSecondForRoll()
    {
        animator.SetBool("isRolling", true);
        isRolling = true;
        yield return new WaitForSeconds(1);
        animator.SetBool("isRolling", false);
        isRolling = false;
    }

    public bool GetIsJumping()
    {
        return isJumping;
    }

    public bool GetIsBlocking()
    {
        return isBlocking;
    }
}
