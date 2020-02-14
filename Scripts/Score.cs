using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public delegate void Milestone(float distance);
    public static event Milestone OnMilestone;

    public delegate void FinishLevel();
    public static event FinishLevel OnFinishLevel;

    public delegate void MidwayPoint();
    public static event MidwayPoint OnMidwayPoint;

    //Reference player position and text to update
    public Transform player;
    public Text scoreText;
    public float milestoneIncrement = 150f;
    public float levelFinishDistance = 1500;
    Animator animator;

    private void OnEnable()
    {
        OnMidwayPoint += flashText;
        animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        OnMidwayPoint -= flashText;
    }

    //Update called once per frame
    void Update()
    {
        //Update text with player position whole number
        scoreText.text = player.position.z.ToString("0");

        if (player.position.z >= levelFinishDistance)
        {
            OnFinishLevel();
        }

        if (player.position.z >= milestoneIncrement)
        {
            OnMilestone(milestoneIncrement);
            milestoneIncrement *= 3;
        }

        if (player.position.z >= levelFinishDistance / 2)
        {
            OnMidwayPoint();
        }
    }

    //I get that I don't need to do this here, but its just
    //a demo of the observer pattern
    void flashText()
    {
        animator.SetBool("Flash", true);
    }

    public void StopFlashing()
    {
        animator.SetBool("Flash", false);
    }
}