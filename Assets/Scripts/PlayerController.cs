using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float jump = 3f;
    public Joystic joystic; //조이스틱
    public float Player_speed; //플레이어 속도

    private Vector2 _moveVector; //플레이어 이동 위치
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform; //트랜스폼
        _moveVector = Vector2.zero; //플레이어 이동백터
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
        }
        HandleInput();
    }

    private void FixedUpdate()
    {
        Move(); //플레이어 이동
    }

    private void HandleInput()
    {
        _moveVector = poolInput();
    }

    public Vector2 poolInput()
    {
        float h = joystic.GetHorizontalValue();
        Vector2 moveDir = new Vector3(h, 0).normalized;

        return moveDir;
    }

    public void Move()
    {
        _transform.Translate(_moveVector * Player_speed * Time.deltaTime);
    }

    public void Jump_B()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
    }
}
