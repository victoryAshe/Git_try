using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotKey : MonoBehaviour
{
    //�ʿ��� �� hotKey ���� �� ��.

    void Start()
    {

    }

    void Update()
    {
        //if "a"pressed, questIndex++
        if (Input.GetKeyDown("a"))
        {
            QuestManager questManager = this.gameObject.GetComponent<QuestManager>();
            questManager.questIndex++;
        }
    }
}
