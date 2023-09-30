
using UnityEngine;
using UnityEngine.UI;

public class ChestView : MonoBehaviour
{
    ChestController chestController;

    [SerializeField]
    Image chestImage;

    public void SetChestController(ChestController chestController)
    {
        this.chestController = chestController;
    }

    public void EnableChest(Sprite sprite)
    {
        this.chestImage.sprite = sprite;
    }
}
