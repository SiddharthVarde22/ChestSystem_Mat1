using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController
{
    private ChestModel chestModel;
    private ChestView chestView;
    private ChestScriptableObject chestScriptableObject;

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
        ServiceLocator.Instance.GetService<EventsService>(TypesOfServices.Events).OnChestSelectedEventTrigger(timeToUnlock, this);
    }

    public void OnChestSelected(float remainingTimeToUnlock)
    {
        int gems = (int)(remainingTimeToUnlock / 60);
        ServiceLocator.Instance.GetService<EventsService>(TypesOfServices.Events).OnChestSelectedEventTrigger(gems, this);
    }

    public void OnUnlockChestPressed(ChestController chestController)
    {
        if(chestController != this)
        {
            return;
        }
        ServiceLocator.Instance.GetService<QueueChestService>(TypesOfServices.ChestQueue).EnqueChest(this);
    }

    public void OnChestUnlocked()
    {
        ServiceLocator.Instance.GetService<QueueChestService>(TypesOfServices.ChestQueue).DequeChest();
        ChangeState(StatesOfChest.Unlocked);
    }

    public void OnUnlockImmidiatePressed(int numberOfGemsToUse, ChestController chestController)
    {
        if(chestController != this)
        {
            return;
        }

        //use gems
        if(!ServiceLocator.Instance.GetService<GameResoursesService>(TypesOfServices.Resources).UseGems(numberOfGemsToUse))
        {
            return;
        }

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
        int gemsToAdd = Random.Range(chestModel.chestScriptable.minimumGems, chestModel.chestScriptable.maximumGems);
        int coinsToAdd = Random.Range(chestModel.chestScriptable.minimumCoins, chestModel.chestScriptable.maximumCoins);

        ServiceLocator.Instance.GetService<GameResoursesService>(TypesOfServices.Resources).AddGems(gemsToAdd);
        ServiceLocator.Instance.GetService<GameResoursesService>(TypesOfServices.Resources).AddCoins(coinsToAdd);
        //change state to collected
        ChangeState(StatesOfChest.Collected);
    }

    public float GetUnlockTime()
    {
        return chestModel.timeToUnlockInSeconds;
    }
}
