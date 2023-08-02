using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float CurrentTime { get; private set; }

    void Update()
    {
        CurrentTime += Time.deltaTime;
    }
}
