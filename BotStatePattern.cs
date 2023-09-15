using UnityEngine;


public class BotStatePattern : MonoBehaviour
{
    enum State
    {
        idle, attack, dodge, move, struggling
    };
    State state;
    public Animator anim;
    MovingBots movingBots;
    BotAttack botAttack;
    BotJumping botJumping;
    bool amIJumping;
    void Start()
    {
        movingBots = GetComponent<MovingBots>();
        botJumping = GetComponent<BotJumping>();
        botAttack = GetComponent<BotAttack>();
        anim = GetComponent<Animator>();
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        //anim = GetComponent<Animator>();
        Idle();
    }

    // Update is called once per frame
    public void ChangeState()
    {
        int rnd = Random.Range(0, 10);
        if (rnd < 5)
        {
            state = State.move;
        }
        else
        {
            state = State.attack;
        }
        EnemyState();
    }

    void EnemyState()
    {
        switch (state)
        {
            case State.idle:              
                break;

            case State.attack: 
                botAttack = GetComponent<BotAttack>();
                botAttack.Attack();
                break;            
            case State.move: 

                movingBots = GetComponent<MovingBots>();
                movingBots.SetRandomDestination();
                break;
            case State.struggling: //4
                break;
        }
    }

    public void Idle()
    {
        state = State.idle;
        Debug.Log("Idle");
        anim.SetInteger("EnemyBehavoir", -1);
        Invoke("ChangeState", 2f);
    }

    public void Jump()
    {
        int iWantToJump = Random.Range(0, 10);

        if (iWantToJump > 3)
        {
            state = State.dodge;
            botJumping.SelectSide();
        }

        else
        {
            Idle();
        }
    }


}
