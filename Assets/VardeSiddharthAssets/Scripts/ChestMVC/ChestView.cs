
using UnityEngine;
using UnityEngine.UI;

public class ChestView : MonoBehaviour
{
    ChestController chestController;

    [SerializeField]
    Image chestImage;

    [SerializeField]
    GameObject chestVisual;

    public void SetChestController(ChestController chestController)
    {
        this.chestController = chestController;
    }

    public void EnableChest(Sprite sprite)
    {
        this.chestImage.sprite = sprite;
        chestVisual.SetActive(true);
    }

    public void Disable()
    {
        chestVisual.SetActive(false);
    }
}
