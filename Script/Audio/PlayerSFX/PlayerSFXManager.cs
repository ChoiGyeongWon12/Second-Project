using UnityEngine;

public class PlayerSFXManager : MonoBehaviour
{

    AudioSource playerSFX;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip attack;
    [SerializeField] AudioClip tp;
    [SerializeField] AudioClip meteor;
    [SerializeField] AudioClip heal;
    [SerializeField] AudioClip hit;
    [SerializeField] AudioClip roar;

    void Awake()
    {
        playerSFX = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip clip) // 클립 실행
    {
        playerSFX.PlayOneShot(clip);
    }

    public void PlayerJump()
    {
        playerSFX.PlayOneShot(jump);
    }

    public void PlayerAttack()
    {
        playerSFX.PlayOneShot(attack);
    }

    public void PlayerTeleport()
    {
        playerSFX.PlayOneShot(tp);
    }

    public void PlayerMeteor()
    {
        playerSFX.PlayOneShot(meteor);
    }

    public void PlayerHeal()
    {
        playerSFX.PlayOneShot(heal);
    }

    public void PlayerHit()
    {
        playerSFX.PlayOneShot(hit);
    }

    public void PlayerRoar()
    {
        playerSFX.PlayOneShot(roar);
    }

}
