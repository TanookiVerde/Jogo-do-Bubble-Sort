using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class LevelInitialNumber : MonoBehaviour
{
    [SerializeField] private CanvasGroup circle;
    [SerializeField] private TMP_Text value;

    public IEnumerator StartAnimation(int dif)
    {
        value.text = (dif+1).ToString();
        circle.DOFade(0, 0);
        circle.DOFade(1, 0.5f);
        circle.transform.DOScale(0, 0);
        circle.transform.DOScale(1, 0.5f);
        yield return new WaitForSeconds(1f);
        circle.DOFade(0, 0.25f);
        circle.transform.DOScale(0, 0.25f);
    }
}
