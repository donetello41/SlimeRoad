using UnityEngine;

public class BallController : MonoBehaviour
{

    float bounceSpeed = 1.5f;
    float bounceAmount = 2.0f;
    Vector3 touchPosition;
    private Camera cam;
    float forward;
    private float timer = 0.0f;
    void Start()
    {
        cam = Camera.main;
        forward = 0f;
    }

    void Update()
    {
        if (GameManager.Instance.isGameStarted == true)
            forward = -0.06f;

            timer += Time.fixedDeltaTime;
            float yPos = Bounce((timer * bounceSpeed) % 1) * bounceAmount;
            Vector3 newBallPos = new Vector3(transform.position.x + forward, yPos, transform.position.z);
            transform.position = newBallPos;

            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                touchPosition = Input.mousePosition;
                Vector3 currentPosition = cam.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, cam.nearClipPlane));
                if (currentPosition.z <= 2.2f && -2.2f <= currentPosition.z)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, currentPosition.z);
                }

            }
    }

    float Bounce(float t)
    {
        return Mathf.Sin(Mathf.Clamp01(t) * Mathf.PI);
    }

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ring")
        {
            GameManager.Instance.RestartGame();
        }
    }

}
