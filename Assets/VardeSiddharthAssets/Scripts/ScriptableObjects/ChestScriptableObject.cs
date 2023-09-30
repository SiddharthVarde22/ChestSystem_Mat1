
using UnityEngine;

[CreateAssetMenu(fileName = "ChestScriptable", menuName = "ScriptableObjects/Chest")]
public class ChestScriptableObject : ScriptableObject
{
    public TypesOfChest chestType;
    public int minimumCoins, maximumCoins;
    public int minimumGems, maximumGems;
    public float timeInMinutes;

    public Sprite chestSprite;
}
