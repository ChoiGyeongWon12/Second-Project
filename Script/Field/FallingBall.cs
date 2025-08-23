using UnityEngine;

public class FallingBall : MonoBehaviour
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
            if (VolumeController.instance != null)
            {
                VolumeController.instance.StartVolumeEffect();
            }

            Balrog.instance.GetDamage(Balrog.instance.maxHp / 20);
            Destroy(gameObject);
        }
    }

}
