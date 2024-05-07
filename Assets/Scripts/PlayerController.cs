using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Slider fuelSlider;
    [SerializeField] private float speed = 10f;
    private GameManager gameManager;

    public float maxFuel = 100f;
    public float fuelDecreaseRate = 5f;
    public float fuelIncreaseAmount = 20f;
    private float currentFuel;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        currentFuel = maxFuel;

        if (fuelSlider != null)
        {
            fuelSlider.maxValue = maxFuel;
            fuelSlider.value = maxFuel;
        }
        else
        {
            Debug.LogError("Fuel Slider reference is not set in the inspector!");
        }
    }

    private void Update()
    {
        PlayerMovement();
        UpdateFuel();
        UpdateFuelUI();
    }

    void PlayerMovement()
    {
        float xPosition = Input.GetAxis("Horizontal");
        float yPosition = Input.GetAxis("Vertical");
        Vector3 shipMovement = new Vector3(xPosition, yPosition, 0) * speed * Time.deltaTime;
        transform.Translate(shipMovement);
    }

    void UpdateFuel()
    {
        currentFuel -= fuelDecreaseRate * Time.deltaTime;

        if (currentFuel <= 0)
        {
            if (gameManager != null)
            {
                gameManager.ShowGameOverMenu();
            }
            else
            {
                Debug.LogError("GameManager reference is null.");
            }
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }

    void UpdateFuelUI()
    {
        if (fuelSlider != null)
        {
            fuelSlider.value = currentFuel;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (gameManager != null)
            {
                gameManager.ShowGameOverMenu();
            }
            else
            {
                Debug.LogError("GameManager reference is null.");
            }
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fuel")
        {
            currentFuel = Mathf.Min(maxFuel, currentFuel + fuelIncreaseAmount);
            Destroy(collision.gameObject);
            UpdateFuelUI();
        }
    }
}

