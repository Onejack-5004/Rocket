using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Slider fuelSlider;

    public PlayerController player;

    void Update()
    {
        fuelSlider.maxValue = player.maxFuel;
        fuelSlider.value = player.currentFuel;
    }
}