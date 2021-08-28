using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    // 인벤토리의 열고 닫는 변수
    private bool isOpened;

    public RawImage bg_black;//검은색 화면

    public Button inventoryButton;
    public CanvasGroup inventoryPanel;

    // 싱글턴 인스턴스 선언
    public static GameManager instance = null;


    void Awake()
    {
        // 싱글턴
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        QuestManager questManager = this.GetComponent<QuestManager>();
        questManager.questId = 10;

        //bg_black.gameObject.SetActive(true);

        //StartCoroutine(Fadein());//페이드인 효과 실행

        inventoryButton = GameObject.Find("Inventory Button").GetComponent<Button>();
        inventoryPanel = GameObject.Find("Panel - Inventory").GetComponent<CanvasGroup>();

        
    }

    void Start()
    {
        isOpened = false; // 처음 인벤토리의 상태
        inventoryButton.onClick.AddListener(() => InventoryCheck());

    }

    void Update()
    {
        
    }




    // 인벤토리를 여는 함수
    public void InventoryCheck()
    {
        isOpened = !isOpened;

        inventoryPanel.alpha = isOpened ? 1.0f : 0.0f;
        inventoryPanel.interactable = isOpened;
    }


    IEnumerator Fadein()
    {
        float fadeCount = 1.0f; //처음 알파값
        while (fadeCount > 0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            bg_black.color = new Color(0, 0, 0, fadeCount);//해당 변수값으로 알파값 지정
        }
        bg_black.gameObject.SetActive(false);
    }
}


