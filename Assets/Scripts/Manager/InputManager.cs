using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    //�� Ű���� ��������� Ʈ���������� ��ȹ���� �������� �ʾƼ� ��ļ����� ����.

    public float horizontal { get; private set; }
    public float vertical { get; private set; }

    #region bool Input
    public bool attack { get; private set; }
    public bool jump { get; private set; }
    public bool weaponChange1 { get; private set; }
    public bool weaponChange2 { get; private set; }
    public bool[] skills { get; private set; }

    public bool dash { get; private set; }
    public bool Genius { get; private set; }
    #endregion


    public void InputUpdate()
    {//GamemanagerUpdate���� �����

        MovementInput();

        TriggerInput();
        HoldInput();
        ToggleInput();
    }

    void MovementInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            horizontal += -1f;
        if (Input.GetKey(KeyCode.RightArrow))
            horizontal += 1f;

        if (Input.GetKey(KeyCode.UpArrow))
            vertical += 1f;
        if (Input.GetKey(KeyCode.DownArrow))
            vertical += -1f;

        horizontal = Mathf.Clamp(horizontal, -1f, 1f);
        vertical = Mathf.Clamp(vertical, -1f, 1f);
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
