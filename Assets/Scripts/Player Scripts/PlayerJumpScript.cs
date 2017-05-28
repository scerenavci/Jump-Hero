using UnityEngine;
using System.Collections;

public class PlayerJumpScript : MonoBehaviour
{


    public static PlayerJumpScript instance;

    private Rigidbody2D myBody;

    private Animator anim;

    private float forceX, forceY;

    private float thresholdx = 7f;

    private float thresholdY = 14f;

    private bool didJump, setPower;

    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    public void SetPower(bool setPower)
    {
        this.setPower = setPower;

        if (setPower)
            Debug.Log("We Are Settig The Power");
        else
            Debug.Log("We Are Not Settig The Power");


    }
}
