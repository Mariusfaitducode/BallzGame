using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void OnMouseDown()
    {
        print("Click");
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        AsyncOperation asyncload = SceneManager.LoadSceneAsync("Game");
        while (!asyncload.isDone)
        {
            yield return null;
        }
    }
}
