using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgmt : MonoBehaviour
{
    [SerializeField]
    private Slider HPbar;

    private float maxHp = 100f;
    private float curHp = 100f;
    float imsi;
    void Start()
    {
        HPbar.value = (float)curHp / (float)maxHp;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(curHp > 0)
            {
                curHp -= 10;
            } else
            {
                curHp = 0;
            }
            imsi = (float)curHp / (float)maxHp;
            HandleHp();
        }
        //HandleHp();
    }

    void HandleHp()
    {
        HPbar.value = Mathf.Lerp(HPbar.value, imsi, Time.deltaTime * 10);  
    }
}
