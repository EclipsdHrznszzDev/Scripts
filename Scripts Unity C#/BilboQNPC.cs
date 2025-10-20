using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilboQNPC : questNPC
{
    void Start()
    {
       
        CreateStory();
        questName = "Find 12 cristals";
    }

    public override bool CheckSuccess()
    {
        return FindObjectOfType<PlayerMove>().GetCrystals() >= 12;
    }

    public override void CreateStory()
    {
        greet.Add("Good morning, Sir!");
        greet.Add("Welcome to the planet 700-46b. ");
        greet.Add("Did you see a strange door?");
        greet.Add("If you want to look behind the door I will need your help");
        greet.Add("I need 12 crystals to create the key for that door!");
        greet.Add("So, are you in?");

    }

    void Update()
    {
        if (isDialog)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                if (FindObjectOfType<QuestSystem>().GetFinishedQuests().Contains(questName))
                {
                    message.text = "You have the key already, goodbye.";

                }
                else if (FindObjectOfType<QuestSystem>().GetMyQuests().Contains(questName))
                {
                    message.text = greet[i];
                    if (CheckSuccess())
                    {
                        //questDone = true;
                        FindObjectOfType<QuestSystem>().FinishQuest(questName);
                        buttons.SetActive(false);
                        KEY.SetActive(true);
                        PORTAL.SetActive(true);
                        Image.SetActive(false);
                        Bigpointer.SetActive(true);
                        message.text = "Thanks you very much, now you have asset to the door";
                        FindObjectOfType<PlayerMove>().deleteCrystalls(12);
                        


                    }
                }
                else
                {
                    message.text = greet[i];
                    if (i < greet.Count - 1)
                    {
                        i++; // i = i +1; i += 1;
                    }
                    else
                    {

                        buttons.SetActive(true);
                        but1.onClick.RemoveAllListeners();
                        but2.onClick.RemoveAllListeners();
                        but1.onClick.AddListener(questTake);
                        but2.onClick.AddListener(questDisline);
                        Cursor.lockState = CursorLockMode.None;
                    }
                }
            }
        }
    }

    public override void questTake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<QuestSystem>().AddQuest(questName);
        buttons.SetActive(false);
        Image.SetActive(true);
        pointer.SetActive(false);
        //questIsTaken = true;
        message.text = "Great, now go!";
    }

    public override void questDisline()
    {
        Cursor.lockState = CursorLockMode.Locked;
        buttons.SetActive(false);
        Image.SetActive(false);
        message.text = "If you change your mind, you know where I am.";
    }
}