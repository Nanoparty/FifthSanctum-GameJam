using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public Transform Target;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void Update()
    {
        if (Target != null)
        {
            transform.LookAt(Target);
        }
    }
}
