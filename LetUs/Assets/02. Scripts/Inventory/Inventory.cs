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

    public GameObject PutItem(GameObject item) // ���Կ� �������� ����
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

    public void DelItem(GameObject currItem) // ���Կ��� �������� ����
    {
        int currSlotNum = currItem.GetComponentInParent<Slot>().slotNum;
        fullCheck[currSlotNum] = false;
        for (int i = 0; i < fullCheck.Length; i++) // �� ���� ã��
        {
            if (fullCheck[i] == false)
            {
                emptySlotNum = i;
                break;
            }
        }

        for (int j = emptySlotNum + 1; j < fullCheck.Length; j++) // �� ������ ä��� ���� ���� �������� �� ���Կ� �ű�
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
