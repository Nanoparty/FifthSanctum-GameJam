using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDown : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        Vector3 newPos = transform.position;
        newPos.y -= speed * Time.deltaTime;
        transform.position = newPos;
    }
}
