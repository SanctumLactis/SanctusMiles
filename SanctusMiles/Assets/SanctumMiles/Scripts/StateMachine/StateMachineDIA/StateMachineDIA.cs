using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StateMachineDIA
{
    [SerializeField] public string currentStateName;
    private StateDIA currentState;

    [SerializeField] private string[] currentSubStateNames;
    public SubStateDIA[] currentSubStates;

    private dynamic[] currentArgs;

    private Coroutine updateCoroutine;
    private Coroutine fixedUpdateCoroutine;

    public StateMachineDIA()
    {
        currentSubStates = new SubStateDIA[0];
    }

    // Switches the state if the state or state inputs are different from the previous one.
    public void SwitchState(StateDIA newState = null, dynamic[] args = null)
    {
        if (currentState != newState || currentArgs != args)
        {
            // Stop actions of the previous state
            if (currentState != null)
            {
                if (updateCoroutine != null)
                {
                    MonoHelper.instance.StopCoroutine(updateCoroutine);
                    MonoHelper.instance.StopCoroutine(fixedUpdateCoroutine);
                }
                currentState.OnExit();
            }

            currentState = newState;

            if (currentState != null)
            {
                currentStateName = newState.GetType().Name;
                currentState.OnEnter(args);
                updateCoroutine = MonoHelper.instance.StartCoroutine(_CallOnUpdates());
                fixedUpdateCoroutine = MonoHelper.instance.StartCoroutine(_CallOnFixedUpdates());
            }
        }
    }

    public void SwitchState(SubStateDIA newSubState = null, int layer = 0)
    {
        // Resize array if needed
        if (layer + 1 > currentSubStates.Length)
            ResizeSubStateArrays(layer + 1);

        currentSubStateNames[layer] = "null";

        // Check if the state is already running
        if (currentSubStates[layer] != newSubState)
        {
            // Stop actions of the previous sub state
            if (currentSubStates[layer] != null)
                currentSubStates[layer].OnExit();

            // Set new sub state and temporary name
            currentSubStates[layer] = newSubState;

            // If new state isn't null
            if (currentSubStates[layer] != null)
            {
                // Show sub state name in inspector
                currentSubStateNames[layer] = newSubState.GetType().Name;

                // Start sub state.
                currentSubStates[layer].OnEnter();
            }
        }
    }

    #region Coroutine Functions

    // Calls OnUpdate in current state and sub states.
    private IEnumerator _CallOnUpdates()
    {
        while (true)
        {
            if (currentState != null)
            {
                // Run main state
                currentState.OnUpdate();
            }

            // Run current sub state hierachy
            if (currentSubStates.Length != 0)
                foreach (SubStateDIA subState in currentSubStates)
                    if (subState != null)
                        subState.OnUpdate();

            yield return null;
        }
    }

    // Calls OnFixedUpdate in current state and sub states.
    private IEnumerator _CallOnFixedUpdates()
    {
        while (true)
        {
            if (currentState != null)
            {
                // Run main state
                currentState.OnFixedUpdate();
            }

            // Run current sub state hierachy
            if (currentSubStates.Length != 0)
                foreach (SubStateDIA subState in currentSubStates)
                    if (subState != null)
                        subState.OnFixedUpdate();

            yield return null;
        }
    }

    #endregion

    
    #region Private Helper 
    
    private void ResizeSubStateArrays(int size)
    {
        Array.Resize(ref currentSubStates, size);
        Array.Resize(ref currentSubStateNames, size);
    }

    #endregion


    #region Public Helper Functions

    public void KillStateMachine()
    {
        // Stop actions of the current state
        if (currentState != null)
        {
            if (updateCoroutine != null)
            {
                MonoHelper.instance.StopCoroutine(updateCoroutine);
            }
            if (fixedUpdateCoroutine != null)
            {
                MonoHelper.instance.StopCoroutine(fixedUpdateCoroutine);
            }
            currentState.OnExit();
        }

        currentState = null;
    }

    public StateDIA GetState() { return currentState; }

    public SubStateDIA GetSubState(int layer) { return currentSubStates[layer]; }

    public dynamic[] FormatArgs(dynamic arg) { return new dynamic[] { arg }; }

    public dynamic[] FormatArgs(dynamic[] args) { return args; }

    #endregion
}