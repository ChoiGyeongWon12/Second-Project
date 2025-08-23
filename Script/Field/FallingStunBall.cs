using UnityEngine;

public class FallingStunBall : MonoBehaviour
{
    [SerializeField] private float speed;



    void Start()
    {

    }

    void Update()
    {

        transform.Translate(Vector2.down * speed * Time.deltaTime);


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Balrog.instance.StunBalrog();
            Balrog.instance.GetDamage(Balrog.instance.maxHp / 20);
            Destroy(gameObject);
        }
    }



}
