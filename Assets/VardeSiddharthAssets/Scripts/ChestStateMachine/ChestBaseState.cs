
using UnityEngine;

public abstract class ChestBaseState
{
    public abstract void OnEnterState();
    public abstract void Tick();
    public abstract void OnExitState();
}
