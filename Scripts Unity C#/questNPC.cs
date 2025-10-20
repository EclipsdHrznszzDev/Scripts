using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questNPC : MonoBehaviour
{
    protected List<string> greet = new List<string>();

    [SerializeField] protected GameObject dialog;
    [SerializeField] protected Text message;
    [SerializeField] protected Button but1;
    [SerializeField] protected Button but2;
    [SerializeField] protected GameObject buttons;
    [SerializeField] protected GameObject KEY;
    [SerializeField] protected GameObject PORTAL;
    [SerializeField] protected GameObject Image;
    [SerializeField] protected GameObject block;
    [SerializeField] protected GameObject pointer;
    [SerializeField] protected GameObject Bigpointer;

    protected string questName;
    protected bool isDialog = false;
    protected int i = 0;
    protected bool success = false;

    public virtual bool CheckSuccess()
    {
        return success;
    }

    public virtual void CreateStory()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dialog.SetActive(true);
            isDialog = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            message.text = "Press E";
            buttons.SetActive(false);
            dialog.SetActive(false);
            isDialog = false;
        }
    }

    public virtual void questTake()
    {

    }

    public virtual void questDisline()
    {

    }



    //protected bool questIsTaken = false;
    //protected bool questDone = false;
}