using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimalsPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI horsesPoints;
    [SerializeField] private TextMeshProUGUI chickensPoints;
    [SerializeField] private TextMeshProUGUI rostersPoints;
    [SerializeField] private TextMeshProUGUI chicksPoints;
    [SerializeField] private TextMeshProUGUI cowsPoints;
    public void UpdatePoints()
    {
        horsesPoints.text = "" + MainManager.instance.GetPlayerData().GetHorses();
        chickensPoints.text = "" + MainManager.instance.GetPlayerData().GetChickens();
        rostersPoints.text = "" + MainManager.instance.GetPlayerData().GetRoosters();
        chicksPoints.text = "" + MainManager.instance.GetPlayerData().GetChicks();
        cowsPoints.text = "" + MainManager.instance.GetPlayerData().GetCows();
    }
}
