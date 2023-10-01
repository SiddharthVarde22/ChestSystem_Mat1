using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawnerService : MonoBehaviour, IGameService
{
    [SerializeField]
    ChestView chestView;
    [SerializeField]
    ChestsList_ScriptableObject ChestsList_Scriptable;
    [SerializeField]
    Transform parentObjectOfChests;
    [SerializeField]
    int maxNumberOfChest = 4;

    ChestObjectPool chestObjectPool;

    public void RegisterService(TypesOfServices type, IGameService gameService)
    {
        ServiceLocator.Instance.Register<ChestSpawnerService>(type, (ChestSpawnerService)gameService);
    }

    void Start()
    {
        RegisterService(TypesOfServices.ChestSpawner, this);
        chestObjectPool = new ChestObjectPool();

        for(int i = 0; i < maxNumberOfChest; i++)
        {
            SpawnChestController();
        }
    }

    public void SpawnChestController()
    {
        ChestController chestController = new ChestController(
                ChestsList_Scriptable.chestScriptableList[Random.Range(0, ChestsList_Scriptable.chestScriptableList.Count)],
                chestView, parentObjectOfChests);

        ReturnChestController(chestController);
    }

    public void ReturnChestController(ChestController chestController)
    {
        chestObjectPool.ReturnChestObject(chestController);
        chestController.Disable();
    }

    public void GetChestController()
    {
        ChestController chestController = chestObjectPool.GetChest();

        if(chestController != null)
        {
            chestController.Enable(ChestsList_Scriptable.chestScriptableList[Random.Range(0, ChestsList_Scriptable.chestScriptableList.Count)]);
        }
        else
        {
            ServiceLocator.Instance.GetService<EventsService>(TypesOfServices.Events).OnAllChestSlotaAreFullEventTrigger();
        }
    }
}
