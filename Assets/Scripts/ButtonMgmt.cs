using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMgmt : MonoBehaviour
{
    public void GotoScene(string scene)
    {
        try
        {
            SceneManager.LoadScene(scene);
            Debug.Log("System: " + scene + "씬이 로드에 성공했습니다!");
        } catch
        {
            Debug.LogWarning("System: " + scene + "씬이 로드에 실패했습니다!");
        }
    }

    public void ApplicationQuit()
    {
        Debug.Log("게임이 종료됩니다");
        Application.Quit();
    }
}
