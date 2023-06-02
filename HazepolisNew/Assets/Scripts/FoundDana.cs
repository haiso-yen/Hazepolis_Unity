using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundDana : MonoBehaviour
{
    private SkeletonAnimation skeletonAnimation;
    BoxCollider2D boxCollider2;
    [SerializeField]
    bool completeTalk;
    bool su;
    // Start is called before the first frame update
    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        boxCollider2 = GetComponent<BoxCollider2D>();
        skeletonAnimation.state.SetAnimation(0, "sit", true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                completeTalk = true;
            }
            if (!su)
            {
                skeletonAnimation.state.SetAnimation(0, "su", false);
                su = true;
                skeletonAnimation.state.AddAnimation(0, "idle", true, 3);
                if (Input.GetKeyDown(KeyCode.T))
                {
                    completeTalk = true;
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                completeTalk = true;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            completeTalk = true;
        }
        if (other.CompareTag("Player") && completeTalk)
        {
            Eammon.instance.foundDan = true;
            Eammon.instance.KeyPassword = "foundDan";
            Destroy(gameObject);
        }
    }
}
