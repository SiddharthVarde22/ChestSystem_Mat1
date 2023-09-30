using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController
{
    ChestModel chestModel;
    ChestView chestView;
    public ChestController(ChestScriptableObject chestScriptableObject, ChestView chestView, Transform parent)
    {
        this.chestModel = new ChestModel(this, chestScriptableObject);
        this.chestView = GameObject.Instantiate<ChestView>(chestView, parent);
        chestView.SetChestController(this);
        chestView.EnableChest(chestScriptableObject.chestSprite);
    }
}
