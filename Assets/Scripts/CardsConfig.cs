using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/CardsConfig", fileName = "CardsConfig")]
public class CardsConfig : ScriptableObject
{
    public List<CardStats> CardStatsList;
}