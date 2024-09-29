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
            //�ݴ� ��ư�� �θ� ������Ʈ ��Ȱ��ȭ
            this.transform.parent.gameObject.SetActive(false);
            return;
        }

        if (InteractionObj == null)
        {
            Debug.Log($"{this.gameObject.name}�� ������Ʈ ���� �ʿ�");
            return;
        }

        InteractionObj.SetActive(true);
    }
}
