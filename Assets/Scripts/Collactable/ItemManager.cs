using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;


    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;

    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;

       // UIInGameManager.UpdateTextCoins(coins.ToString());
    }


}
