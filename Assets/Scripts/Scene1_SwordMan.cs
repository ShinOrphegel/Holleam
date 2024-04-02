using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1_SwordMan : PlayerController
{
    Scene1_Controller ctl;

    float xDirection;
    float yDirection;
    float moveSpeed = 5;
    bool alive;

/*    Vector3 xtrans = new Vector3(-5f, -2f, 0f);
    bool replay = false;*/
    // Start is called before the first frame update
    void Start()
    {
        m_CapsulleCollider = this.transform.GetComponent<CapsuleCollider2D>();
        m_Anim = this.transform.Find("model").GetComponent<Animator>();
        ctl = FindAnyObjectByType<Scene1_Controller>();
        alive = true;
/*        if (!replay)
        {
            replay = true;
        }
        else
        {
            Instantiate(this, xtrans, Quaternion.identity);
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ctl.getEnd() == 1)
        {
            return;
        }
        if(ctl.getEnd() == 2 && alive == true)
        {
            //m_Anim.Play("Die");
            alive = false;
            return;
        }
        else if(ctl.getEnd() == 2 && alive == false)
        {
            return;
        }

        checkInput();

        xDirection = Input.GetAxisRaw("Horizontal");
        yDirection = Input.GetAxisRaw("Vertical");
        //		Debug.Log(xDirection);
        float moveStepX = moveSpeed * xDirection * Time.deltaTime;
        transform.position = transform.position + new Vector3(moveStepX, 0, 0);
        float moveStepY = moveSpeed * yDirection * Time.deltaTime;
        transform.position = transform.position + new Vector3(0, moveStepY, 0);

        if ((transform.position.x <= -7.5 && xDirection < 0) || (transform.position.x >= 7.5 && xDirection > 0))
        {
            return;
        }

    }

    protected override void LandingEvent()
    {

        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Run") && !m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            if (alive)
            {
                m_Anim.Play("Idle");
            }
            
    }

    public void checkInput() {
        // animation Sit, test là chính vì scene này không cần sit
        if (Input.GetKeyDown(KeyCode.H))
        {
            IsSit = true;
            m_Anim.Play("Sit");
        }
        else if (Input.GetKeyUp(KeyCode.H))
        {
            if (alive)
            {
                m_Anim.Play("Idle");
            }
                

            IsSit = false;
        }
        // animation attack && attack trong lúc đi
        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")){
            if (Input.GetKey(KeyCode.Mouse0)){
                m_Anim.Play("Attack");
            }
            else
            {
                if ((xDirection != 0) || (yDirection != 0))
                {
                    m_Anim.Play("Run");
                }
                else
                {
                    if (alive)
                    {
                        m_Anim.Play("Idle");
                    }
                        
                }
            }
        }
        // animation Dead
        if (Input.GetKeyDown(KeyCode.V))
        {
            m_Anim.Play("Die");
        }
        //
        if (Input.GetKey(KeyCode.D))
        {
            //transform.transform.Translate(Vector2.right * xDirection * moveSpeed * Time.deltaTime);
            if (!Input.GetKey(KeyCode.A))
                Filp(false);
        }else if (Input.GetKey(KeyCode.A))
        {
            //transform.transform.Translate(Vector2.right * xDirection * moveSpeed * Time.deltaTime);
            if (!Input.GetKey(KeyCode.D))
                Filp(true);
        }
    }

}
