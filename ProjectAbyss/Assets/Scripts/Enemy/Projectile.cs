using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
        Vector3 playerPos = Player.transform.position;
        playerPos.y += 1;
        Direction = (playerPos - transform.position).normalized;
        Vector3 curPos = transform.position;
        curPos += Direction * Speed * Time.deltaTime;
        transform.position = curPos;
    }

    private void FixedUpdate()
    {
        //rb.AddForce(Speed * Direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hits Player");
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
        if (other.CompareTag("Shield"))
        {
            Debug.Log("Hit Shield");
            Destroy(gameObject);
        }
    }
}
