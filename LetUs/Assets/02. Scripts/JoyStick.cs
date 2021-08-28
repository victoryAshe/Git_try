using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform pad; // 패드
    public Transform player; // 플레이어
    Vector3 movePos; // 이동
    Vector3 rotaePos; // 회전
    public float moveSpeed; // 이동 속도
    public float rotateSpeed; // 회전 속도

    // 드래그하면 조이스틱 움직이기
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.localPosition = // 조이스틱 움직임 위치 제한
            Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.5f);
        
        // 조이스틱 움직일 때, 이동값 회전값 저장
        movePos = new Vector3(0, 0, transform.localPosition.y).normalized;
        rotaePos = new Vector3(0, transform.localPosition.x, 0).normalized;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 터치 안하면 원래 위치로 이동
        transform.localPosition = Vector3.zero;
        // 조이스틱 터치 안하면 이동값, 회전값 지우기
        movePos = Vector3.zero;
        rotaePos = Vector3.zero;
        StopCoroutine("playerMove");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 조이스틱 터치시 캐릭터 움직이기
        StartCoroutine("PlayerMove");
    }

    // 캐릭터 움직이기
    IEnumerator PlayerMove()
    {
        while(true)
        {
            player.Translate(movePos * moveSpeed * Time.deltaTime);

            if (Mathf.Abs(transform.localPosition.x) > pad.rect.width * 0.3f)
            {
                player.Rotate(rotaePos * rotateSpeed * Time.deltaTime); // 회전
            }

            yield return null;
        }
    }
}
