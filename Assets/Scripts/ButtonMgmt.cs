using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental;
using UnityEditor;
using UnityEditor.EditorTools;

public class ButtonMgmt : MonoBehaviour
{
    public AudioClip clip;
    public void GotoScene(string scene)
    {
        //try
        //{
            
        SceneManager.LoadScene(scene);
        AudioMgmt.instance.SFXPlay("Start_sound", clip);
        Debug.Log("System: " + scene + "씬이 로드에 성공했습니다!");
        //} catch
        //{
          //  Debug.LogError("System: " + scene + "씬이 로드에 실패했습니다!");
        //}
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  //유니티 에디터에서 플레이시 play를 false로
#elif UNITY_WEBPLAYER
        Application.OpenURL("http://stackoverflow.com/"); //개발자들의 성지로 이동
#else
        Application.Quit(); //앱 종료
#endif
    }
}