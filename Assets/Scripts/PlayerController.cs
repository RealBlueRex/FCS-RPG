using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Joystic joystic; //조이스틱
    public float Player_speed; //플레이어 속도

    private Vector3 _moveVector; //플레이어 이동 위치
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform; //트랜스폼
        _moveVector = Vector3.zero; //플레이어 이동백터
    }

    // Update is called once per frame
    void Update()
    {
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

    public Vector3 poolInput()
    {
        float h = joystic.GetHorizontalValue();
        float v = joystic.GetVerticalValue();
        Vector3 moveDir = new Vector3(h, v, 0).normalized;

        return moveDir;
    }

    public void Move()
    {
        _transform.Translate(_moveVector * Player_speed * Time.deltaTime);
    }
}
