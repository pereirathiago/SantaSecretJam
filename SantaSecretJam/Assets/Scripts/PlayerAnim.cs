using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
    }

    #region
       
    void OnMove()
    {
        if(player.Direction.sqrMagnitude > 0)
        {
            if (player.Direction.y > 0)
            {
                anim.SetInteger("transition", 1);
            }
            if (player.Direction.y < 0)
            {
                anim.SetInteger("transition", 2);
            }
            if (player.Direction.x > 0 || player.Direction.x < 0)
            {
                anim.SetInteger("transition", 3);
            }
        }
        else
        {
            anim.SetInteger("transition", 0);   
        }

        if (player.Direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (player.Direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void OnRun()
    {
        if (player.IsRunning && player.Direction.sqrMagnitude > 0)
        {
            anim.SetInteger("transition", 2);
        }
    }

    #endregion
}