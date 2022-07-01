using System.Collections;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI gameTime, dspTime, beat;
    public AudioClip song;

    //public GameObject Something;
    public int BPM = 60;

    private float startingGameTime, startingDSPTime, startingOffset;

    private bool running;

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
        float currentTime = CurrentGameTime();
        float currentDSPTime = CurrentTime();

        gameTime.text = $"Game: {currentTime:00.00}";
        dspTime.text = $"DSP: {currentDSPTime:00.00}";
        beat.text = $"Beat: {CurrentBeat()}";

        //if (CurrentBeat() == 3)
        //{
        //    Something.GetComponent<Spawner>().BeatSpawnInterval = 1;
        //}
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
