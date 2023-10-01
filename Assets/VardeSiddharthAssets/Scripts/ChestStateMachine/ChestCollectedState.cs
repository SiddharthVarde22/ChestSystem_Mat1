
using UnityEngine;

public class ChestCollectedState : ChestBaseState
{
    ChestController chestController;
    public ChestCollectedState(ChestController chestController)
    {
        this.chestController = chestController;
    }

    public override void OnEnterState()
    {
        ReturnTheChestToPool();
    }

    public override void OnExitState()
    {
        //nothing to do
    }

    public override void Tick()
    {
        ///nothing to do
    }

    public void ReturnTheChestToPool()
    {
        ServiceLocator.Instance.GetService<ChestObjectPool>(TypesOfServices.ChestObjectPool).ReturnChestObject(chestController);
    }
}
