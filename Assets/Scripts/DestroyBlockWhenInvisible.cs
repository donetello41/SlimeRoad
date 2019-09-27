using UnityEngine;

public class DestroyBlockWhenInvisible : MonoBehaviour
{

    Transform player;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    void Update()
    {

        if (transform.position.x < player.position.x) return;

        float distance = Vector3.Distance(player.position, transform.position);
        if (distance > Camera.main.orthographicSize * 2)
        {
            Destroy(gameObject);
        }
    }
}