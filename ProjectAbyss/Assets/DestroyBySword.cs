using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBySword : MonoBehaviour
{
    public GameObject Parent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            Destroy(Parent.gameObject);
        }
    }
}
