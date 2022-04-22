using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateDIA
{
    public dynamic main;
    protected StateDIA(dynamic main) { this.main = main; }

    public virtual void OnEnter(dynamic[] args) { }

    public virtual void OnUpdate() { }

    public virtual void OnFixedUpdate() { }

    public virtual void OnExit() { }
}
