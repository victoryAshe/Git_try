using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    //public int questType; // 퀘스트의 종류
    public int questId; // 퀘스트 id
    public int questIndex; // 현재 퀘스트의 내부 퀘스트의 순서
    public Dictionary<int, TempQuestData> questList; // 퀘스트 순서(리스트)
    public GameObject[] questObjects; // 퀘스트 시 필요할 아이템 (0 : 붉은 꽃, 1 : 노란 꽃, 2 : 보라꽃, 3 : 나뭇가지, 4 : 버섯)
    private GameObject[] currObjects; // 현재 가지고 있는 아이템.
    // 퀘스트 주인
    private Dictionary<int, GameObject> questNPC;


    // spotlight
    private Transform spotlightTr;
    // spotlightPoint 위치
    private Transform[] spotlightPointsTr;

    // Inventory
    private Inventory inventory;

    // 싱글턴 인스턴스 선언
    public static QuestManager instance = null;

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

    void Start()
    {
        questList = new Dictionary<int, TempQuestData>();
        questNPC = new Dictionary<int, GameObject>();


        generateData();

        if (GameObject.Find("SpotlightPoints") != null)
        {
            spotlightPointsTr = GameObject.Find("SpotlightPoints").GetComponentsInChildren<Transform>();
        }
        else
        {
            spotlightPointsTr = null;
        }

        if (GameObject.Find("Spot Light") != null)
        {
            spotlightTr = GameObject.Find("Spot Light").GetComponent<Transform>();
        }
        else
        {
            spotlightTr = null;
        }

        inventory = GameObject.Find("Panel - Inventory").GetComponent<Inventory>();

        currObjects = new GameObject[5];
    }


    // 퀘스트 추가
    private void generateData()
    {
        questList.Add(10, new TempQuestData(100, new int[] { 100, 300, 300, 300, 300, 100 })); // (3000 : 붉은 꽃, 3001 : 노란꽃, 3002 : 보라꽃, 3003 : 나뭇가지) 수집형 
        questList.Add(20, new TempQuestData(200, new int[] { 200, 600, 200 })); // (6000 : 버섯) 수집형




        if (GameObject.Find("NPC_1") != null)
        {
            questNPC.Add(10, GameObject.Find("NPC_1"));
        }
        if (GameObject.Find("NPC_2") != null)
        {
            questNPC.Add(20, GameObject.Find("NPC_2"));
        }


    }

    // 현재 퀘스트 NPC와 대화한 NPC 비교 -> 대화 함수 다 끝난 후에 호출
    public void CheckQuest(int id) // 이때 아이디는 사람, 사물 다 가능(퀘스트를 해결하기 위해서는 사물과도 상호작용 필요)
    {
        if (id / 10 == questList[questId].NPCs[questIndex]) // 대화한 사람 혹은 사물이 퀘스트의 순서와 같을 때
        {
            questIndex++; // 퀘스트 순서 하나 올림
        }

        QuestObjectCtrl(id); // 작은 퀘스트의 성공 유무 따른 퀘스트 오브젝의 활성화

        if (questIndex == questList[questId].NPCs.Length) // questIndex와 NPCs의 길이가 같을 때(퀘스트에 관련된 NPC와 대화 다 끝냄/ 퀘스트 성공)
        {
            nextQuest(questNPC[questId].GetComponent<NPC_Ctrl>()); // 다음 퀘스트로 이동
        }
    }

    // 퀘스트의 Id에 따른 작은 퀘스트 관리
    void QuestObjectCtrl(int id) // 아이디는 사람, 사물
    {
        if (questId == 10) // 퀘스트 10 에서
        {
            if (questIndex == 2 || questIndex == 3 || questIndex == 4 || questIndex == 5) // 30000과 상호작용
            {
                if (id % 10 == 0) // 붉은 꽃
                {
                    GetObject(questObjects[0], 0);
                }
                else if (id % 10 == 1) // 노란꽃
                {
                    GetObject(questObjects[1], 1);
                }
                else if (id % 10 == 2) // 보라꽃
                {
                    GetObject(questObjects[2], 2);
                }
                else if (id % 10 == 3) // 나뭇가지
                {
                    GetObject(questObjects[3], 3);
                }
            }
            else if (questIndex == 6) // 1000(NPC_1)과 대화. 
            {
                DelObject(currObjects[0]); // 인벤토리에서 붉은 꽃 삭제
                DelObject(currObjects[1]); // 인벤토리에서 노란 꽃 삭제
                DelObject(currObjects[2]); // 인벤토리에서 보라 꽃 삭제
                DelObject(currObjects[3]); // 인벤토리에서 나뭇가지 삭제
            }
        }
        else if (questId == 20)
        {
            if (questIndex == 2) // 60000(버섯)과 상호작용
            {
                GetObject(questObjects[4], 4);

            }
            else if (questIndex == 3) // 2000(NPC_2)와 상호작용
            {
                DelObject(currObjects[4]); // 인벤토리에서 버섯 삭제
            }
        }
    }

    // 다음 퀘스트로 이동
    void nextQuest(NPC_Ctrl npcCtrl)
    {
        // 퀘스트 성공한 후 NPC의 변수isSucc true로 바꾸기
        npcCtrl.isSucc = true;

        // spotlight 위치 바꾸기
        spotlightTr.position = spotlightPointsTr[1].position;
        spotlightTr.rotation = spotlightPointsTr[1].rotation;

        questId += 10;
        questIndex = 0;
    }

    // 아이템 얻음
    public void GetObject(GameObject item, int i)
    {
        // 인벤토리 슬롯에서 아이템 넣기
        currObjects[i] = inventory.PutItem(item);
    }

    // 아이템 반납
    public void DelObject(GameObject item)
    {
        // 인벤토리 슬롯에서 아이템 삭제하기
        inventory.DelItem(item);
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questIndex;
    }
}