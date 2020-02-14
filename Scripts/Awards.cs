using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Awards : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void OnEnable()
    {
        Score.OnMilestone += GiveAward;
        animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        Score.OnMilestone -= GiveAward;
    }

    void GiveAward(float distance)
    {
        GetComponent<Text>().text = "Milestone: " + distance + " meters!";
        animator.SetBool("reachMilestone", true);
    }

    //This function is only called at the end of an animation
    public void ResetAnimation()
    {
        animator.SetBool("reachMilestone", false);
    }
}
