using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    EnemyStatus _status;
    Animator _anim;

    float _attackCoolTime = 2.1f;
    float _attackDeltaTime = 3f;

    private void Start()
    {
        _status = this.GetComponent<EnemyStatus>();
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (_attackDeltaTime <= _attackCoolTime)
        {
            _attackDeltaTime += Time.deltaTime;
            return;
        }
        if (_status.attackable == false)
            return;

        _attackDeltaTime = 0f;
        _anim.SetTrigger("Attack");
    }
}
