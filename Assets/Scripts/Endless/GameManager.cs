using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelInitialNumber levelInitialNumber;
    [SerializeField] private GameRules gameRules;

    private int difficult = 0;

    private void Start()
    {
        difficult = 0;
        StartCoroutine(LevelStartAnimation());
    }
    public IEnumerator LevelStartAnimation()
    {
        yield return levelInitialNumber.StartAnimation(difficult);
        gameRules.GenerateLevel(difficult);
        gameRules.UpdateSelector(0);
        foreach (Number n in gameRules.numbers)
        {
            n.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                n.GetComponent<RectTransform>().anchoredPosition.x,
                n.GetComponent<RectTransform>().anchoredPosition.y + 720);
        }
        foreach (Number n in gameRules.numbers)
        {
            n.GetComponent<RectTransform>().DOAnchorPosY(GameRules.NUMBER_SIZE * 0.8f, 0.5f);
            yield return new WaitForSeconds(0.1f);
        }
    }
    public IEnumerator LevelEndAnimation()
    {
        difficult++;
        yield return new WaitForSeconds(0.5f);
        foreach (Number n in gameRules.numbers)
        {
            n.Checked();
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        foreach (Number n in gameRules.numbers)
        {
            n.GetComponent<RectTransform>().DOAnchorPosX(
                n.GetComponent<RectTransform>().anchoredPosition.x + 1280, 
                1f).SetEase(Ease.Linear);
        }
        yield return LevelStartAnimation();
    }
    public void CheckIfIsOrdered()
    {
        if (gameRules.Check())
            StartCoroutine(LevelEndAnimation());
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
