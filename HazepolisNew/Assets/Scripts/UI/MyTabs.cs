using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyTabs : MonoBehaviour
{

    public GameObject tabBtn1;
    public GameObject tabBtn2;
    public GameObject tabBtn3;
    public GameObject tabBtn4;

    public GameObject tabCont1;
    public GameObject tabCont2;
    public GameObject tabCont3;
    public GameObject tabCont4;
    public void HideAllTabs()
    {
        tabCont1.SetActive(false);
        tabCont2.SetActive(false);
        tabCont3.SetActive(false);
        tabCont4.SetActive(false);

        //tabBtn1.GetComponent<Button>().image.color = new Color32(212, 212, 212, 255);
        //tabBtn2.GetComponent<Button>().image.color = new Color32(212, 212, 212, 255);
        //tabBtn3.GetComponent<Button>().image.color = new Color32(212, 212, 212, 255);
    }

    public void ShowTab1()
    {
        HideAllTabs();
        tabCont1.SetActive(true);
        //tabBtn1.GetComponent<Button>().image.color = new Color32(255, 255, 255, 255);
    }

    public void ShowTab2()
    {
        HideAllTabs();
        tabCont2.SetActive(true);
        //tabBtn2.GetComponent<Button>().image.color = new Color32(255, 255, 255, 255);
    }

    public void ShowTab3()
    {
        HideAllTabs();
        tabCont3.SetActive(true);
        //tabBtn3.GetComponent<Button>().image.color = new Color32(255, 255, 255, 255);
    }   
    public void ShowTab4()
    {
        HideAllTabs();
        tabCont4.SetActive(true);
        //tabBtn4.GetComponent<Button>().image.color = new Color32(255, 255, 255, 255);
    }
}