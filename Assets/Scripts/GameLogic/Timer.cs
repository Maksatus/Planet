using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeSecond;
    private void Update()
    {
        timeSecond += Time.deltaTime;
    }
}
