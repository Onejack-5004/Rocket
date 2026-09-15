using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    [Header("Rocket")]
    public float force = 5f;

    [Header("Fuel")]
    public float maxFuel = 100f;
    public float currentFuel;
    public float fuelUseRate = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentFuel = maxFuel;
    }

    void Update()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard != null && keyboard.spaceKey.isPressed && currentFuel > 0)
        {
            // ทำให้จรวดบินขึ้น
            rb.AddForce(0.0f, force, 0.0f, ForceMode.Impulse);

            // ลดน้ำมัน
            currentFuel -= fuelUseRate * Time.deltaTime;

            // ป้องกันน้ำมันติดลบ
            if (currentFuel < 0)
            {
                currentFuel = 0;
            }
        }
    }
}