using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldManager : MonoBehaviour
{
    public Vector3 StartLocation;
    public Vector3 Phase1Location;
    public Vector3 Phase2Location;
    public Vector3 Phase3Location;

    private void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        switch (Data.Phase)
        {
            case 0:
                Player.transform.position = StartLocation;
                break;
            case 1:
                Player.transform.position = Phase1Location;
                break;
            case 2:
                Player.transform.position = Phase2Location;
                break;
            case 3:
                Player.transform.position = Phase3Location;
                break;
        }
    }
}
