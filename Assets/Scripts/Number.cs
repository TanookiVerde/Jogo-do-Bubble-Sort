using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Number : MonoBehaviour
{
    [SerializeField] private TMP_Text header;
    [SerializeField] private Image selector;
    [SerializeField] private Image circle;

    public int n;
    public bool selected;

    public void Initialize(int number)
    {
        n = number;
        header.text = number.ToString();
        GetComponent<Image>().color = new Color(number / 8f, 1 - (number / 8f), 0.1f, 1);
        Unselect();
    }
    public void Select()
    {
        selected = true;
        selector.enabled = true;
    }
    public void Unselect()
    {
        selected = false;
        selector.enabled = false;
    }
    public void Checked()
    {
        circle.DOFade(1, 0);
        circle.transform.DOScale(0, 0);
        circle.transform.DOScale(2f, 0.5f);
        circle.DOFade(0, 0.5f);
    }
}
