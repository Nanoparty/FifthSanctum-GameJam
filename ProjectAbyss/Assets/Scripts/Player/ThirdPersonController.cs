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
    public GameObject Shield;
    public GameObject Sword;

    public float playerHeight;
    public LayerMask GroundMask;
    public bool IsGrounded;
    public float GroundDrag;

    public float rotationSpeed;
    public float moveSpeed;
    public float jumpForce;
    public float jumpDelay;
    public float airMultiplier;
    public float shieldDuration;
    public float shieldDelay;
    public bool canUseShield;
    public float swordSpeed;
    public float swordDelay;
    public bool canUseSword;
    public bool swingingSword;
    public float swordStartingRotation;
    public float SwordDuration;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 inputDir;

    public bool CanJump;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        CanJump = true;
        canUseShield = true;

        Shield.SetActive(false);
        Sword.SetActive(false);
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

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedSpeed = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedSpeed.x, rb.velocity.y, limitedSpeed.z);
        }

        UpdateAnimations();

        CastShield();
        CastSword();
    }

    private void FixedUpdate()
    {
        if (inputDir != Vector3.zero)
        {
                rb.AddForce(inputDir.normalized * moveSpeed * 10f, ForceMode.Force);
        }
    }

    private void CastShield()
    {
        if (canUseShield && Input.GetKeyDown(KeyCode.Alpha1))
        {
            Shield.SetActive(true);
            canUseShield = false;
            Invoke("DisableShield", shieldDuration);
        }
    }

    private void DisableShield()
    {
        Shield.SetActive(false);
        Invoke("EnableShield", shieldDelay);
    }

    private void CastSword()
    {
        if (canUseShield && Input.GetKeyDown(KeyCode.Alpha2))
        {
            Sword.SetActive(true);
            canUseSword = false;
            Invoke("DisableSword", SwordDuration);
        }
    }

    private void DisableSword()
    {
        Sword.SetActive(false);
        Invoke("EnableSword", swordDelay);
    }

    private void EnableShield()
    {
        canUseShield = true;
    }

    private void EnableSword()
    {
        canUseSword = true;
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
    }
}
