using System.Threading;
using UnityEngine;

public class ThreadSleeper : MonoBehaviour
{
    public int Duration = 100;
    public bool Sleep;

    private void Update()
    {
        if (Sleep)
        {
            Sleep = false;

            Thread.Sleep(Duration);
        }
    }
}
