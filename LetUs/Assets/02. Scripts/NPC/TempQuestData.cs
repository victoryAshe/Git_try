using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempQuestData
{
    // 오류 방지를 위해 임시로 만든 것입니다. 곧 삭제할 예정입니다.

    public int questTypeId; // 퀘스트 종류(수집형 : 100, 참여형 : 200)
    private GameObject NPC; // 퀘스트의 주 NPC
    public int[] NPCs; // 퀘스트에 필요한 NPC 순서

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

    // 수집형 퀘스트
    void CollectQuest(NPC_Ctrl NPCInfo)
    {

    }

    //
}
