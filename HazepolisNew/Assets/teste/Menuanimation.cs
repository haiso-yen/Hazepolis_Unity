using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Menuanimation : MonoBehaviour
{
    public RectTransform TitlePanel,Titlechoice,settingBanner,settingPanel, panelSwitchD,panelSwitchA;

    void Start()
    {
        TitlePanel.DOAnchorPos(new Vector2(-110, -30), 0.25f);
        Titlechoice.DOAnchorPos(new Vector2(-400, -300), 0.25f);

        settingPanel.DOAnchorPos(new Vector2(0, -308), 0.25f);
        settingBanner.DOAnchorPos(new Vector2(0, 85), 0.25f);
    }
    //¼È®É
    public void Titledissapear()
    {
        TitlePanel.DOAnchorPos(new Vector2(-500,-30), 0.25f);
        Titlechoice.DOAnchorPos(new Vector2(-650, -300), 0.25f);

        settingBanner.DOAnchorPos(new Vector2(0, 3), 0.25f);
        settingPanel.DOAnchorPos(new Vector2(0, -20), 0.2f);
        panelSwitchD.DOAnchorPos(new Vector2(-300, -165), 0.25f);
    }
    public void Titleappear()
    {
        TitlePanel.DOAnchorPos(new Vector2(-110, -30), 0.25f);
        Titlechoice.DOAnchorPos(new Vector2(-400, -300), 0.25f);

        settingBanner.DOAnchorPos(new Vector2(0, 85), 0.25f);
        settingPanel.DOAnchorPos(new Vector2(0, -308), 0.2f);
        panelSwitchD.DOAnchorPos(new Vector2(-386, -165), 0.25f);
    }
}