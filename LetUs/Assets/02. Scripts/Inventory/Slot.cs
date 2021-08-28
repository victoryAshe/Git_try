using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int slotNum; // 슬롯의 번호 
    
    void Awake()
    {
        inventory = GameObject.Find("Panel - Inventory").GetComponent<Inventory>();
    }

    void Update()
    {
        if(transform.childCount == 0) // 슬롯에 아무것도 없을 때
        {
            inventory.fullCheck[slotNum] = false;
        }
    }

    public void putItem(GameObject item)
    {
        Instantiate(item, gameObject.transform.position, Quaternion.identity);
    }
}
