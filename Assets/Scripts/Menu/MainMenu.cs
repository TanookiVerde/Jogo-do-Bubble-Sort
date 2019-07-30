using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OpenEndlessGame()
    {
        SceneManager.LoadScene("EndlessGame");
    }
    public void OpenBubbleSort()
    {
        SceneManager.LoadScene("BubbleSortGame");
    }
}
