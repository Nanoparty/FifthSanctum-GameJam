using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;
    public Animator anim;

    public float playerHeight;
    public LayerMask GroundMask;
    public bool IsGrounded;
    public float GroundDrag;

    public float rotationSpeed;
    public float moveSpeed;
    public float jumpForce;
    public float jumpDelay;
    public float airMultiplier;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 inputDir;

    public bool CanJump;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        CanJump = true;
    }

    private void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, rotationSpeed * Time.deltaTime);
        }

        IsGrounded = Physics.Raycast(player.transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, GroundMask);

        Debug.DrawRay(player.transform.position, Vector3.down, Color.red, playerHeight * 0.5f + 0.2f);

        //if (IsGrounded)
        //{
        //    rb.drag = GroundDrag;
        //}
        //else
        //{
        //    rb.drag = 0f;
        //}

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedSpeed = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedSpeed.x, rb.velocity.y, limitedSpeed.z);
        }

        float moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));

        if (moveAmount < 0.05f)
        {
            //rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        UpdateAnimations();

        //if (CanJump && IsGrounded && Input.GetKey(KeyCode.Space))
        //{
        //    Jump();
        //    CanJump = false;
        //    Invoke("ResetJump", jumpDelay);
        //}
    }

    private void FixedUpdate()
    {
        if (inputDir != Vector3.zero)
        {
            if (IsGrounded)
                rb.AddForce(inputDir.normalized * moveSpeed * 10f, ForceMode.Force);
            else if (!IsGrounded)
                rb.AddForce(inputDir.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }


    }

    private void UpdateAnimations()
    {
        float moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));

        if (moveAmount < .1f)
        {
            moveAmount = 0;
        }
        else if (moveAmount >= 0.1f)
        {
            moveAmount = 1f;
        }

        anim.SetFloat("Vertical", moveAmount, 0.1f, Time.deltaTime);
        //anim.SetFloat("Horizontal", 0, 0.1f, Time.deltaTime);
    }

    private void Jump()
    {
        Debug.Log("Jumping");
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(player.transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        CanJump = true;
    }
}
