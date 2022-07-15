using System.Collections;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI gameTime, dspTime, beat;
    public AudioClip song;

    public SongSettings songSettings;

    GameManager gameManager;
    //public GameObject Something;
    public int BPM = 60;

    private float startingGameTime, startingDSPTime, startingOffset;

    public bool running;

    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
        song = songSettings.song;
        BPM = songSettings.BMP;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);

        running = true;

        startingGameTime = Time.time;
        startingDSPTime = (float)AudioSettings.dspTime;

        // set song and play
        GetComponent<AudioSource>().clip = song;
        GetComponent<AudioSource>().Play();
        gameManager.gameStarted = true;
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
        return Mathf.FloorToInt(CurrentTime() / (60f / BPM)) + 1;
    }

    public bool SongPlaying()
    {
        bool songPlaying = GetComponent<AudioSource>().isPlaying;
        if (!songPlaying)
            running = false;
        return songPlaying;
    }
}
