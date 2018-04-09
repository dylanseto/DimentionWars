﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(UnitHealth))]
public class UnitAnimationController : MonoBehaviour
{
    Animator anim;
    NavMeshAgent ag;
    UnitHealth h;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        ag = GetComponent<NavMeshAgent>();
        h = GetComponent<UnitHealth>();
    }

    private void Update()
    {
        if (h.isDead)
        {
            anim.SetBool("isDead", true);
        }
        else
        {
            if (ag.velocity != Vector3.zero)
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
        }

    }

    public void Shoot()
    {
        StartCoroutine(InternalShoot());
    }

    IEnumerator InternalShoot()
    {
        if (anim.GetBool("isFiring"))
        {
            yield break;
        }
        anim.SetBool("isFiring", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("isFiring", false);
    }
}
