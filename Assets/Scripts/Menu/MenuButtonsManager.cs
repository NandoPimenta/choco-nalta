using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MenuButtonsManager : MonoBehaviour
{
    public List<GameObject> buttons;

    [Header("Animation")]
    public float duration = .2f;
    public float delay = 0.5f;
    public Ease ease = Ease.OutBack;

    private void Awake()
    {
        foreach (var b in buttons)
        {
            b.SetActive(false);
            b.transform.localScale = Vector3.zero;
           
        }
        StartCoroutine(ShowButtonsWithDelay());
    }



    IEnumerator ShowButtonsWithDelay()
    {
        foreach(var b in buttons)
        {
            b.SetActive(true);
            b.transform.DOScale(1, duration).SetEase(ease);
            yield return new WaitForSeconds(delay);
        }
    }
}
