using UnityEngine;

public class Portal : MonoBehaviour
{

    [SerializeField] GameObject portal;
    [SerializeField] GameObject guide;

    public string targetSceneName;

    void Awake()
    {
        if (portal != null)
            portal.SetActive(false);
    }


    public void AppearPortal()
    {
        BossStateMachine boss = FindAnyObjectByType<BossStateMachine>();
        Enemy enemy = FindAnyObjectByType<Enemy>();
        if (enemy == null && boss == null && !portal.activeSelf)
        {
            portal.SetActive(true);
            guide.SetActive(true);
        }

    }

    public string GetTargetSceneName()
    {
        return targetSceneName;
    }
}
