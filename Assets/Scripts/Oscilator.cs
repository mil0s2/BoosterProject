using UnityEngine;

public class Oscilator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; } // epsilon - smallest float number (not guaranteed that 0 is actualy 0)
        float cycles = Time.time / period; // number of cycles, continually growing over time

        const float tau = Mathf.PI * 2; // const value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        movementFactor = (rawSinWave + 1f) / 2; //making it go from 0 to 1 instead from -1 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
