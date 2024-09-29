using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _ins = null;

    //UIManager _ui = new UIManager();

    //프로퍼티
    public static GameManager Instance { get { Init(); return _ins; } }
    //public static UIManager UI { get { return Instance._ui; } }

    private void Start()
    {
        Init();
    }
    private void Update()
    {
        //UI.Update();
    }

    static void Init()
    {
        if (_ins == null)
        {
            GameObject temp = GameObject.Find("@GameManager");

            if (temp == null)
            {
                temp = new GameObject("@GameManager");
            }

            temp.TryGetComponent<GameManager>(out _ins);
            if (_ins == null) { _ins = temp.AddComponent<GameManager>(); }
        }
    }
}
