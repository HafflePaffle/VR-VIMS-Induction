using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ControlManager : MonoBehaviour
{
    public InputActionProperty rightIndexButton;
    public UnityEvent rightIndexAction;
    public InputActionProperty leftIndexButton;
    public UnityEvent leftIndexAction;
    public InputActionProperty rightGripButton;
    public UnityEvent rightGripAction;
    public InputActionProperty leftGripButton;
    public UnityEvent leftGripAction;
    public InputActionProperty rightAButton;
    public UnityEvent rightAAction;
    public InputActionProperty rightBButton;
    public UnityEvent rightBAction;
    public InputActionProperty leftXButton;
    public UnityEvent leftXAction;
    public InputActionProperty leftYButton;
    public UnityEvent leftYAction;
    public InputActionProperty rightStickClick;
    public UnityEvent rightStickClickAction;
    public InputActionProperty leftStickClick;
    public UnityEvent leftStickClickAction;

    private void OnEnable()
    {
        EnableAllActions();
    }

    private void OnDisable()
    {
        DisableAllActions();
    }

    private void Update()
    {
        CheckInput(rightIndexButton, rightIndexAction);
        CheckInput(leftIndexButton, leftIndexAction);
        CheckInput(rightGripButton, rightGripAction);
        CheckInput(leftGripButton, leftGripAction);
        CheckInput(rightAButton, rightAAction);
        CheckInput(rightBButton, rightBAction);
        CheckInput(leftXButton, leftXAction);
        CheckInput(leftYButton, leftYAction);
        CheckInput(rightStickClick, rightStickClickAction);
        CheckInput(leftStickClick, leftStickClickAction);
    }

    private void CheckInput(InputActionProperty inputActionProp, UnityEvent unityEvent)
    {
        if (inputActionProp.action != null && inputActionProp.action.ReadValue<float>() == 1f)
        {
            Debug.Log("Invoking event for: " + unityEvent);
            unityEvent.Invoke();
        }
    }

    private void EnableAllActions()
    {
        rightIndexButton.action.Enable();
        leftIndexButton.action.Enable();
        rightGripButton.action.Enable();
        leftGripButton.action.Enable();
        rightAButton.action.Enable();
        rightBButton.action.Enable();
        leftXButton.action.Enable();
        leftYButton.action.Enable();
        rightStickClick.action.Enable();
        leftStickClick.action.Enable();
    }

    private void DisableAllActions()
    {
        rightIndexButton.action.Disable();
        leftIndexButton.action.Disable();
        rightGripButton.action.Disable();
        leftGripButton.action.Disable();
        rightAButton.action.Disable();
        rightBButton.action.Disable();
        leftXButton.action.Disable();
        leftYButton.action.Disable();
        rightStickClick.action.Disable();
        leftStickClick.action.Disable();
    }
}
