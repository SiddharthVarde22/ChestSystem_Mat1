using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChestLockedState : ChestBaseState
{
    TextMeshProUGUI chestStateText;
    Button chestButton;
    ChestController chestController;
    public ChestLockedState(TextMeshProUGUI chestStateText, Button chestButton, ChestController chestController)
    {
        this.chestStateText = chestStateText;
        this.chestButton = chestButton;
        this.chestController = chestController;
    }

    public override void OnEnterState()
    {
        chestStateText.text = "Locked";
        chestButton.onClick.AddListener(OnChestButtonPressed);
    }

    public override void OnExitState()
    {
        chestButton.onClick.RemoveListener(OnChestButtonPressed);
    }

    public override void Tick()
    {
        //there is nothing to do here
    }

    public void OnChestButtonPressed()
    {
        //chest popup
        chestController.OnLockedChestSelected();
    }
}
