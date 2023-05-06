using Spine.Unity;
using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    private SkeletonAnimation skeletonAnimation;
    private int animationNum;
    private string stayAnimation;
    private bool isFlying;


    private void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        skeletonAnimation.state.SetAnimation(0, "stay2", false);
    }
    private void Update()
    {
        if (!isFlying)
        {
            animationNum = Random.Range(0, 100) % 2 + 1;
            stayAnimation = "stay" + animationNum.ToString();
            skeletonAnimation.state.AddAnimation(0, stayAnimation, false, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            skeletonAnimation.state.SetAnimation(0, "fly", false);
            isFlying = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
