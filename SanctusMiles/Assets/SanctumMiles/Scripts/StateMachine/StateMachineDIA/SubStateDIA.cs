using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SubStateDIA
{
    public dynamic main, parentState;
    protected SubStateDIA(dynamic main, dynamic parentState)
    {
        this.main = main;
        this.parentState = parentState;
    }

    public virtual void OnEnter() { }

    public virtual void OnUpdate() { }

    public virtual void OnFixedUpdate() { }

    public virtual void OnExit() { }
}
