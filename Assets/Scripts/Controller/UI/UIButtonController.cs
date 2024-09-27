using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonController : MonoBehaviour
{
    [SerializeField] GameObject InteractionObj;

    public static int SortOrderValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.UI.AddPopWindow(this.gameObject.name, InteractionObj);
        //GameManager.UI.Updater += Test;
    }
    public void Test()
    {
        GameManager.UI.PushButton(this.gameObject.name);
    }
}
