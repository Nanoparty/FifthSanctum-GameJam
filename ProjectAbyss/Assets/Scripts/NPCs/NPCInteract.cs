using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCInteract : MonoBehaviour
{
    public string NextScene;

    public bool IsTouching;

    public GameObject InteractionText;

    private void Start()
    {
        InteractionText.SetActive(false);
    }

    private void Update()
    {
        if (IsTouching)
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                Data.PlayerLastPos = player.transform.position;
                SceneManager.LoadScene(NextScene, LoadSceneMode.Single);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsTouching = true;
            InteractionText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsTouching = false;
            InteractionText.SetActive(false);
        }
    }
}
