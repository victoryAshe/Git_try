using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotKey : MonoBehaviour
{
    //필요할 때 hotKey 만들어서 쓸 것.

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
