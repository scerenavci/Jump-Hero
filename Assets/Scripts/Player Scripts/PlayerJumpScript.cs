using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerJumpScript : MonoBehaviour
{


    public static PlayerJumpScript instance;

    private Rigidbody2D myBody;

    private Animator anim;

    [SerializeField]

    private float forceX, forceY;

    private float thresholdX = 7f;

    private float thresholdY = 14f;

    private bool didJump, setPower;

    private Slider PowerBar;
    private float PowerBarTreshold = 10f;
    private float PowerBarValue = 0f;

    void Awake()
    {
        MakeInstance();
        Initialize();
    }

    void Update()
    {
        SetPower(); //Because we want to set this each frame
    }

    void Initialize()
    {
        PowerBar = GameObject.Find("Power Bar").GetComponent<Slider>();
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        PowerBar.minValue = 0f;
        PowerBar.maxValue = 10f;
        PowerBar.value = PowerBarValue;

    }
    void MakeInstance()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    public void SetPower()
    {

        if (setPower)
        {
            forceX += thresholdX * Time.deltaTime;
            forceY += thresholdY * Time.deltaTime;

            if (forceX > 6.5f)
                forceX = 6.5f;
            if (forceY > 13.5f)
                forceY = 13.5f;

            PowerBarValue += PowerBarTreshold * Time.deltaTime;
            PowerBar.value = PowerBarValue;
        }
        else
            Debug.Log("We Are Not Settig The Power");

        

    }

    public void SetPower(bool setPower)
    {
        this.setPower = setPower;

        if (!setPower)
        {
            Jump();
        }
    }

    void Jump()
    {
        myBody.velocity = new Vector2(forceX, forceY);
        forceX = forceY = 0f;
        didJump = true;

        anim.SetBool("Jump", didJump);

        PowerBarValue = 0f;
        PowerBar.value = PowerBarValue;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        
        if (didJump) // we don't want to call that collision if we didn't jump previously
        {
            didJump = false;

            anim.SetBool("Jump", didJump);

            if (target.tag == "Platform")
            {
                if (GameManager.instance != null)
                {
                    GameManager.instance.CreateNewPlatformAndLLerp(target.transform.position.x);
                    target.tag = "Jumped";
                }
                if (ScoreManager.instance != null)
                {
                    ScoreManager.instance.IncrementScore();
                }
            }
         
        }

        if (target.tag == "Dead")
        {
            if (GameOverManager.instance != null)
            {
                GameOverManager.instance.GameOverShowPanel();
                Destroy(gameObject);
            }
        }
    }
}
