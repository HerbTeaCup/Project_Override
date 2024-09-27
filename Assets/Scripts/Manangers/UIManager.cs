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

        //Ȱ��ȭ ���¸� â�� �ݰ�, ��Ȱ�� ���¸� â�� ��.
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
        //â�� ���� �޼ҵ�

        //���� ������ ����
        if (PopWindow.ContainsKey(key) == false)
        {
            return;
        }

        GameObject window = PopWindow[key];
        UIObject ui;

        //����ó��
        if (window.TryGetComponent<UIObject>(out ui) == false)
        {
            Debug.LogError("UI ������Ʈ �ƴ�");
            return;
        }
        if (window.activeSelf == true)
        {
            Debug.Log("�̹� Ȱ��ȭ�Ǿ� ����");
            return;
        }

        //������Ʈ Ȱ��ȭ�ϰ� â�� ���� ��ܿ� ����
        window.SetActive(true);
        ui.Pop(UIButtonController.SortOrderValue++);

        //â�� �ݴ� �͵� �ʿ��ϹǷ� stack�� Push
        UiStack.Push(window);
    }
    
    void Close()
    {
        //â�� �ݴ� �޼ҵ�

        //�ƹ��͵� ���µ� â�� �������� �ϸ� �׳� ����
        if(UiStack.Count == 0) { return; }

        //Stack���� �����ؼ� ���� �ֱٿ� �� â�� ����
        GameObject window = UiStack.Pop();
        UIObject ui = window.GetComponent<UIObject>();

        //â�� �ݾƾ��ϴϱ� Order�� ���߰� ������Ʈ ��Ȱ��ȭ
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
