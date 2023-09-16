using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhost : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public Animator anim;

    public Vector3 Direction = Vector3.forward;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

        anim.SetFloat("Vertical", 1);
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            rb.AddForce(speed * Direction * 10f, ForceMode.Force);
        }
    }
}
