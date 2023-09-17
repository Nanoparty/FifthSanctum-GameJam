using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    public GameObject TextObject;
    public float DeleteTimer;

    private bool triggered;

    private void Start()
    {
        TextObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
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
