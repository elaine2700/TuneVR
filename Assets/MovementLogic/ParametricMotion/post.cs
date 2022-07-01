using System.Collections;
using TMPro;
using UnityEngine;

public class ClockNewReally: MonoBehaviour
{
    public TextMeshProUGUI gameTime, dspTime, beat;
    public AudioClip song;

    public int BPM = 60;

    private float startingGameTime, startingDSPTime, startingOffset;

    private bool running;

    public enum TimeType { Game, DSP }

    public TimeType UseTimeType;
    public Clock Clock;
    public MovingNote NotePrefab;

    public int BeatSpawnInterval;

    public float NoteSpawnDistance = 1;
    public float NoteSpawnSecondsAheadOfArrivalBeat = 1;

    public int nextSpawnBeat;

    private void Awake()
    {
        nextSpawnBeat = BeatSpawnInterval - 1;
    }
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);

        running = true;

        startingGameTime = Time.time;
        startingDSPTime = (float)AudioSettings.dspTime;

        GetComponent<AudioSource>().clip = song;
        GetComponent<AudioSource>().Play();
    }

    private void Update()
    {
        float nextSpawnTime = (60f / Clock.BPM) * nextSpawnBeat;
        float currentTime = CurrentGameTime();

        if (currentTime > nextSpawnTime - NoteSpawnSecondsAheadOfArrivalBeat)
        {
            Vector3 position = transform.position - Vector3.back * NoteSpawnDistance;

            MovingNote note = Instantiate(NotePrefab, position, Quaternion.identity);
            note.Speed = NoteSpawnDistance / NoteSpawnSecondsAheadOfArrivalBeat;

            nextSpawnBeat += BeatSpawnInterval;
        }

        //float currentTime = CurrentGameTime();
        float currentDSPTime = CurrentTime();

        gameTime.text = $"Game: {currentTime:00.00}";
        dspTime.text = $"DSP: {currentDSPTime:00.00}";
        beat.text = $"Beat: {CurrentBeat()}";

        if (CurrentBeat() == 6)
        {

        }
    }

    private float GetCurrentTime()
    {
        if (UseTimeType == TimeType.Game)
            return Clock.CurrentGameTime();
        else
            return Clock.CurrentTime();
    }
    /// <summary>
    /// Current time synced with audio.
    /// </summary>
    /// <returns></returns>
    public float CurrentTime()
    {
        if (!running)
            return 0;

        return (float)AudioSettings.dspTime - startingDSPTime;
    }

    public float CurrentGameTime()
    {
        if (!running)
            return 0;

        return Time.time - startingGameTime + startingOffset;
    }

    public int CurrentBeat()
    {
        return Mathf.FloorToInt(CurrentTime() / (BPM / 60f)) + 1;
    }
}
