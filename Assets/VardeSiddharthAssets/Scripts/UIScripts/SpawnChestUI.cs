using UnityEngine.UI;
using UnityEngine;

public class SpawnChestUI : MonoBehaviour
{
    [SerializeField]
    Button spawnChestButton;

    // Start is called before the first frame update
    void Start()
    {
        spawnChestButton.onClick.AddListener(SpawnChestButtonPressed);
    }

    public void SpawnChestButtonPressed()
    {
        ServiceLocator.Instance.GetService<ChestSpawnerService>(TypesOfServices.ChestSpawner).GetChestController();
    }
}
