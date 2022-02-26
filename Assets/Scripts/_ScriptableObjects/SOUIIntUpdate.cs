using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntUpdate : MonoBehaviour
{

    public SOInt soInt;
    public TextMeshProUGUI uiTextvalue;
    // Start is called before the first frame update
    void Start()
    {
        uiTextvalue.text = "X " + soInt.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        uiTextvalue.text = "X " + soInt.value.ToString();

    }
}
