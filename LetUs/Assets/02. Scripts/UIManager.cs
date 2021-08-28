using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    private UnityAction action;

    void Start()
    {
        action = () => OnStartClick();
        startButton.onClick.AddListener(action);

        action = () => OnQuitClick();
        quitButton.onClick.AddListener(action);

        

    }

    void Update()
    {
        //���� play��� �׽�Ʈ�ϱ� ���� hotkey.
        if (Input.GetKeyDown("f"))
        {
            SceneManager.LoadScene("Village");
            SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        }
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene("Prologue");

    }

    public void OnQuitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }
}
