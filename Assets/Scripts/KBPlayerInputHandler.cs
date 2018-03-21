﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(Player))]
public class KBPlayerInputHandler : MonoBehaviour
{
    #region ABOUT
    /**
     * Handles player input from keyboard (or mouse)
     * Sets the parent camera (Main Camera) transform to a clicked object's position.
     * As such, the [CameraRig] object that this script is attached to will also have its position move.
     **/
    #endregion

    #region VARIABLES
    [Tooltip("Main Non-VR Game Camera")]
    public Camera cam;

    public Player player;

    [SerializeField] private MouseLook mouseLook;
    #endregion

    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        player = GetComponent<Player>();
    }

    private void Start()
    {
        mouseLook.Init(transform, cam.transform);
    }

    private void FixedUpdate()
    {
        mouseLook.UpdateCursorLock();
    }

    /// <summary>
    /// Listens for a mouse click and moves the Main Camera and [Camera Rig] to a raycast hit at a position to the click.
    /// </summary>
    void Update()
    {
        mouseLook.LookRotation(transform, cam.transform);
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            player.TeleportTo(ray);
        }
    }
}