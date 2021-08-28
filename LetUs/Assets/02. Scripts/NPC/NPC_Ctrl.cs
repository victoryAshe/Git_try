using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Ctrl : MonoBehaviour
{

    // 퀘스트 보상
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

    // 퀘스트 성공시
    private void QuestSucc()
    {
        anim.SetBool("SuccBool", true);
    }
}
