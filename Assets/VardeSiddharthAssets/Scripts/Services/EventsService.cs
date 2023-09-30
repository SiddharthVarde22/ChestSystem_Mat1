
using UnityEngine;
using System;

public class EventsService : MonoBehaviour, IGameService
{
    public event Action<int> OnGemsChangedEvent;
    public event Action<int> OnCoinsChangedEvent;

    private void Start()
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
}
