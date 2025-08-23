using UnityEngine;

public class TeleportPos : MonoBehaviour
{
    public static TeleportPos instance;

    public GameObject portal;


    private void Awake()
    {
        instance = this;
    }

    public Vector3 PortalSetPos()
    {
        return portal.transform.position;

    }


}
