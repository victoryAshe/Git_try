using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    

    public bool[] fullCheck;
    public GameObject[] slots;
    private int emptySlotNum;
    private GameObject instItem;
    //private Slot slot;

    // Start is called before the first frame update
    void Awake()
    {

        fullCheck = new bool[8];
    }

    public GameObject PutItem(GameObject item) // 슬롯에 아이템을 넣음
    {
        for (int i = 0; i < fullCheck.Length; i++)
        {
            if(fullCheck[i] == false)
            {
                instItem = Instantiate(item, slots[i].transform.position, Quaternion.identity);
                instItem.transform.SetParent(slots[i].transform);
                fullCheck[i] = true;

                break;
            }
        }

        return instItem;
    }

    public void DelItem(GameObject currItem) // 슬롯에서 아이템을 지움
    {
        int currSlotNum = currItem.GetComponentInParent<Slot>().slotNum;
        fullCheck[currSlotNum] = false;
        for (int i = 0; i < fullCheck.Length; i++) // 빈 슬롯 찾기
        {
            if (fullCheck[i] == false)
            {
                emptySlotNum = i;
                break;
            }
        }

        for (int j = emptySlotNum + 1; j < fullCheck.Length; j++) // 빈 슬롯을 채우기 위해 뒤의 아이템을 앞 슬롯에 옮김
        {
            GameObject otherItem = slots[j].GetComponent<GameObject>();
            if (otherItem != null)
            {
                otherItem.transform.SetParent(slots[j - 1].transform);
                otherItem.transform.position = slots[j - 1].transform.position;
            }
        }

        Destroy(currItem);
    }
}
