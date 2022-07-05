using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Transform> spawners = new List<Transform>();
    [SerializeField] List<SongSettings> songSettingsList = new List<SongSettings>();
    [SerializeField] Clock clock;
    [SerializeField] Canvas mainMenu;
    [SerializeField] Canvas endMenu;
    [SerializeField] TextMeshProUGUI songNameField;
    [SerializeField] TextMeshProUGUI finalScoreField;

    ScoreManager scoreManager;

    public bool gameStarted = false;

    private void Start()
    {
        SetSpawnersActive(false);
        endMenu.gameObject.SetActive(false);
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        if (clock.isActiveAndEnabled)
        {
            if (!clock.SongPlaying() && gameStarted)
            {
                StopGame();
            }
        }
    }

    public void SetSpawnersActive(bool startSong)
    {
        foreach (Transform spawner in spawners)
        {
            spawner.gameObject.SetActive(startSong);
        }
        clock.gameObject.SetActive(startSong);

    }

    public void StartGame()
    {
        SetSpawnersActive(true);
        mainMenu.gameObject.SetActive(false);
    }

    private void StopGame()
    {
        gameStarted = false;
        Invoke(nameof(ShowEndMenu), 2f);
        SetSpawnersActive(false);
    }

    private void ShowEndMenu()
    {
        endMenu.gameObject.SetActive(true);
        finalScoreField.text = scoreManager.CurrentScore.ToString();
    }

    public void ChooseSong(int songNumber)
    {
        if(songNumber >= songSettingsList.Count)
        {
            Debug.LogError("Song Number out of range. Max number is 1");
        }
        clock.songSettings = songSettingsList[songNumber];
        songNameField.text = $"Song: {songSettingsList[songNumber].songName}";
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene("Design");
    }
}
