using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DreamDoor : MonoBehaviour
{
    public string NextLevel;

    public int Phase;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Data.Phase = Phase;
            SceneManager.LoadScene(NextLevel, LoadSceneMode.Single);
        }
    }
}
