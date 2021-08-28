using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JoinQuest : MonoBehaviour
{
    //private int questType = 200;

    private Rigidbody npcRb;
    private Transform npctr;
    private Transform playertr;
    private NavMeshAgent agent; // speed 1로 하기 stopping 4로 하기

    private QuestManager questManager;

    private Animator anim;

    private void Start()
    {
        npcRb = GetComponent<Rigidbody>();
        npctr = GetComponent<Transform>();
        playertr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();

        questManager = GameObject.Find("QuestManager").GetComponent<QuestManager>();

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        /*if (questManager.questType == questType)
        {
            // 대화가 끝났을 때 NPCTrace(), 애니메이션 설정
            if (대화가 끝났을 때)
            {
                StartCoroutine(CheckNPCAnim());
                NPCTrace(playertr);
            }


        }*/
    }

    IEnumerator CheckNPCAnim()
    {
        if (npcRb.velocity.x == 0 && npcRb.velocity.z == 0)
        {
            // 정지하는 애니메이션
        }
        else
        {
            // 걷는 애니메이션
        }

        yield return new WaitForSeconds(0.3f);
    }

    public void NPCTrace(Transform trans)
    {
        agent.SetDestination(trans.position);
    }
}
