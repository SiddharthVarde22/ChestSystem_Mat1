
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListOfChests", menuName = "ScriptableObjects/ChestsList")]
public class ChestsList_ScriptableObject : ScriptableObject
{
    public List<ChestScriptableObject> chestScriptableList;
}
