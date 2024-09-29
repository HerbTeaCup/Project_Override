using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonController : MonoBehaviour
{
    [SerializeField] GameObject InteractionObj;

    UnityEngine.UI.Button _button;

    public static int SortOrderValue = 100;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.name != "CloseButton")
        {
            GameManager.UI.AddPopWindow(this.gameObject.name, InteractionObj);
        }

        _button = GetComponent<UnityEngine.UI.Button>();

        _button.onClick.AddListener(ButtonClick);
    }
    public void ButtonClick()
    {
        if (this.gameObject.name == "CloseButton")
        {
            this.transform.parent.gameObject.SetActive(false);
            return;
        }
        if (InteractionObj == null)
        {
            Debug.Log($"{this.gameObject.name}에 상호작용 설정 필요");
            return;
        }

        GameManager.UI.PushButton(this.gameObject.name);
    }
}
