
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupPanelUI : MonoBehaviour
{
    [SerializeField]
    GameObject popupPanel;
    [SerializeField]
    TextMeshProUGUI popupText, unlockImmidiatelyText;
    [SerializeField]
    Button unlockButton, unlockImmidiateButton, closePopupButton;

    int requiredGemsToUnlock = 0;

    private void Start()
    {
        closePopupButton.onClick.AddListener(ClosePopupPanelPressed);
        ServiceLocator.Instance.GetService<EventsService>(TypesOfServices.Events).OnAllSlotsAreFilledEvent += OnChestSlotsFilled;
        ServiceLocator.Instance.GetService<EventsService>(TypesOfServices.Events).OnChestSelectedEvent += OnChestSelectedEventTriggered;
    }

    public void OnChestSlotsFilled()
    {
        popupText.text = "All the Slots are Occupied";
        unlockButton.gameObject.SetActive(false);
        unlockImmidiateButton.gameObject.SetActive(false);
        popupPanel.SetActive(true);
    }

    public void ClosePopupPanelPressed()
    {
        popupPanel.SetActive(false);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.GetService<EventsService>(TypesOfServices.Events).OnAllSlotsAreFilledEvent -= OnChestSlotsFilled;
        ServiceLocator.Instance.GetService<EventsService>(TypesOfServices.Events).OnChestSelectedEvent -= OnChestSelectedEventTriggered;
    }

    public void OnChestSelectedEventTriggered(int remainingTimeToUnlockInMinutes)
    {
        popupText.text = "Start Unlocking the Chest";
        unlockButton.gameObject.SetActive(true);
        unlockImmidiateButton.gameObject.SetActive(true);

        requiredGemsToUnlock = (remainingTimeToUnlockInMinutes + 1) * 3;
        unlockImmidiatelyText.text = "Unlock " + requiredGemsToUnlock + " Gems";
        popupPanel.SetActive(true);
    }
}
