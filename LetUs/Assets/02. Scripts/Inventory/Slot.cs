using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int slotNum; // ������ ��ȣ 
    
    void Awake()
    {
        inventory = GameObject.Find("Panel - Inventory").GetComponent<Inventory>();
    }

    void Update()
    {
        if(transform.childCount == 0) // ���Կ� �ƹ��͵� ���� ��
        {
            inventory.fullCheck[slotNum] = false;
        }
    }

    public void putItem(GameObject item)
    {
        Instantiate(item, gameObject.transform.position, Quaternion.identity);
    }
}
