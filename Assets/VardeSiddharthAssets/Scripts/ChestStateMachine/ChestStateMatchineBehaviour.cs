using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ChestStateMatchineBehaviour : MonoBehaviour
{
    [SerializeField]
    Button chestButton;
    [SerializeField]
    TextMeshProUGUI chestStateText;

    ChestBaseState currentChestState = null;

    public void ChangeChestState(StatesOfChest stateOfChest, ChestController chestController)
    {
        if(currentChestState != null)
        {
            currentChestState.OnExitState();
            currentChestState = null;
        }

        switch(stateOfChest)
        {
            case StatesOfChest.Locked:
                currentChestState = new ChestLockedState(chestStateText, chestButton, chestController);
                break;
            case StatesOfChest.Unlocking:
                break;
            case StatesOfChest.Unlocked:
                break;
            case StatesOfChest.Collected:
                break;
        }
        currentChestState?.OnEnterState();
    }

    private void Update()
    {
        currentChestState?.Tick();
    }
}
