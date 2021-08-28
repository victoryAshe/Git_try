using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // �̱��� �ν��Ͻ� ����
    public static DontDestroy instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }


        DontDestroyOnLoad(this.gameObject);
    }
}
