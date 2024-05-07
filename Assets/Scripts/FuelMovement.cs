using UnityEngine;

public class FuelMovement : MonoBehaviour
{
    public float fuelSpeed;

    void Update()
    {
        transform.Translate(Vector3.down * fuelSpeed * Time.deltaTime);
    }
}
