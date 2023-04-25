using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnimationManager : MonoBehaviour
{
    public RectTransform popMission,buttonpanel;

    void Start()
    {
        popMission.DOAnchorPos(new Vector2(-730, 123), 0.25f);
    }
    //¼È®É
    public void backbutton()
    {
        popMission.DOAnchorPos(new Vector2(-730, 123), 0.25f);
    }
    public void appearbutton()
    {
        popMission.DOAnchorPos(new Vector2(-2000, 123), 0.25f);
    }
}
