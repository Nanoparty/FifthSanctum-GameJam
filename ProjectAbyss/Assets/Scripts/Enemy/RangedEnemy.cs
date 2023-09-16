using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject Projectile;
    public Material AttackMaterial;
    public Material IdleMaterial;

    public MeshRenderer mr;

    public bool Attacking;

    public float AttackRange;
    public float AttackDelay;
    public float AttackRecharge;

    public GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
        mr = transform.GetComponentInChildren<MeshRenderer>();
    }

    private void Update()
    {
        Vector3 playerPos = Player.transform.position;
        playerPos.y += 1;
        if (!Attacking && Vector3.Distance(playerPos, transform.position) <= AttackRange)
        {
            Attacking = true;
            mr.material = AttackMaterial;
            Invoke("FireProjectile", AttackDelay);
        }
    }

    private void FireProjectile()
    {
        mr.material = IdleMaterial;
        GameObject projectile = Instantiate(Projectile, transform.position, Quaternion.identity);
        Invoke("AttackReset", AttackRecharge);
    }

    private void AttackReset()
    {
        Attacking = false;
    }
}
