using System.Collections.Generic;
using UnityEngine;

public class PositionChanger : MonoBehaviour
{
    [SerializeField] List<Transform> soundPositions = new List<Transform>();
    [SerializeField] float secondsToChange = 5f;
    float timer = 0;
    int currentIndex = -1;

    private void Start()
    {
        NextPosition();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= secondsToChange)
        {
            NextPosition();
        }
    }


    private void NextPosition()
    {
        timer = 0f;
        currentIndex++;
        if(currentIndex >= soundPositions.Count)
        {
            currentIndex = 0;
        }
        transform.position = soundPositions[currentIndex].position;
        transform.rotation = soundPositions[currentIndex].rotation;
    }
}
