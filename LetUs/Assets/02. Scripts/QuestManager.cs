using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    //public int questType; // ����Ʈ�� ����
    public int questId; // ����Ʈ id
    public int questIndex; // ���� ����Ʈ�� ���� ����Ʈ�� ����
    public Dictionary<int, TempQuestData> questList; // ����Ʈ ����(����Ʈ)
    public GameObject[] questObjects; // ����Ʈ �� �ʿ��� ������ (0 : ���� ��, 1 : ��� ��, 2 : �����, 3 : ��������, 4 : ����)
    private GameObject[] currObjects; // ���� ������ �ִ� ������.
    // ����Ʈ ����
    private Dictionary<int, GameObject> questNPC;


    // spotlight
    private Transform spotlightTr;
    // spotlightPoint ��ġ
    private Transform[] spotlightPointsTr;

    // Inventory
    private Inventory inventory;

    // �̱��� �ν��Ͻ� ����
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


    // ����Ʈ �߰�
    private void generateData()
    {
        questList.Add(10, new TempQuestData(100, new int[] { 100, 300, 300, 300, 300, 100 })); // (3000 : ���� ��, 3001 : �����, 3002 : �����, 3003 : ��������) ������ 
        questList.Add(20, new TempQuestData(200, new int[] { 200, 600, 200 })); // (6000 : ����) ������




        if (GameObject.Find("NPC_1") != null)
        {
            questNPC.Add(10, GameObject.Find("NPC_1"));
        }
        if (GameObject.Find("NPC_2") != null)
        {
            questNPC.Add(20, GameObject.Find("NPC_2"));
        }


    }

    // ���� ����Ʈ NPC�� ��ȭ�� NPC �� -> ��ȭ �Լ� �� ���� �Ŀ� ȣ��
    public void CheckQuest(int id) // �̶� ���̵�� ���, �繰 �� ����(����Ʈ�� �ذ��ϱ� ���ؼ��� �繰���� ��ȣ�ۿ� �ʿ�)
    {
        if (id / 10 == questList[questId].NPCs[questIndex]) // ��ȭ�� ��� Ȥ�� �繰�� ����Ʈ�� ������ ���� ��
        {
            questIndex++; // ����Ʈ ���� �ϳ� �ø�
        }

        QuestObjectCtrl(id); // ���� ����Ʈ�� ���� ���� ���� ����Ʈ �������� Ȱ��ȭ

        if (questIndex == questList[questId].NPCs.Length) // questIndex�� NPCs�� ���̰� ���� ��(����Ʈ�� ���õ� NPC�� ��ȭ �� ����/ ����Ʈ ����)
        {
            nextQuest(questNPC[questId].GetComponent<NPC_Ctrl>()); // ���� ����Ʈ�� �̵�
        }
    }

    // ����Ʈ�� Id�� ���� ���� ����Ʈ ����
    void QuestObjectCtrl(int id) // ���̵�� ���, �繰
    {
        if (questId == 10) // ����Ʈ 10 ����
        {
            if (questIndex == 2 || questIndex == 3 || questIndex == 4 || questIndex == 5) // 30000�� ��ȣ�ۿ�
            {
                if (id % 10 == 0) // ���� ��
                {
                    GetObject(questObjects[0], 0);
                }
                else if (id % 10 == 1) // �����
                {
                    GetObject(questObjects[1], 1);
                }
                else if (id % 10 == 2) // �����
                {
                    GetObject(questObjects[2], 2);
                }
                else if (id % 10 == 3) // ��������
                {
                    GetObject(questObjects[3], 3);
                }
            }
            else if (questIndex == 6) // 1000(NPC_1)�� ��ȭ. 
            {
                DelObject(currObjects[0]); // �κ��丮���� ���� �� ����
                DelObject(currObjects[1]); // �κ��丮���� ��� �� ����
                DelObject(currObjects[2]); // �κ��丮���� ���� �� ����
                DelObject(currObjects[3]); // �κ��丮���� �������� ����
            }
        }
        else if (questId == 20)
        {
            if (questIndex == 2) // 60000(����)�� ��ȣ�ۿ�
            {
                GetObject(questObjects[4], 4);

            }
            else if (questIndex == 3) // 2000(NPC_2)�� ��ȣ�ۿ�
            {
                DelObject(currObjects[4]); // �κ��丮���� ���� ����
            }
        }
    }

    // ���� ����Ʈ�� �̵�
    void nextQuest(NPC_Ctrl npcCtrl)
    {
        // ����Ʈ ������ �� NPC�� ����isSucc true�� �ٲٱ�
        npcCtrl.isSucc = true;

        // spotlight ��ġ �ٲٱ�
        spotlightTr.position = spotlightPointsTr[1].position;
        spotlightTr.rotation = spotlightPointsTr[1].rotation;

        questId += 10;
        questIndex = 0;
    }

    // ������ ����
    public void GetObject(GameObject item, int i)
    {
        // �κ��丮 ���Կ��� ������ �ֱ�
        currObjects[i] = inventory.PutItem(item);
    }

    // ������ �ݳ�
    public void DelObject(GameObject item)
    {
        // �κ��丮 ���Կ��� ������ �����ϱ�
        inventory.DelItem(item);
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questIndex;
    }
}