using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AudioMgmt : MonoBehaviour
{
    public static AudioMgmt instance;

    public AudioClip aydi;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(instance);
        } else
        {
            //Destroy(gameObject);
        }
    }

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.clip = clip;
        audiosource.Play();

        Destroy(go, clip.length);
    }

    public void OnclickPlay()
    {
        //추후 작동 안될시 코드 추가 작성 바람
    }
}
