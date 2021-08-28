using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform pad; // �е�
    public Transform player; // �÷��̾�
    Vector3 movePos; // �̵�
    Vector3 rotaePos; // ȸ��
    public float moveSpeed; // �̵� �ӵ�
    public float rotateSpeed; // ȸ�� �ӵ�

    // �巡���ϸ� ���̽�ƽ �����̱�
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.localPosition = // ���̽�ƽ ������ ��ġ ����
            Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.5f);
        
        // ���̽�ƽ ������ ��, �̵��� ȸ���� ����
        movePos = new Vector3(0, 0, transform.localPosition.y).normalized;
        rotaePos = new Vector3(0, transform.localPosition.x, 0).normalized;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // ��ġ ���ϸ� ���� ��ġ�� �̵�
        transform.localPosition = Vector3.zero;
        // ���̽�ƽ ��ġ ���ϸ� �̵���, ȸ���� �����
        movePos = Vector3.zero;
        rotaePos = Vector3.zero;
        StopCoroutine("playerMove");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // ���̽�ƽ ��ġ�� ĳ���� �����̱�
        StartCoroutine("PlayerMove");
    }

    // ĳ���� �����̱�
    IEnumerator PlayerMove()
    {
        while(true)
        {
            player.Translate(movePos * moveSpeed * Time.deltaTime);

            if (Mathf.Abs(transform.localPosition.x) > pad.rect.width * 0.3f)
            {
                player.Rotate(rotaePos * rotateSpeed * Time.deltaTime); // ȸ��
            }

            yield return null;
        }
    }
}
