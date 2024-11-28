using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    //각 키마다 토글형인지 트리거형인지 기획서에 적혀있지 않아서 상식선으로 만듦.

    public float horizontal { get; private set; }
    public float vertical { get; private set; }

    #region bool Input
    public bool attack { get; private set; }
    public bool jump { get; private set; }
    public bool weaponChange1 { get; private set; }
    public bool weaponChange2 { get; private set; }
    public bool[] skills { get; private set; } = new bool[4];

    public bool dash { get; private set; }
    public bool Genius { get; private set; }
    #endregion


    public void InputUpdate()
    {//GamemanagerUpdate에서 실행됨

        MovementInput();

        TriggerInput();
        HoldInput();
        ToggleInput();
    }

    void MovementInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            horizontal = -1f;
        else if (Input.GetKey(KeyCode.RightArrow))
            horizontal = 1f;
        else
            horizontal = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
            vertical = 1f;
        else if (Input.GetKey(KeyCode.DownArrow))
            vertical = -1f;
        else
            vertical = 0f;
    }

    void TriggerInput()
    {
        attack = Input.GetKeyDown(KeyCode.X);
        jump = Input.GetKeyDown(KeyCode.Z);

        skills[0] = Input.GetKeyDown(KeyCode.A);
        skills[1] = Input.GetKeyDown(KeyCode.S);
        skills[2] = Input.GetKeyDown(KeyCode.D);
        skills[3] = Input.GetKeyDown(KeyCode.F);

        weaponChange1 = Input.GetKeyDown(KeyCode.C);
        weaponChange2 = Input.GetKeyDown(KeyCode.V);
    }

    void HoldInput()
    {
        dash = Input.GetKey(KeyCode.Space);
        Genius = Input.GetKey(KeyCode.LeftControl);
    }

    void ToggleInput()
    {

    }
}
