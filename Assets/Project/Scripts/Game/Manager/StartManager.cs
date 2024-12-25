using UnityEngine;

public class StartManager : MonoBehaviour
{
    void Awake()
    {
        Physics2D.simulationMode = SimulationMode2D.Update;
    }
}
