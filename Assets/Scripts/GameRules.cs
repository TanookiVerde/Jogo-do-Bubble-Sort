using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameRules : MonoBehaviour
{
    public const int NUMBER_SIZE = 150;

    [SerializeField] private int numberQuantity;
    [SerializeField] private GameObject numberPrefab;
    [SerializeField] private Transform root;

    [SerializeField] private int selectedNumber;

    [HideInInspector] public List<Number> numbers;

    public void GenerateLevel(int difficult, bool random = true)
    {
        numbers = new List<Number>();
        numberQuantity = GetNumberQuantity(difficult);

        var randNumbers = GenerateListInt(numberQuantity);
        for (int i = 0; i < numberQuantity; i++)
        {
            int rand = !random ? randNumbers[i] : Random.Range(0, numberQuantity);
            var go = Instantiate(numberPrefab, root);
            go.name = "Number " + rand;
            go.GetComponent<Number>().Initialize(rand);
            var pos = new Vector3(i * NUMBER_SIZE + 640 - NUMBER_SIZE * numberQuantity * 0.5f + NUMBER_SIZE * 0.5f, NUMBER_SIZE * 0.8f, 0);
            go.GetComponent<RectTransform>().anchoredPosition = pos;
            go.GetComponent<RectTransform>().DOScale(0.6f + 0.6f * rand/8f, 0);
            numbers.Add(go.GetComponent<Number>());
        }
    }
    public void UpdateSelector(int newSelectedNumber, bool reset = false)
    {
        numbers[selectedNumber].Unselect();
        numbers[selectedNumber + 1].Unselect();
        numbers[newSelectedNumber].Select();
        numbers[newSelectedNumber + 1].Select();
        selectedNumber = newSelectedNumber;
    }
    public void MoveLeft()
    {
        UpdateSelector(Mathf.Clamp(selectedNumber - 1, 0, numberQuantity - 1));
    }
    public void MoveRight()
    {
        UpdateSelector(Mathf.Clamp(selectedNumber + 1, 0, numberQuantity - 2));
    }
    public void Swap()
    {
        numbers[selectedNumber + 1].GetComponent<RectTransform>().DOLocalMove(
            numbers[selectedNumber].GetComponent<RectTransform>().localPosition, 0.25f);
        numbers[selectedNumber].GetComponent<RectTransform>().DOLocalMove(
            numbers[selectedNumber + 1].GetComponent<RectTransform>().localPosition, 0.25f);
        var temp = numbers[selectedNumber + 1];
        numbers[selectedNumber + 1] = numbers[selectedNumber];
        numbers[selectedNumber] = temp;
    }
    public bool Check()
    {
        for (int i = 0; i < numberQuantity - 1; i++)
        {
            if (numbers[i].n > numbers[i + 1].n)
            {
                return false;
            }
        }
        return true;
    }
    private int GetNumberQuantity(int dif)
    {
        int d = dif / 5;
        return Mathf.Clamp(d + 4, 4, 8);
    }
    private List<int> GenerateListInt(int size)
    {
        List<int> list = new List<int>();
        List<int> newList = new List<int>();
        for(int i = 0; i < size; i++)
        {
            list.Add(i);
        }
        for(int i = size-1; i >= 0; i--)
        {
            int r = Random.Range(0, i);
            newList.Add(list[r]);
            list.RemoveAt(r);
        }
        return newList;
    }
}
