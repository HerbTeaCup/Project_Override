using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonController : MonoBehaviour
{
    [SerializeField] GameObject InteractionObj;

    UnityEngine.UI.Button _button;
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<UnityEngine.UI.Button>();

        _button.onClick.AddListener(ButtonClick);
    }
    public void ButtonClick()
    {
        if (this.gameObject.name.Equals("CloseButton"))
        {
            //닫는 버튼은 부모 오브젝트 비활성화
            this.transform.parent.gameObject.SetActive(false);
            return;
        }

        if (InteractionObj == null)
        {
            Debug.Log($"{this.gameObject.name}에 오브젝트 연결 필요");
            return;
        }

        InteractionObj.SetActive(true);
    }
}
