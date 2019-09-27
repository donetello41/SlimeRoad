using UnityEngine;

public class CreateRing : MonoBehaviour
{
   public GameObject ringPrefab;
    Vector3 ringPos;
    [System.Obsolete]
    void Start()
    {
        if (Random.RandomRange(1, 6) % 2 == 0)
        {
            Invoke("RandomCreateRing", 0.1f);
        }
    }
    [System.Obsolete]
    void  RandomCreateRing()
    {
        ringPos = new Vector3(transform.position.x+0.4f, transform.position.y + 1.7f, Random.RandomRange(-2.2f, 2.2f));
        GameObject childObject = Instantiate(ringPrefab, ringPos, Quaternion.identity) as GameObject;
        childObject.transform.parent = gameObject.transform;
    }

}
