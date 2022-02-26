using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core.Singleton;

public class UIInGameManager : Singleton<UIInGameManager>
{

    public TextMeshProUGUI textCoins;

    public static void UpdateTextCoins(string s)
    {
        Instance.textCoins.SetText("X " + s);

    }
}
