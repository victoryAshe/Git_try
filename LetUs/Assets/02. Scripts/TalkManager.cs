using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TalkManager : MonoBehaviour
{
    //����Ʈ ���� ��ȭ ���� ���� <npcId, talkString[]>
    Dictionary<int, string[]> talkData = new Dictionary<int, string[]>();

    //�� ��° ��ȭ�� �̾������� ����
    public int talkIndex;

    //��ȭâ�� ȭ���� �̸��� ���
    public Text TalkerName;

    //��ȭâ�� �ؽ�Ʈ�� ���
    public Text talkText;

    //��ȭâ ���
    public GameObject TalkImage;

    //PlayerIneteraction���� Ȯ���� ������Ʈ ����
    private GameObject scanObject;

    //quest���� �ؽ�Ʈ
    public Text QuestText;


    //��ȭ ���� ������
    private int questId;
    public Dictionary<int, TempQuestData> questList = new Dictionary<int, TempQuestData>();


    //�÷��̾ ������ �� �� or �� ���� ����
    //������ ���ӸŴ����� isMove�� ���� �����̴� ��� �� �������
    public bool isMove;


    void Awake()
    {

    }
    void Start()
    {
        QuestText = GameObject.Find("QuestWindow").GetComponent<Text>();

        QuestManager questManager = GameObject.Find("GameManager").GetComponent<QuestManager>();
        questId = questManager.questId;
        questList = questManager.questList;

        Make_Talk();
    }

    void Update()
    {

    }

    void Make_Talk()
    {

        talkData.Add(2000, new string[] { "...�ȳ�.", "...", "�� ���� ������." });
        talkData.Add(1000, new string[] { "���ξ��� �����ְ� �ֱ���? �� ���� �����༭ ����.", "���� �������� �𸣰�����, �� �ذ������ ���ڴ�!" });

        talkData.Add(10 + 1000, new string[] { "���� ���̾�.", "...�ʴ� �̸��� ����?", "��, ��¼�� �̷� �ð� �̻�Գİ�?", "�۽�... �� �� �̾߱��.", "~", "�׷��� ���ε�, �ɴٹ��� ���� �� �ְ� ������, �����, ����� �� �ϳ����̶� ���������� �������� �� ������?" });
        talkData.Add(11 + 3000, new string[] { "������ ���� �����." });
        talkData.Add(12 + 3001, new string[] { "����� ���� �����." });
        talkData.Add(13 + 3002, new string[] { "����� ���� �����." });
        talkData.Add(14 + 3003, new string[] { "���������� �����." });
        talkData.Add(15 + 1000, new string[] { "��, ����! �����ߴ� �ͺ��� �ξ� ���ڴ�!", "��� �� ���� ���� �ͳ��� ���� �ٺ��� �������� ���߰ŵ�. �̷��Զ� �ɱ����� �� �� �ְ����༭ ���� ����.", "�� ���� ��� �� ��. �̸��� ���ζ�� �ϴµ�, ���� �ͼ� �� ���� ���� �ɾ ���� ����. �� �̸��� �˱� ����!", "�� ����� ���� ����� ���� ���̴���, Ȥ�� �װ� �����ٸ� ���ξ��� �������� ������?" });





        talkData.Add(20 + 2000, new string[] { "��? ���̾��� ������ �Դٰ�? �װ� ������?", "...��, ���� ���? �̻��ϴ�, �� ���� ����غ� �� ���µ�. �� ����� ���� ��?", "...���� ���� �������ٰ�? ����, ������ ����.", "���� �丮�� �� �����ϴµ�... ���ο� �����Ǹ� �����ϴ� �� ���� ����� ���� �ƴϴ����.", "��... ��ġ������, ���� ��Ź �ϳ� �ص� �ɱ�? �ٸ� �� �ƴ϶�, ���� ���⼭�� ���� �� �ִ� ���ο� �丮�� �����غ��� �ְŵ�.", "����� ������ ã�� �ִµ�... �� �����δ� �� ���ھ ���̾�. ���� ���� ���ʿ� �ڻ��ϴ� �����̳�, �ƴϸ� �� �� ���� �صտ��� �ڶ��ִ� ���� �ϳ��� �������ָ� ��!" });
        talkData.Add(21 + 6000, new string[] { "����� ������ �����." });
        talkData.Add(22 + 2000, new string[] { "����! ������ �������ᱸ��! ����! �̰ɷ� Ư�� �丮�� ���� �� �ְھ�!", "������ ���� ������ ģ��������, Ư���� �丮�� ���� ��ο� ���� ���� �Դ� �� �� ���̾��ŵ�.", "...��? ����? ����, �ƴϾ�. ������ ó�� ������µ�, �� ������ �غ��� ������ ��! �������� ��!" });


    }


    public string GetTalk(int id, int talkIndex) //��ȭ ������ �������� �Լ�
    {
        if (questList.ContainsKey(questId))
        {
            if (!talkData.ContainsKey(id))
            {
                //���� ����Ʈ ���� ��X or ����Ʈ�� ������� npc���� ���� �ɾ��� ��
                if (!talkData.ContainsKey(id - id % 10))
                {
                    //�⺻ ���� ��ȭ �̾��� �� �ְ� ��
                    return GetTalk(id - id % 100, talkIndex);
                }
                else
                {
                    //����Ʈ npc���� �� �ɾ��� �� �̸� ������ ����Ʈ ��ȭ �̷����� ��
                    return GetTalk(id - id % 10, talkIndex);
                }
            }
            //id�� talkIndex�� ���ڷ� �޾� talkData�� �ִ� ��ȭ������� ��ȯ
            //�� �̻� ��ȭ������ ���ٸ� null���� ��ȯ�ϴ� �Լ�
            if (talkIndex == talkData[id].Length)
            {

                return null;

            }
            else
                return talkData[id][talkIndex];
        }
        else
            return "...�ȳ�";




    }

    public void ShowText(GameObject scanObj)
    {


        if (scanObj != scanObject)
        {
            talkIndex = 0;
        }
        //���ڷ� ���� scanObj����
        scanObject = scanObj;
        //Ȯ���� ������Ʈ�� ObjectData ��������
        ObjectData objectData = scanObj.GetComponent<ObjectData>();

        //OnTalk�� Ȯ���� ������Ʈ�� ���� ���ڷ� ����
        OnTalk(objectData.id, objectData.isNpc);

        //��ȭâ�� Ȯ���� ������Ʈ�� �̸� ���
        TalkerName.text = "[" + objectData.ObjectName + "]";

        isMove = false;

        TalkImage.SetActive(true);

    }

    void OnTalk(int id, bool isNpc)
    {
        QuestManager questManager = GameObject.Find("GameManager").GetComponent<QuestManager>();
        int questTalkIndex = questManager.GetQuestTalkIndex(id);

        string talkData = GetTalk(id + questTalkIndex, talkIndex);

        if (talkData == null)
        {
            isMove = false;
            talkIndex = 0;

            questManager.CheckQuest(id);

            TalkImage.SetActive(false);

            return;
        }

        //talkData�� talkText�� text������ �Ѱ� npc�� ��ȭ�� �� �ְ� ��
        talkText.text = talkData;

        isMove = true;






    }

    public void OnScriptButtonClick()
    {
        talkIndex++;

        ObjectData objectData = scanObject.GetComponent<ObjectData>();
        OnTalk(objectData.id, objectData.isNpc);
    }

    public void OnQuitButtonClick()
    {
        TalkImage.SetActive(false);
    }

}
