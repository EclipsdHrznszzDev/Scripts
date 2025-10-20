using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkusQNPC : questNPC
{
    void Start()
    {
        CreateStory();
        questName = "Find the witcher";
    }

    public override bool CheckSuccess()
    {
        return FindObjectOfType<Witcher>();
    }

    public override void CreateStory()
    {
        greet.Add("Omg here is my hero, hello mr, I'am really pround that you can help me!");
        greet.Add("My name is Raia.");
        greet.Add("I need your help.");
        greet.Add("Can you save my child from this robots?.");
        greet.Add("I've lost him in this labyrinth.");
        greet.Add("Can you find him?.");
    }

    void Update()
    {
        if (isDialog)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (FindObjectOfType<QuestSystem>().GetFinishedQuests().Contains(questName))
                {
                    message.text = "Thank you for help, now I'm feeling gooder";
                }
                else if (FindObjectOfType<QuestSystem>().GetMyQuests().Contains(questName))
                {
                    message.text = greet[i];
                    if (CheckSuccess())
                    {
                        //questDone = true;
                        FindObjectOfType<QuestSystem>().FinishQuest(questName);
                        buttons.SetActive(false);
                        message.text = "Thank you've literally save me!";
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
        block.SetActive(false);
        //questIsTaken = true;
        message.text = "Thank you very much, I can't wait, go!";
    }

    public override void questDisline()
    {
        Cursor.lockState = CursorLockMode.Locked;
        buttons.SetActive(false);
        block.SetActive(true);
        message.text = "Oh no, my son,:( Are you sure that you don't want to help me?";
    }
}