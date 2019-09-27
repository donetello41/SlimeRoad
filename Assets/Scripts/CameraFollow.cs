using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    void Start()
    {
        offset = transform.position - player.position;
    }
    void LateUpdate()
    {
        Vector3 camPos = (player.position + offset);
        camPos = new Vector3(camPos.x, transform.position.y, transform.position.z);
        transform.position = camPos;
    }
}
