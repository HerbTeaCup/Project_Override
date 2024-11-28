using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSencing : MonoBehaviour
{
    EnemyStatus _status;
    // Start is called before the first frame update
    void Start()
    {
        _status = this.transform.root.GetComponent<EnemyStatus>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _status.attackable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _status.attackable = false;
        }
    }
}
