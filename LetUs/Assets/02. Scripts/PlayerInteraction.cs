using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject ScriptWindowCanvas;
    public GameObject GameManager;
    public GameObject Player;
    GameObject Npc1;
    GameObject Npc2;

   void Awake()
    {
        Npc1 = GameObject.Find("NPC_1");
        Npc2 = GameObject.Find("NPC_2");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Interaction()
    {
        if (Vector3.Distance(Player.transform.position, Npc1.transform.position) <= 10.0f)
        {
            TalkManager tManager = ScriptWindowCanvas.GetComponent<TalkManager>();
            tManager.ShowText(Npc1);
        }

        if (Vector3.Distance(Player.transform.position, Npc2.transform.position) <= 10.0f)
        {
            TalkManager tManager = ScriptWindowCanvas.GetComponent<TalkManager>();
            tManager.ShowText(Npc2);
        }

    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.name == "ToFlower")
        {
            SceneManager.LoadScene("Area_01");
            SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        }
        else if (coll.gameObject.name == "ToCliff")
        {
            if (Npc2.GetComponent<NPC_Ctrl>().isSucc == true)
            {
                SceneManager.LoadScene("Area_02");
                SceneManager.LoadScene("Player", LoadSceneMode.Additive);
            }
            SceneManager.LoadScene("Area_02");
            SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        }
        else if (coll.gameObject.name == "ToCave")
        {
            SceneManager.LoadScene("Area_03");
            SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        }
        else if (coll.gameObject.name == "FromCaveToCliff")
        {
            SceneManager.LoadScene("Area_02");
            SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        }
        else if (coll.gameObject.name == "moveSpace" || coll.gameObject.name == "ToVillage")
        {
            SceneManager.LoadScene("Village");
            SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "WoodBoat")
        {
            other.transform.SetParent(gameObject.transform);
            other.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 2.7f, gameObject.transform.position.z);
            other.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y -180, gameObject.transform.rotation.eulerAngles.z);
        }
    }
}
