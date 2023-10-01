using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueChestService : MonoBehaviour, IGameService
{
    [SerializeField]
    int maxNumberOfChestToEnque = 2;

    //Queue<ChestController> unlockingChestsQueue = new Queue<ChestController>();
    List<ChestController> unlockingChestsQueue = new List<ChestController>();

    public void RegisterService(TypesOfServices type, IGameService gameService)
    {
        ServiceLocator.Instance.Register<QueueChestService>(type, (QueueChestService)gameService);
    }

    private void OnEnable()
    {
        RegisterService(TypesOfServices.ChestQueue, this);
    }

    public void EnqueChest(ChestController chestController)
    {
        if(unlockingChestsQueue.Count <= 0)
        {
            //unlockingChestsQueue.Enqueue(chestController);
            unlockingChestsQueue.Add(chestController);
            chestController.ChangeState(StatesOfChest.Unlocking);
        }

        if(unlockingChestsQueue.Count < maxNumberOfChestToEnque)
        {
            //unlockingChestsQueue.Enqueue(chestController);
            unlockingChestsQueue.Add(chestController);
        }
        else
        {
            //show popup
        }
    }

    public void DequeChest()
    {
        ChestController unlockedChest = unlockingChestsQueue[0];
        unlockingChestsQueue.RemoveAt(0);
        unlockedChest.ChangeState(StatesOfChest.Unlocked);

        if (unlockingChestsQueue.Count > 0)
        {
            //unlockingChestsQueue.Peek()?.ChangeState(StatesOfChest.Unlocking);
            unlockingChestsQueue[0]?.ChangeState(StatesOfChest.Unlocking);
        }
    }

    public bool DequeChest(ChestController chestController)
    {
        ChestController unlockedChest = unlockingChestsQueue.Find(chestObject => chestObject.Equals(chestController));
        
        if(unlockedChest != null)
        {
            unlockedChest.ChangeState(StatesOfChest.Unlocked);
            unlockingChestsQueue.Remove(chestController);
            return true;
        }

        return false;
    }
}
