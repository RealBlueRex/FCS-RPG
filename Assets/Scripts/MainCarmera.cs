using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCarmera : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, -10f);
    }
}
