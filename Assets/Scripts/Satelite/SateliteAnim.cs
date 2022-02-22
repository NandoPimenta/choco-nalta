using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SateliteAnim : MonoBehaviour
{
    public Animator animator;

    string animatorFly = "canFly";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool(animatorFly, true);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool(animatorFly, false);
        }
    }
}
