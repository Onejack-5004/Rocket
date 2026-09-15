using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public Vector3 offset = new Vector3(0f, 3f, -10f);

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}