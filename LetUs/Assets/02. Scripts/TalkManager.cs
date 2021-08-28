using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TalkManager : MonoBehaviour
{
    //퀘스트 관련 대화 정보 저장 <npcId, talkString[]>
    Dictionary<int, string[]> talkData = new Dictionary<int, string[]>();

    //몇 번째 대화가 이어지는지 저장
    public int talkIndex;

    //대화창에 화자의 이름을 띄움
    public Text TalkerName;

    //대화창에 텍스트를 띄움
    public Text talkText;

    //대화창 배경
    public GameObject TalkImage;

    //PlayerIneteraction에서 확인한 오브젝트 저장
    private GameObject scanObject;

    //quest관련 텍스트
    public Text QuestText;


    //대화 오류 방지용
    private int questId;
    public Dictionary<int, TempQuestData> questList = new Dictionary<int, TempQuestData>();


    //플레이어가 움직일 수 있 or 없 정보 저장
    //지금은 게임매니저에 isMove에 따라 움직이는 기능 안 들어있음
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

        talkData.Add(2000, new string[] { "...안녕.", "...", "말 걸지 말아줘." });
        talkData.Add(1000, new string[] { "서로씨를 도와주고 있구나? 내 말을 따라줘서 고마워.", "무슨 일인지는 모르겠지만, 잘 해결됐으면 좋겠다!" });

        talkData.Add(10 + 1000, new string[] { "나는 윤이야.", "...너는 이름이 뭐야?", "아, 어쩌다 이런 시골에 이사왔냐고?", "글쎄... 좀 긴 이야기야.", "~", "그래서 말인데, 꽃다발을 만들 수 있게 빨간색, 노란색, 보라색 꽃 하나씩이랑 나뭇가지를 가져와줄 수 있을까?" });
        talkData.Add(11 + 3000, new string[] { "빨간색 꽃을 얻었다." });
        talkData.Add(12 + 3001, new string[] { "노란색 꽃을 얻었다." });
        talkData.Add(13 + 3002, new string[] { "보라색 꽃을 얻었다." });
        talkData.Add(14 + 3003, new string[] { "나뭇가지를 얻었다." });
        talkData.Add(15 + 1000, new string[] { "와, 고마워! 예상했던 것보다 훨씬 예쁘다!", "사실 이 좋은 곳에 와놓고도 일이 바빠서 나가보질 못했거든. 이렇게라도 꽃구경을 할 수 있게해줘서 정말 고마워.", "내 옆집 사람 좀 봐. 이름은 서로라고 하는데, 여기 와서 한 번도 말을 걸어본 적이 없어. 내 이름은 알까 몰라!", "저 사람도 요즘 고민이 많아 보이던데, 혹시 네가 괜찮다면 서로씨를 도와주지 않을래?" });





        talkData.Add(20 + 2000, new string[] { "뭐? 윤이씨가 보내서 왔다고? 그게 누군데?", "...아, 옆집 사람? 이상하다, 한 번도 얘기해본 적 없는데. 그 사람이 나를 왜?", "...내가 요즘 힘들어보였다고? 으음, 힘들기야 했지.", "내가 요리를 좀 좋아하는데... 새로운 레시피를 개발하는 게 여간 어려운 일이 아니더라고.", "음... 염치없지만, 나도 부탁 하나 해도 될까? 다른 게 아니라, 내가 여기서만 만들 수 있는 새로운 요리를 개발해보고 있거든.", "희귀한 버섯을 찾고 있는데... 내 힘으로는 못 가겠어서 말이야. 저기 폭포 안쪽에 자생하는 버섯이나, 아니면 그 앞 바위 밑둥에서 자라있는 버섯 하나를 가져와주면 돼!" });
        talkData.Add(21 + 6000, new string[] { "희귀한 버섯을 얻었다." });
        talkData.Add(22 + 2000, new string[] { "오오! 버섯을 가져와줬구나! 고마워! 이걸로 특제 요리를 만들 수 있겠어!", "언젠가 마을 사람들과 친해지고나면, 특별한 요리를 만들어서 모두와 같이 나눠 먹는 게 내 꿈이었거든.", "...뭐? 지금? 에이, 아니야. 이제야 처음 만들었는데, 더 연습을 해보고 나서… 야! 가져가지 마!" });


    }


    public string GetTalk(int id, int talkIndex) //대화 정보를 가져오는 함수
    {
        if (questList.ContainsKey(questId))
        {
            if (!talkData.ContainsKey(id))
            {
                //현재 퀘스트 진행 중X or 퀘스트와 상관없는 npc에게 말을 걸었을 때
                if (!talkData.ContainsKey(id - id % 10))
                {
                    //기본 설정 대화 이어질 수 있게 함
                    return GetTalk(id - id % 100, talkIndex);
                }
                else
                {
                    //퀘스트 npc에게 말 걸었을 때 미리 설정한 퀘스트 대화 이뤄지게 함
                    return GetTalk(id - id % 10, talkIndex);
                }
            }
            //id와 talkIndex를 인자로 받아 talkData에 있는 대화내용들을 반환
            //더 이상 대화내용이 없다면 null값을 반환하는 함수
            if (talkIndex == talkData[id].Length)
            {

                return null;

            }
            else
                return talkData[id][talkIndex];
        }
        else
            return "...안녕";




    }

    public void ShowText(GameObject scanObj)
    {


        if (scanObj != scanObject)
        {
            talkIndex = 0;
        }
        //인자로 받은 scanObj저장
        scanObject = scanObj;
        //확인한 오브젝트의 ObjectData 가져오기
        ObjectData objectData = scanObj.GetComponent<ObjectData>();

        //OnTalk에 확인한 오브젝트의 값을 인자로 전달
        OnTalk(objectData.id, objectData.isNpc);

        //대화창에 확인한 오브젝트의 이름 출력
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

        //talkData를 talkText의 text값으로 넘겨 npc와 대화할 수 있게 함
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
