using UnityEngine;

public class ConfusionBall : MonoBehaviour
{
    [SerializeField] private float speed;



    void Update()
    {

        transform.Translate(Vector2.down * speed * Time.deltaTime);


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("혼란 걸림!");
            Balrog.instance.ConfusionBalrog();
            Balrog.instance.GetDamage(Balrog.instance.maxHp / 20);
            Destroy(gameObject);
        }
    }
}
