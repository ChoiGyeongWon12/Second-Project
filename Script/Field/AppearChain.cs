using UnityEngine;

public class AppearChain : MonoBehaviour
{

    private bool isPlayerTouching = false;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerTouching = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerTouching = false;
        }
    }

    public void ChainDamage()
    {
        if (isPlayerTouching)
            Balrog.instance.GetDamage(Balrog.instance.maxHp / 10);
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
