using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldManager : MonoBehaviour
{
    public Vector3 StartLocation;
    public Vector3 Phase1Location;
    public Vector3 Phase2Location;
    public Vector3 Phase3Location;

    public GameObject Barrier1;
    public GameObject Barrier2;

    public GameObject NPC1;
    public GameObject NPC2;
    public GameObject NPC3;

    private void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Data.GameStarted)
        {
            Player.transform.position = Data.PlayerLastPos;
        }
        else
        {
            Data.GameStarted = true;
        }

        if (Data.Phase == 1)
        {
            Destroy(Barrier1);
            Destroy(NPC1);
        }
        if (Data.Phase == 2)
        {
            Destroy(Barrier1);
            Destroy(Barrier2);
            Destroy(NPC1);
            Destroy(NPC2);
        }
        if (Data.Phase == 3)
        {
            Destroy(Barrier1);
            Destroy(Barrier2);
            Destroy(NPC1);
            Destroy(NPC2);
            Destroy(NPC3);
        }

        //switch (Data.Phase)
        //{
        //    case 0:
        //        Player.transform.position = StartLocation;
        //        break;
        //    case 1:
        //        Player.transform.position = Phase1Location;
        //        break;
        //    case 2:
        //        Player.transform.position = Phase2Location;
        //        break;
        //    case 3:
        //        Player.transform.position = Phase3Location;
        //        break;
        //}
    }
}
