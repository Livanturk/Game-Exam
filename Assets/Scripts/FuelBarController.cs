using UnityEngine;
using UnityEngine.UI;

public class FuelBarController : MonoBehaviour
{
    public Slider fuelSlider;

    private float maxFuel;

    public void InitializeFuelBar(float startingFuel)
    {
        maxFuel = startingFuel;
        UpdateFuelBar(startingFuel);
    }

    public void UpdateFuelBar(float currentFuel)
    {
        fuelSlider.value = currentFuel / maxFuel;
    }
}

