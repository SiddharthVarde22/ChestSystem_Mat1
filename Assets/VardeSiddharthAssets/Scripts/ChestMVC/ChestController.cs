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
        ServiceLocator.Instance.GetService<EventsService>(TypesOfServices.Events).unlockChestPressedEvent -= OnUnlockChestPressed;
        ServiceLocator.Instance.GetService<EventsService>(TypesOfServices.Events).unlockImmidiatelyPressedEvent -= OnUnlockImmidiatePressed;
        chestView.Disable();
    }

    public void Enable(ChestScriptableObject chestScriptableObject)
    {
        this.chestScriptableObject = chestScriptableObject;
        chestModel.ResetChestData(this.chestScriptableObject);
        chestView.SetChestController(this);
        chestView.EnableChest(this.chestScriptableObject.chestSprite);
        ServiceLocator.Instance.GetService<EventsService>(TypesOfServices.Events).unlockChestPressedEvent += OnUnlockChestPressed;
        ServiceLocator.Instance.GetService<EventsService>(TypesOfServices.Events).unlockImmidiatelyPressedEvent += OnUnlockImmidiatePressed;
    }

    public void ChangeState(StatesOfChest newState)
    {
        chestView.ChangeChestState(newState);
    }

    public void OnChestSelected()
    {
        int timeToUnlock = (int)(chestModel.timeToUnlockInSeconds / 60);
        ServiceLocator.Instance.GetService<EventsService>(TypesOfServices.Events).OnChestSelectedEventTrigger(timeToUnlock);
    }

    public void OnUnlockChestPressed()
    {
        ServiceLocator.Instance.GetService<QueueChestService>(TypesOfServices.ChestQueue).EnqueChest(this);
    }

    public void OnChestUnlocked()
    {
        ServiceLocator.Instance.GetService<QueueChestService>(TypesOfServices.ChestQueue).DequeChest();
    }

    public void OnUnlockImmidiatePressed(int numberOfGemsToUse)
    {
        Debug.Log("Unlocking immidiately " + numberOfGemsToUse);
        //use gems
        //unqueue chest if queued
        //else change state

        if(!ServiceLocator.Instance.GetService<QueueChestService>(TypesOfServices.ChestQueue).DequeChest(this))
        {
            ChangeState(StatesOfChest.Unlocked);
        }
    }

    public void OnChestCollected()
    {
        //collect reward
        //change state to collected
    }

    public float GetUnlockTime()
    {
        return chestModel.timeToUnlockInSeconds;
    }
}
