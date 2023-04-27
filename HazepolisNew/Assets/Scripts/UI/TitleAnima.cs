using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TitleAnima : MonoBehaviour
{   
    public RectTransform TitleMenuCanvas;

    void Start()
    {
        //標題畫面動畫
        TitleAnimation();
    }

    public void TitleAnimation()
    {
        //LeanTween.move(TitleMenuCanvas, new Vector3(48f, 0f, 0f), 1f).setDelay(.4f);
        LeanTween.alpha(TitleMenuCanvas, 2f, 5f).setFrom(0f).setDelay(.1f).setEase(LeanTweenType.easeOutQuad);

    }
}
