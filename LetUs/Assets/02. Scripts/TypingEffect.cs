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
            prologue_string1 = "나는 수도에 위치한 평범한 회사의 직원이었다. \n시끄러운 도시의 작은 톱니바퀴같은 인생… \n처음엔 내게도 나름의 열정이 있었던 것 같은데, \n회사 안에서 이런 저런 사건들을 겪으며 나는 너무 지쳐버렸다.";
            prologue_string2 = "계속 이렇게 살아야하는 건가? 싶을 때 즈음에, \n귀농이 유행한다는 말을 듣고 나는 조용한 시골에 이사 가기로 결심했다. \n그동안 모아둔 돈이라면 꽃가게 하나쯤은 차릴 수 있겠지… \n퇴직을 하고 이사 준비를 하다보니 어느새 가게를 오픈하는 날이 되었다. \n이왕 시골에 왔으니 동네 사람들하고 인사라도 해볼까?";

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
