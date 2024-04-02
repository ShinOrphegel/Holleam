using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1_Wolf : MonoBehaviour
{
    // biến nhập từ unity
//    public Vector3 startPoint;
    public Vector3 endPoint;
    public float wolfMoveSpeed;
    public GameObject tornado;
    public GameObject tornado2;
    public GameObject redZone;
    public GameObject icicle;
    public Image HPBar;

    Scene1_SwordMan s1sm;
    Scene1_Controller sctl;

    //
    Vector3 smPosition;
    Vector3 wPosition;

    //Biến priavte
    float shootTime = 1;
    float st;
    float blitzTime = 3;
    float bt;
    int isRedZoneExist;
    Vector3 playerPosition;
    int phase2;
    float changePhase = 7;

    // Vật triệu hồi
    GameObject dong;
    GameObject tay;
    GameObject nam;
    GameObject bac;
    GameObject dongbac;
    GameObject dongnam;
    GameObject taybac;
    GameObject taynam;
    int shot8count1;
    int shot8count2;

    GameObject icicle1;
    GameObject icicle2;
    GameObject icicle3;
    GameObject icicle4;
    int ice1;

    // stat của sói
    float wolfMaxHP = 1000;
    float wolfCurrentHP;
    // Start is called before the first frame update
    void Start()
    {
        s1sm = FindObjectOfType<Scene1_SwordMan>();
        sctl = FindObjectOfType<Scene1_Controller>();
        st = shootTime;
        bt = blitzTime;
        isRedZoneExist = 0;
        wolfCurrentHP = wolfMaxHP;
        phase2 = 0;
        shot8count1 = 0;
        shot8count2 = 0;
        ice1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(sctl.getEnd() == 1)
        {
            Destroy(gameObject);
            return;
        }
        if(sctl.getEnd() == 2)
        {
            return;
        }



        smPosition = s1sm.transform.position;
        wPosition = this.transform.position;
        HPBar.fillAmount = wolfCurrentHP / wolfMaxHP;
        faceToPlayer();
        //wolfRun();
        //battle();
        if(wolfCurrentHP > (wolfMaxHP/2))
        {
            if(sctl.getMNP() == 0)
            {//      *************** phase 1: shoot ********************
                st -= Time.deltaTime * 1 / 2;
                if(st <= 0)
                {
                    Instantiate(tornado, this.transform.position, Quaternion.identity);
                    st = shootTime;
                }
            }
            else
            {//      *************** phase 1: gore *********************
                bt -= Time.deltaTime;
                if (bt <= 2 && isRedZoneExist == 0)
                {
                    Instantiate(redZone, s1sm.transform.position, Quaternion.identity);
                    isRedZoneExist = 1;
                    playerPosition = s1sm.transform.position;
                }
                if(bt <= 1)
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position, playerPosition, 0.2f);
                }
                if(bt <= 0)
                {
                    bt = blitzTime;
                    isRedZoneExist = 0;
                }
            }
        }
        else if ((wolfCurrentHP <= (wolfMaxHP/2)) && (phase2 == 0))
        {
            changePhase -= Time.deltaTime;
            if(changePhase >= 6)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(0,0,0), 0.15f);
            }else if(changePhase < 6 && changePhase >= 5 && shot8count1 == 0)
            {
                // shoot8 -1
                bac = Instantiate(tornado2, this.transform.position, Quaternion.identity);
                dong = Instantiate(tornado2, this.transform.position, Quaternion.identity);                
                nam = Instantiate(tornado2, this.transform.position, Quaternion.identity);                
                tay = Instantiate(tornado2, this.transform.position, Quaternion.identity);
                shot8count1 = 1;
                
            }else if(changePhase < 6 && changePhase >= 5 && shot8count1 == 1)
            {
                if(dong)
                    dong.transform.position += new Vector3(Time.deltaTime * 50, 0, 0);
                if(bac)
                    bac.transform.position += new Vector3(0, Time.deltaTime * 50, 0);
                if(tay)
                    tay.transform.position += new Vector3(-Time.deltaTime * 100, 0, 0);
                if(nam)
                    nam.transform.position += new Vector3(0, -Time.deltaTime * 50, 0);
            }
            else if(changePhase < 5 && changePhase >= 4 && shot8count2 == 0)
            {
                // shoot8 -2
                if (dong)
                    Destroy(dong);
                if(tay)
                    Destroy(tay);
                if(nam)
                    Destroy(nam);
                if(bac)
                    Destroy(bac);
                dongbac = Instantiate(tornado2, this.transform.position, Quaternion.identity);
                dongnam = Instantiate(tornado2, this.transform.position, Quaternion.identity);
                taynam = Instantiate(tornado2, this.transform.position, Quaternion.identity);
                taybac = Instantiate(tornado2, this.transform.position, Quaternion.identity);
                shot8count2 = 1;
            }
            else if (changePhase < 5 && changePhase >= 4 && shot8count2 == 1)
            {
                if(dongbac)
                    dongbac.transform.position += new Vector3(Time.deltaTime * 30, Time.deltaTime * 15, 0);
                if(dongnam)
                    dongnam.transform.position += new Vector3(Time.deltaTime * 30, -Time.deltaTime * 15, 0);
                if(taynam)
                    taynam.transform.position += new Vector3(-Time.deltaTime * 30, -Time.deltaTime * 15, 0);
                if(taybac)
                    taybac.transform.position += new Vector3(-Time.deltaTime * 30, Time.deltaTime * 15, 0);
            }
            else if(changePhase < 4 && changePhase >= 3)
            {
                if (dongbac)
                    Destroy(dongbac);
                if (dongnam)
                    Destroy(dongnam);
                if (taynam)
                    Destroy(taynam);
                if (taybac)
                    Destroy(taybac);
                this.transform.position = Vector3.MoveTowards(this.transform.position, endPoint, 0.15f);
            }else if(changePhase < 3 && changePhase >= 0 && ice1 == 0)
            {
                // goi tuyet
                icicle1 = Instantiate(icicle, new Vector3(-6.38f, 6, 0), Quaternion.identity);
                icicle2 = Instantiate(icicle, new Vector3(-2.9f, 6, 0), Quaternion.identity);
                icicle3 = Instantiate(icicle, new Vector3(0, 6, 0), Quaternion.identity);
                icicle4 = Instantiate(icicle, new Vector3(2.79f, 6, 0), Quaternion.identity);
                ice1 = 1;
            }
            else if (changePhase < 3 && changePhase >= 0 && ice1 == 1)
            {
                icicle1.transform.position = Vector3.MoveTowards(icicle1.transform.position, new Vector3(-6.38f, 2.5f), 0.2f);
                icicle2.transform.position = Vector3.MoveTowards(icicle2.transform.position, new Vector3(-2.9f, -1.72f), 0.2f);
                icicle3.transform.position = Vector3.MoveTowards(icicle3.transform.position, new Vector3(0, 2.06f), 0.2f);
                icicle4.transform.position = Vector3.MoveTowards(icicle4.transform.position, new Vector3(2.79f, -1.58f), 0.2f);
            }
            else
            {
                Destroy(icicle1); Destroy(icicle2); Destroy(icicle3); Destroy(icicle4);
                phase2 = 1;
            }
        }else if ((wolfCurrentHP <= (wolfMaxHP / 2)) && (phase2 == 1))
        {
            if (sctl.getMNP() == 0)
            {//      *************** phase 1: shoot ********************
                st -= Time.deltaTime * 1 / 2;
                if (st <= 0)
                {
                    Instantiate(tornado, this.transform.position, Quaternion.identity);
                    st = shootTime;
                }
            }
            else
            {//      *************** phase 1: gore *********************
                bt -= Time.deltaTime;
                if (bt <= 2 && isRedZoneExist == 0)
                {
                    Instantiate(redZone, s1sm.transform.position, Quaternion.identity);
                    isRedZoneExist = 1;
                    playerPosition = s1sm.transform.position;
                }
                if (bt <= 1)
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position, playerPosition, 0.2f);
                }
                if (bt <= 0)
                {
                    bt = blitzTime;
                    isRedZoneExist = 0;
                }
            }
        }
    }

    private void faceToPlayer() {
        if (smPosition.x < wPosition.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("sword"))
        {
            wolfCurrentHP -= 50;
            Debug.Log(wolfCurrentHP);
            Debug.Log("hihi");
            Debug.Log((wolfCurrentHP / wolfMaxHP));
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("c");
        }
    }

    public float getHP()
    {
        return wolfCurrentHP;
    }

    public void callStart()
    {
        Start();
    }





}
