using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public enum TimeType { Game, DSP }

    public TimeType UseTimeType;
    public Clock Clock;
    public MovingNote NotePrefab;

    GameManager gameManager;

    public int BeatSpawnInterval;

    public float NoteSpawnDistance = 1;
    public float NoteSpawnSecondsAheadOfArrivalBeat = 1;
    private int BpmMemory = 1;
    private int RandomMemory = 0;

    public int nextSpawnBeat;

    [SerializeField] List<int> Intervals = new List<int>();

    private void Awake()
    {
        nextSpawnBeat = BeatSpawnInterval - 1;
        
    }

    private void Update()
    {
        if (BpmMemory != Clock.CurrentBeat())
        {
            //BpmMemory = Clock.CurrentBeat();
            int indexInterval = Random.Range(0, Intervals.Count);
            RandomMemory = Intervals[indexInterval];
            BeatSpawnInterval = RandomMemory;
            //RandomMemory = Random.Range(0, Intervals.Count - 1);
            /*if (RandomMemory < 1)
            {
                BeatSpawnInterval = 1;
            }
            else if (RandomMemory < 3)
            {
                BeatSpawnInterval = 2;
            }
            else if (RandomMemory < 6)
            {
                BeatSpawnInterval = 4;
            }
            else if (RandomMemory < 10)
            {
                BeatSpawnInterval = 2;
            }*/

        }

        float nextSpawnTime = (60f / Clock.BPM) * nextSpawnBeat;
        float currentTime = GetCurrentTime();

        if (Clock.SongPlaying())
        {
            if (currentTime > nextSpawnTime - NoteSpawnSecondsAheadOfArrivalBeat)
            {
                Vector3 position = transform.position - Vector3.back * NoteSpawnDistance;

                MovingNote note = Instantiate(NotePrefab, position, Quaternion.identity);
                note.Speed = NoteSpawnDistance / NoteSpawnSecondsAheadOfArrivalBeat;
               

                nextSpawnBeat += BeatSpawnInterval;
            }
        }
        else
        {
            // Invoke Stop Game after 5 seconds
        }

             
    }

    private float GetCurrentTime()
    {
        if (UseTimeType == TimeType.Game)
            return Clock.CurrentGameTime();
        else
            return Clock.CurrentTime();
    }
}
