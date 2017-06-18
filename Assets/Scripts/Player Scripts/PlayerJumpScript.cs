using UnityEngine;
using System.Collections;

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
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

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
                forceY = 6.5f;
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
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        
        if (didJump) // we don't want to call that collision if we didn't jump previously
        {
            didJump = false;
            if (target.tag == "Platform")
            {
                if (GameManager.instance != null)
                {
                    GameManager.instance.CreateNewPlatformAndLLerp(target.transform.position.x);
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
