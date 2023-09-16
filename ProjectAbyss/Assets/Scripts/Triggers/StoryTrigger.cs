using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    public GameObject TextObject;
    public float DeleteTimer;

    private void Start()
    {
        TextObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TextObject.SetActive(true);
            Invoke("DeleteText", DeleteTimer);
        }
    }

    void DeleteText()
    {
        Destroy(TextObject.gameObject);
        Destroy(gameObject);
    }
}
