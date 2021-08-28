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
    private NavMeshAgent agent; // speed 1�� �ϱ� stopping 4�� �ϱ�

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
            // ��ȭ�� ������ �� NPCTrace(), �ִϸ��̼� ����
            if (��ȭ�� ������ ��)
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
            // �����ϴ� �ִϸ��̼�
        }
        else
        {
            // �ȴ� �ִϸ��̼�
        }

        yield return new WaitForSeconds(0.3f);
    }

    public void NPCTrace(Transform trans)
    {
        agent.SetDestination(trans.position);
    }
}
