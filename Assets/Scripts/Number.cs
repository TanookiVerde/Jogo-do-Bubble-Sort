using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Number : MonoBehaviour
{
    [SerializeField] private Image selector;
    [SerializeField] private Image circle;
    [SerializeField] private Image numberImage;
    [SerializeField] private Image numberFrame;
    [SerializeField] private List<Sprite> numberSprites;

    public int n;
    public bool selected;

    public void Initialize(int number)
    {
        n = number;
        numberImage.sprite = numberSprites[n];
        numberFrame.color = new Color(number / 8f, 1 - (number / 8f), 0.1f, 1);
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
