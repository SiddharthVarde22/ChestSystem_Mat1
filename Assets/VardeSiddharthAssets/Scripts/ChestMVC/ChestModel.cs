
public class ChestModel
{
    ChestController chestController;
    ChestScriptableObject chestScriptable;

    float timeToUnlock;

    public ChestModel(ChestController chestController, ChestScriptableObject chestScriptableObject)
    {
        this.chestController = chestController;
        ResetChestData(chestScriptableObject);
    }

    void ResetChestData(ChestScriptableObject chestScriptableObject)
    {
        this.chestScriptable = chestScriptableObject;
        timeToUnlock = chestScriptable.timeInMinutes * 60;
    }
}
