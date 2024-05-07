using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject fuelPrefab;
    public float minCreateEnemyValue;
    public float maxCreateEnemyValue;
    public float EnemyDestroyTime = 3f;
    public float minSpawnFuelInterval;
    public float maxSpawnFueInterval;
    public float fuelDestroyTime = 5f;

    [Header("Panels")]
    public GameObject StartMenu;
    public GameObject PauseMenu;
    public GameObject GameOverMenu;



    private void Start()
    {
        StartMenu.SetActive(true);
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(true);
        }

    }

    void CreateEnemy()
    {
        Vector3 enemyPosition = new Vector3(Random.Range(minCreateEnemyValue, maxCreateEnemyValue),12f);
        GameObject enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.Euler(0f,0f,180f));
        Destroy(enemy, EnemyDestroyTime);
    }

    void SpawnFuel()
    {
        Debug.Log("Spawning fuel...");
        Vector3 fuelPosition = new Vector3(Random.Range(minCreateEnemyValue, maxCreateEnemyValue), 12f);
        Debug.Log("Fuel position: " + fuelPosition);
        GameObject fuel = Instantiate(fuelPrefab, fuelPosition, Quaternion.identity);
        Destroy(fuel, fuelDestroyTime);
    }

    public void startGameButton()
    {
        StartMenu.SetActive(false);
        Time.timeScale = 1f;
        InvokeRepeating("CreateEnemy", 1f, 1f);
        InvokeRepeating("SpawnFuel", 5f, 5f);
    }
    public void PauseGame(bool isPaused)
    {
        if (isPaused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f; 
        }
        else
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void QuitGame()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }

    public void ShowGameOverMenu()
    {
        GameOverMenu.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

