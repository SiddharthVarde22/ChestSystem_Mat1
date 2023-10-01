
using UnityEngine;
using TMPro;

public class GameResoursesUi : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI coinsText, gemsText;

    private void OnEnable()
    {
        ServiceLocator.Instance.GetService<EventsService>(TypesOfServices.Events).OnCoinsChangedEvent += ChangeCoinsText;
        ServiceLocator.Instance.GetService<EventsService>(TypesOfServices.Events).OnGemsChangedEvent += ChangeGemsText;
    }

    private void OnDisable()
    {
        ServiceLocator.Instance.GetService<EventsService>(TypesOfServices.Events).OnCoinsChangedEvent -= ChangeCoinsText;
        ServiceLocator.Instance.GetService<EventsService>(TypesOfServices.Events).OnGemsChangedEvent -= ChangeGemsText;
    }

    void ChangeCoinsText(int value)
    {
        coinsText.text = "Coins :- " + value;
    }

    void ChangeGemsText(int value)
    {
        gemsText.text = "Gems :- " + value;
    }
}
