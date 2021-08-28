using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    // �κ��丮�� ���� �ݴ� ����
    private bool isOpened;

    public RawImage bg_black;//������ ȭ��

    public Button inventoryButton;
    public CanvasGroup inventoryPanel;

    // �̱��� �ν��Ͻ� ����
    public static GameManager instance = null;


    void Awake()
    {
        // �̱���
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

        //StartCoroutine(Fadein());//���̵��� ȿ�� ����

        inventoryButton = GameObject.Find("Inventory Button").GetComponent<Button>();
        inventoryPanel = GameObject.Find("Panel - Inventory").GetComponent<CanvasGroup>();

        
    }

    void Start()
    {
        isOpened = false; // ó�� �κ��丮�� ����
        inventoryButton.onClick.AddListener(() => InventoryCheck());

    }

    void Update()
    {
        
    }




    // �κ��丮�� ���� �Լ�
    public void InventoryCheck()
    {
        isOpened = !isOpened;

        inventoryPanel.alpha = isOpened ? 1.0f : 0.0f;
        inventoryPanel.interactable = isOpened;
    }


    IEnumerator Fadein()
    {
        float fadeCount = 1.0f; //ó�� ���İ�
        while (fadeCount > 0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            bg_black.color = new Color(0, 0, 0, fadeCount);//�ش� ���������� ���İ� ����
        }
        bg_black.gameObject.SetActive(false);
    }
}


