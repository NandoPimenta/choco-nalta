using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyHelper : MonoBehaviour
{

    public PlayerMoviment player;
    public void KillPlayer()
    {
        player.DestroyMe();
    }
}
