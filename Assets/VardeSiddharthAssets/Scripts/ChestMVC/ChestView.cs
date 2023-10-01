
using UnityEngine;
using UnityEngine.UI;

public class ChestView : MonoBehaviour
{
    ChestController chestController;

    [SerializeField]
    Image chestImage;

    [SerializeField]
    GameObject chestVisual;
    [SerializeField]
    ChestStateMatchineBehaviour chestStateMachine;

    public void SetChestController(ChestController chestController)
    {
        this.chestController = chestController;
    }

    public void EnableChest(Sprite sprite)
    {
        this.chestImage.sprite = sprite;
        chestVisual.SetActive(true);
        ChangeChestState(StatesOfChest.Locked);
    }

    public void Disable()
    {
        chestVisual.SetActive(false);
    }

    public void ChangeChestState(StatesOfChest newstate)
    {
        chestStateMachine.ChangeChestState(newstate, this.chestController);
    }
}
