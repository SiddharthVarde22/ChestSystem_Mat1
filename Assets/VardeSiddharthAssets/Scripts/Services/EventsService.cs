
using UnityEngine;
using System;

public class EventsService : MonoBehaviour, IGameService
{
    public event Action<int> OnGemsChangedEvent;
    public event Action<int> OnCoinsChangedEvent;
    public event Action OnAllSlotsAreFilledEvent;
    public event Action<int> OnChestSelectedEvent;
    public event Action unlockChestPressedEvent;
    public event Action<int> unlockImmidiatelyPressedEvent;

    private void OnEnable()
    {
        RegisterService(TypesOfServices.Events, this);
    }

    public void RegisterService(TypesOfServices type, IGameService gameService)
    {
        if(ServiceLocator.Instance == null)
        {
            Debug.Log("Instance is Null");
        }
        ServiceLocator.Instance.Register<EventsService>(type, (EventsService)gameService);
    }

    public void OnGemsChanged(int currentNumberOfGems)
    {
        OnGemsChangedEvent?.Invoke(currentNumberOfGems);
    }

    public void OnCoinsChanged(int currentNumberOfCoins)
    {
        OnCoinsChangedEvent?.Invoke(currentNumberOfCoins);
    }

    public void OnAllChestSlotaAreFullEventTrigger()
    {
        OnAllSlotsAreFilledEvent?.Invoke();
    }

    public void OnChestSelectedEventTrigger(int remainingTimeToUnlockInMinutes)
    {
        OnChestSelectedEvent?.Invoke(remainingTimeToUnlockInMinutes);
    }

    public void OnChestUnlockPressedEventTrigger()
    {
        unlockChestPressedEvent?.Invoke();
    }

    public void OnUnlockImmidiatelyPressedTrigger(int numberOfGemsToUse)
    {
        unlockImmidiatelyPressedEvent?.Invoke(numberOfGemsToUse);
    }
}
