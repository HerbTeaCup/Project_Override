using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public System.Action Updater = null;

    Dictionary<string, GameObject> PopWindow = new Dictionary<string, GameObject>();
    Stack<GameObject> UiStack = new Stack<GameObject>();

    public void AddPopWindow(string key, GameObject value)
    {
        PopWindow.Add(key, value);
    }
    public GameObject GetValue(string key)
    {
        return PopWindow[key];
    }
    public void Clear()
    {
        PopWindow.Clear();
    }

    #region ForButton
    public void PushButton(string key)
    {
        if (PopWindow.ContainsKey(key) == false)
        {
            Debug.LogError($"{key} is not Added Dictionary key");
            return;
        }

        //활성화 상태면 창을 닫고, 비활성 상태면 창을 엶.
        if (PopWindow[key].activeSelf)
        {
            Close();
        }
        else
        {
            OpenUp(key);
        }
    }
    void OpenUp(string key)
    {
        //창을 여는 메소드

        //값이 없으면 리턴
        if (PopWindow.ContainsKey(key) == false)
        {
            return;
        }

        GameObject window = PopWindow[key];
        UIObject ui;

        //예외처리
        if (window.TryGetComponent<UIObject>(out ui) == false)
        {
            Debug.LogError("UI 오브젝트 아님");
            return;
        }
        if (window.activeSelf == true)
        {
            Debug.Log("이미 활성화되어 있음");
            return;
        }

        //오브젝트 활성화하고 창을 제일 상단에 노출
        window.SetActive(true);
        ui.Pop(UIButtonController.SortOrderValue++);

        //창을 닫는 것도 필요하므로 stack에 Push
        UiStack.Push(window);
    }
    
    void Close()
    {
        //창을 닫는 메소드

        //아무것도 없는데 창을 닫으려고 하면 그냥 리턴
        if(UiStack.Count == 0) { return; }

        //Stack으로 저장해서 가장 최근에 연 창을 닫음
        GameObject window = UiStack.Pop();
        UIObject ui = window.GetComponent<UIObject>();

        //창을 닫아야하니까 Order값 낮추고 오브젝트 비활성화
        UIButtonController.SortOrderValue--;
        ui.Push();
        window.SetActive(false);
    }
    #endregion

    public void Update()
    {
        if (Updater != null)
        {
            Updater();
        }
    }
}
