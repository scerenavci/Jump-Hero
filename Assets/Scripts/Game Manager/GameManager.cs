using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{


    public static GameManager instance;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject platform;

    private float minX = -2.5f, maxX = 2.5f, minY = -4.7f, maxY = -3.7f;


    void Awake()
    {
        MakeInstance();
        CreateInitialPlatforms();
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    void CreateInitialPlatforms()
    {
        Vector3 temp = new Vector3(Random.Range(minX, minX + 1.2f), Random.Range(minY,maxY), 0);

        //Quaternion.identity is going to set rotation -> 0, 0, 0

        Instantiate(platform, temp, Quaternion.identity); // Create a clone

        temp.y += 2f; //for position our player initially above the first platform

        Instantiate(player, temp, Quaternion.identity);

        temp = new Vector3(Random.Range(maxX, maxX - 1.2f), Random.Range(minY, maxY), 0);

        Instantiate(platform, temp, Quaternion.identity);

    } //CreateInitialPlatforms

} // GameManager



















