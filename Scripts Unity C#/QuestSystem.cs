using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{

    List<string> MyQuests = new List<string>();

    List<string> FinishedQuests = new List<string>();

    public List<string> GetMyQuests()
    {
        return MyQuests;
    }

    public List<string> GetFinishedQuests()
    {
        return FinishedQuests;
    }

    public void AddQuest(string questName)
    {
        MyQuests.Add(questName);
    }

    public void FinishQuest(string questName)
    {
        FinishedQuests.Add(questName);
    }

}
