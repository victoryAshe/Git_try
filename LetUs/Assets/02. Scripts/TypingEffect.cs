using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class TypingEffect : MonoBehaviour
{
    
    public GameObject prologueCanvas;
    public Text prologueText;
    private string prologue_string1;
    private string prologue_string2;

    public GameObject nextButton;
    public Button NextButton;
    private UnityAction action;

    bool check = false;

    void Awake()
    {
        


    }

    void Start()
    {
            prologue_string1 = "���� ������ ��ġ�� ����� ȸ���� �����̾���. \n�ò����� ������ ���� ��Ϲ������� �λ��� \nó���� ���Ե� ������ ������ �־��� �� ������, \nȸ�� �ȿ��� �̷� ���� ��ǵ��� ������ ���� �ʹ� ���Ĺ��ȴ�.";
            prologue_string2 = "��� �̷��� ��ƾ��ϴ� �ǰ�? ���� �� ������, \n�ͳ��� �����Ѵٴ� ���� ��� ���� ������ �ð� �̻� ����� ����ߴ�. \n�׵��� ��Ƶ� ���̶�� �ɰ��� �ϳ����� ���� �� �ְ����� \n������ �ϰ� �̻� �غ� �ϴٺ��� ����� ���Ը� �����ϴ� ���� �Ǿ���. \n�̿� �ð� ������ ���� ������ϰ� �λ�� �غ���?";

            StartCoroutine("_typing1");







    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            check = true;
        }

    }
    IEnumerator _typing1()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i <= prologue_string1.Length; i++)
        {
            if (check == false)
            {
                prologueText.text = prologue_string1.Substring(0, i);
                yield return new WaitForSeconds(0.03f);


            }
            else
            {
                prologueText.text = prologue_string1;
                check = false;
                prologueText.text = null;
                StartCoroutine("_typing2");

                yield break;
            }

        }
        yield return new WaitForSeconds(1.5f);

        prologueText.text = null;
        StartCoroutine("_typing2");
        
        yield break;
    }

    IEnumerator _typing2()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i <= prologue_string2.Length; i++)
        {
            if (check == false)
            {
                prologueText.text = prologue_string2.Substring(0, i);
                yield return new WaitForSeconds(0.03f);


            }
            else
            {
                prologueText.text = prologue_string2;
                check = false;
                nextButton.SetActive(true);

                action = () => OnNextButtonClick();
                NextButton.onClick.AddListener(action);

                yield break;
            }

        }


        nextButton.SetActive(true);

        action = () => OnNextButtonClick();
        NextButton.onClick.AddListener(action);
        yield break;
    }

    public void OnNextButtonClick()
    {
        SceneManager.LoadScene("Village");
        SceneManager.LoadScene("Player", LoadSceneMode.Additive);
    }

}
