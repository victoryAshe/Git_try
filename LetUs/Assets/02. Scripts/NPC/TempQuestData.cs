using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempQuestData
{
    // ���� ������ ���� �ӽ÷� ���� ���Դϴ�. �� ������ �����Դϴ�.

    public int questTypeId; // ����Ʈ ����(������ : 100, ������ : 200)
    private GameObject NPC; // ����Ʈ�� �� NPC
    public int[] NPCs; // ����Ʈ�� �ʿ��� NPC ����

    public TempQuestData(int questTypeId, int[] NPCs)
    {
        this.questTypeId = questTypeId;
        this.NPCs = NPCs;
    }

    // Start is called before the first frame update
    void Start()
    {
        NPC_Ctrl NPCInfo = NPC.GetComponent<NPC_Ctrl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ������ ����Ʈ
    void CollectQuest(NPC_Ctrl NPCInfo)
    {

    }

    //
}
