using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using System;

public class SwitchVCam : MonoBehaviour
{

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private int priorityBoost = 10;
    [SerializeField] private Canvas thirdPersonCanvas, aimCanvas;

    private CinemachineVirtualCamera vcam;
    private InputAction aimAction;

    private void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];
        Cursor.visible = false;
        aimCanvas.enabled = false;
    }

    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }

    private void StartAim()
    {
        vcam.Priority += priorityBoost;
        aimCanvas.enabled = true;
        thirdPersonCanvas.enabled = false;
    }

    private void CancelAim()
    {
        vcam.Priority -= priorityBoost;
        aimCanvas.enabled = false;
        thirdPersonCanvas.enabled = true;
    }

    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }
}
