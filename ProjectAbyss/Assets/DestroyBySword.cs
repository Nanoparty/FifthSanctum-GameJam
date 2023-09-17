using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBySword : MonoBehaviour
{
    public GameObject Parent;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            audioSource.Play();
            Destroy(Parent.gameObject);
        }
    }
}
