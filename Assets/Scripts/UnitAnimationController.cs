﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class UnitAnimationController : MonoBehaviour
{
    Animator anim;
    NavMeshAgent ag;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        ag = GetComponent<NavMeshAgent>();
    }

    private void Update()
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