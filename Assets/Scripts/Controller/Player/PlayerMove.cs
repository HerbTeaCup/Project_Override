using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //TODO List:
    //2. 중력, 움직임 구현

    CharacterController _cc;

    Vector3 moveDir = new Vector3();

    [SerializeField] float currentSpeed = 0f;
    [SerializeField] float moveSpeed = 5f;
    float _speedOffset = 0.01f;
    float _speedDelta = 0f;
    float _speedRatio = 10f; //속도 가속 비율

    // Start is called before the first frame update
    void Start()
    {
        _cc = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        VectorUpdate();

        Move();
        Rotate();
    }

    void Gravity()
    {

    }
    void Jump()
    {

    }
    void Move()
    {
        float targetSpeed = 0f;

        if (GameManager.Input.horizontal != 0f)
        {
            //입력값 있으면 속도를 5f로 설정
            targetSpeed = 5f;
        }

        if (currentSpeed < targetSpeed - _speedOffset || currentSpeed > targetSpeed + _speedOffset)
        {
            _speedDelta = Mathf.Lerp(_speedDelta, targetSpeed, _speedRatio * Time.deltaTime);
            _speedDelta = Mathf.Round(_speedDelta * 100f) / 100f;
        }
        else
        {
            _speedDelta = targetSpeed;
        }

        currentSpeed = _speedDelta;

        _cc.Move(moveDir * _speedDelta * Time.deltaTime);
    }
    void Rotate()
    {
        float horizontalInput = GameManager.Input.horizontal;

        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // 오른쪽
        }
        else if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); // 왼쪽
        }
    }
    void VectorUpdate()
    {
        moveDir.x = GameManager.Input.horizontal;
        moveDir.y = GameManager.Input.vertical;
    }
    
    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = _cc.isGrounded ? Color.blue : Color.red;

    //    Gizmos.DrawSphere(this.transform.position,)
    //}
}
