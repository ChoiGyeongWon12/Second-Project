using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeController : MonoBehaviour
{
    public static VolumeController instance;
    private Volume volume;
    private Vignette vignette;
    private ColorAdjustments colorAd;

    public bool isEffectActive = false;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        volume = GetComponent<Volume>();
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out colorAd);

        vignette.active = false;
        colorAd.active = false;
    }

    void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(Balrog.instance.transform.position);
        vignette.center.Override(new Vector2(viewPos.x, viewPos.y));

    }

    public void StartVolumeEffect()
    {
        if (!isEffectActive)
        {
            StartCoroutine(ActiveVolume());
        }
    }

    public IEnumerator ActiveVolume()
    {
        if (isEffectActive)
            yield break;

        isEffectActive = true;

        vignette.active = true;
        colorAd.active = true;
        Debug.Log("1");
        yield return new WaitForSeconds(2.5f);
        Debug.Log("2");
        vignette.active = false;
        colorAd.active = false;

        isEffectActive = false;
        Debug.Log("3");
    }
}
