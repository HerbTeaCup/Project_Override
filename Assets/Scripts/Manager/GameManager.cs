using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;
    InputManager _input = new InputManager();
    CameraManager _cam = new CameraManager();

    public static GameManager Instance { get { Init(); return _instance; }}
    public static InputManager Input { get { return Instance._input; } }
    public static CameraManager Cam { get { return Instance._cam; } }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Input.InputUpdate();
    }

    static void Init()
    {
        if (_instance == null)
        {
            GameObject temp = GameObject.Find("@GameManager");

            if (temp == null)
            {
                temp = new GameObject("@GameManager");
                DontDestroyOnLoad(temp);
            }

            temp.TryGetComponent<GameManager>(out _instance);
            if (_instance == null) { _instance = temp.AddComponent<GameManager>(); }
        }
    }
}
