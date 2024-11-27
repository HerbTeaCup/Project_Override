using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //TODO List:
    //1. 커맨드 시스템 연결
    //2. 중력, 움직임 구현

    CharacterController _cc;

    // Start is called before the first frame update
    void Start()
    {
        _cc = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Gravity()
    {

    }

    void Command()
    {

    }
    private void OnDrawGizmosSelected()
    {
        
    }
}
