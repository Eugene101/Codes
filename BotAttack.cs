using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAttack : BotStatePattern
{
    GameObject enemyBall;
    Transform enemyBallparent;
    Transform enemyBallposition;
    GameObject currentBall;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform childrens in transform.GetComponentsInChildren<Transform>())
        {
            if (childrens.name == "RightHand")
            {
                enemyBallparent = childrens;
                break;
            }
        }

        enemyBall = GameObject.Find("EnemyBall");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Attack()
    {
        GameObject enemyBallLoaded = Instantiate(enemyBall, enemyBallparent.position, Quaternion.identity);
        enemyBallLoaded.transform.parent = enemyBallparent;
        currentBall = enemyBallLoaded;
        anim.SetInteger("EnemyBehavoir", 5);
        Invoke("ThrowBall", 1.28f);
        //anim.SetInteger("EnemyBehavoir", 1);
    }

    void ThrowBall()
    {
        currentBall.transform.SetParent(null);
        // currentBall.AddComponent<Rigidbody>();
        //anim.SetInteger("EnemyBehavoir", -1);
        Invoke("Idle", 0.5f);
        //Idle();
    }
}
