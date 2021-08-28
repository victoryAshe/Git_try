using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Ctrl : MonoBehaviour
{

    // ����Ʈ ����
    //public GameObject reward;

    private Animator anim;

    public bool isSucc = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isSucc)
        {
            QuestSucc();
        }
    }

    // ����Ʈ ������
    private void QuestSucc()
    {
        anim.SetBool("SuccBool", true);
    }
}
