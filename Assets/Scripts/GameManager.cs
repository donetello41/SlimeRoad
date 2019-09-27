using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isGameStarted = false;
    float elapsedTime = 3;
    public GameObject button;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Update()
    {
        elapsedTime -= Time.deltaTime;

       if (elapsedTime > 0)
            Debug.Log("bekle");
       else
       {
            StartGame();
       }
    }
    private void StartGame()
    {
        isGameStarted = true;
        FindObjectOfType<MapCreator>().CreateGround();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
