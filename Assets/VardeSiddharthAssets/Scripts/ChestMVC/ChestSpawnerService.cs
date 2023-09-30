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

    public void RegisterService(TypesOfServices type, IGameService gameService)
    {
        ServiceLocator.Instance.Register<ChestSpawnerService>(type, (ChestSpawnerService)gameService);
    }

    void Start()
    {
        RegisterService(TypesOfServices.ChestSpawner, this);

        for(int i = 0; i < 1; i++)
        {
            SpawnChestController();
        }
    }

    public void SpawnChestController()
    {
        ChestController chestController = new ChestController(
                ChestsList_Scriptable.chestScriptableList[Random.Range(0, ChestsList_Scriptable.chestScriptableList.Count)],
                chestView, parentObjectOfChests);
    }
}
