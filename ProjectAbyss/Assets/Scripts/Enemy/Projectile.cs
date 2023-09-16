using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;

    public GameObject Player;
    public Vector3 Direction;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
        Vector3 playerPos = Player.transform.position;
        playerPos.y += 1;
        Direction = (playerPos - transform.position).normalized;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(Speed * Direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hits Player");
            Destroy(gameObject);
        }
        if (other.CompareTag("Shield"))
        {
            Debug.Log("Hit Shield");
            Destroy(gameObject);
        }
    }
}
