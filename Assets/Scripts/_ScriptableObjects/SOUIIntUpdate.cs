using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntUpdate : MonoBehaviour
{

    public SOInt soIntCoins;
    public SOInt soIntPlanets;
    public TextMeshProUGUI uiTextCoinsValue;
    public TextMeshProUGUI uiTextPlanetsValue;
    // Start is called before the first frame update
    void Start()
    {
        uiTextCoinsValue.text = "X " + soIntCoins.value.ToString();
        uiTextPlanetsValue.text = soIntPlanets.value.ToString() + "X ";
    }

    // Update is called once per frame
    void Update()
    {
        uiTextCoinsValue.text = "X " + soIntCoins.value.ToString();
        uiTextPlanetsValue.text = soIntPlanets.value.ToString() + "X ";

    }
}
