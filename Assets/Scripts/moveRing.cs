using UnityEngine;

public class moveRing : MonoBehaviour
{

    float dir;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.z < 0f)
        {
            dir = 0.08f;
        }
        else if (transform.position.z > 0f)
        {
            dir = -0.08f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, dir * Time.deltaTime);
        if (transform.position.z < -2f)
        {
            dir = -dir;
            
        }
        else if (transform.position.z > 2f)
        {
            dir = -dir;
        }
    }
}
