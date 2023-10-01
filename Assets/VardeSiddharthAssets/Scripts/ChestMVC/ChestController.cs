using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController
{
    ChestModel chestModel;
    ChestView chestView;
    ChestScriptableObject chestScriptableObject;

    public ChestController(ChestScriptableObject chestScriptableObject, ChestView chestView, Transform parent)
    {
        this.chestModel = new ChestModel(this, chestScriptableObject);
        this.chestView = GameObject.Instantiate<ChestView>(chestView, parent);
        chestView.SetChestController(this);
        this.chestScriptableObject = chestScriptableObject;
    }

    public void Disable()
    {
        chestView.Disable();
    }

    public void Enable(ChestScriptableObject chestScriptableObject)
    {
        this.chestScriptableObject = chestScriptableObject;
        chestModel.ResetChestData(this.chestScriptableObject);
        chestView.SetChestController(this);
        chestView.EnableChest(this.chestScriptableObject.chestSprite);
    }

    public void ChangeState(StatesOfChest newState)
    {
        chestView.ChangeChestState(newState);
    }

    public void OnLockedChestSelected()
    {
        int timeToUnlock = (int)(chestModel.timeToUnlockInSeconds / 60);
        ServiceLocator.Instance.GetService<EventsService>(TypesOfServices.Events).OnChestSelectedEventTrigger(timeToUnlock);
    }
}
