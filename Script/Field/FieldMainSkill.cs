using UnityEngine;

public class FieldMainSkill : MonoBehaviour
{
    [SerializeField] float skillTimer;
    int fieldCombo;
    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        skillTimer += Time.deltaTime;

        FieldSkillComobo();

        if (fieldCombo == 2)
        {
            fieldCombo = 0;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Balrog.instance.GetDamage(999999);
        }
    }

    public void FieldSkillComobo()
    {
        if (skillTimer > 4f)
        {
            anim.SetInteger("FieldSkillCombo", fieldCombo);
            fieldCombo++;
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
