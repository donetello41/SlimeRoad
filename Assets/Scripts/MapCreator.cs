using UnityEngine;
public class MapCreator : MonoBehaviour
{
    public GameObject darkGroundPart;
    public GameObject lightGroundPart;
    public Transform player;
    Vector3 lastBlockPos;
    float offset = 1.5f;
    bool changeWall;

    // Start is called before the first frame update
    void Start()
    {
        lastBlockPos = new Vector3(-10.5f, 0, 0);
        changeWall = true;
    }
    public void CreateGround()
    {
        InvokeRepeating("CreateGroundParts", 0.5f, Time.deltaTime);
    }

    void CreateGroundParts()
    {
        float distance = Vector3.Distance(lastBlockPos, player.position);
        float screenSize = Camera.main.orthographicSize * 2;
        if (distance > screenSize + 3) return;
        Vector3 newPos = Vector3.zero;
        newPos = new Vector3(lastBlockPos.x - offset, lastBlockPos.y, lastBlockPos.z);
        if (changeWall)
        {
            GameObject newLightGroundPart = Instantiate(lightGroundPart, newPos, Quaternion.identity);
            changeWall = !changeWall;
        }
        else
        {
            GameObject newDarkGroundPart = Instantiate(darkGroundPart, newPos, Quaternion.identity);
            changeWall = !changeWall;
        }
        lastBlockPos = newPos;
    }
}
