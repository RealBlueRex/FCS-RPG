using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_PlayerController : MonoBehaviour
{
    public int Player_speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * Player_speed * Time.deltaTime, 0f));
        }
    }
}
