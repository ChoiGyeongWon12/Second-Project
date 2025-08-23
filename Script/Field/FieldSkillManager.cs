using System.Collections;
using UnityEngine;

public class FieldSkillManager : MonoBehaviour
{
    public static FieldSkillManager instance;

    [SerializeField] GameObject prefabBall;
    [SerializeField] GameObject prefabStunBall;
    [SerializeField] GameObject prefabConfusionBall;
    [SerializeField] GameObject prefabChain;
    [SerializeField] GameObject prefabMainSkill;
    [SerializeField] GameObject image;
    [SerializeField] GameObject teleportPortal;
    [SerializeField] GameObject portalPlatform;
    float cancelTimer;


    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    void Start()
    {
        InvokeRepeating("FieldChainAppear", 5, 3.5f);
        StartCoroutine(FieldBallDropRoutine());
        StartCoroutine(MainSkillRoutine());
    }

    void FieldBallDrop()
    {
        float rndX = Random.Range(-6, 6f);
        float rndBall = Random.Range(1, 4);
        Vector2 spawnPos = new Vector2(rndX, transform.position.y);
        switch (rndBall)
        {
            case 1:
                GameObject ball = Instantiate(prefabBall, spawnPos, Quaternion.identity);
                Destroy(ball, 4f);
                break;
            case 2:
                GameObject stunBall = Instantiate(prefabStunBall, spawnPos, Quaternion.identity);
                Destroy(stunBall, 4f);
                break;
            case 3:
                GameObject confusionBall = Instantiate(prefabConfusionBall, spawnPos, Quaternion.identity);
                Destroy(confusionBall, 4f);
                break;

        }

    }
    public void StopFieldSkill()
    {
        StopAllCoroutines();
        CancelInvoke("FieldChainAppear");
    }

    IEnumerator FieldBallDropRoutine()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            FieldBallDrop();

            float waitTime = Random.Range(0.5f, 1f);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void FieldChainAppear()
    {
        float rndX = Random.Range(-5.5f, 5.5f);
        Vector2 spawnPos = new Vector2(rndX, transform.position.y - 5.5f);
        GameObject pre = Instantiate(prefabChain, spawnPos, Quaternion.identity);
    }

    void FieldMainSkillAppear()
    {
        Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y - 12.5f);
        GameObject pre = Instantiate(prefabMainSkill, spawnPos, Quaternion.identity);
    }

    IEnumerator MainSkillRoutine()
    {
        yield return new WaitForSeconds(27f);

        while (true)
        {
            ShowUIAndObject();
            yield return new WaitForSeconds(3f);
            FieldMainSkillAppear();

            yield return new WaitForSeconds(32f);
        }

    }

    void ShowUIAndObject()
    {
        image.SetActive(true);
        teleportPortal.SetActive(true);
        portalPlatform.SetActive(true);
        Invoke("HideUIAndObject", 3f);
        Invoke("HidePlatform", 12f);

    }

    void HideUIAndObject()
    {
        if (image != null)
        {
            image.SetActive(false);
        }
        if (teleportPortal != null)
        {
            teleportPortal.SetActive(false);
        }
    }

    void HidePlatform()
    {
        portalPlatform.SetActive(false);
    }



}
