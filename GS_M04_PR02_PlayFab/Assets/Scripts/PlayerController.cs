using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    private float startTime;
    private float timeTaken;

    private int collectablesPicked;
    public int maxCollectables = 10;

    private bool isPlaying;

    public GameObject playButton;
    public TextMeshProUGUI currTimeText;    public TextMeshProUGUI scoreTimeText;    private int totalScore = 0;    public TargetSpawner spawner;    public Leaderboard leaderBoard;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isPlaying)
            return;

        currTimeText.text = (Time.time - startTime).ToString("F2");

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if(spawner.numSpawned == spawner.maxNumberSpawned)
        {
            End();
        }

    }

    private void Shoot()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Outer"))
            {
                AddScore(10);
            }
            else if (hit.collider.CompareTag("Inner"))
            {
                AddScore(25);
            }
            else if (hit.collider.CompareTag("Center"))
            {
                AddScore(50);
            }
            spawner.SpawnNext();
            Destroy(hit.collider.transform.parent.gameObject);
        }
    }

    private void AddScore(int score)
    {
        totalScore += score;
        scoreTimeText.text = totalScore.ToString();
    }


    public void Begin()
    {
        playButton.SetActive(false);
        spawner.SpawnNext();
        startTime = Time.time;
        isPlaying = true;
    }

    void End()
    {
        timeTaken = Time.time - startTime;
        isPlaying = false;

        int finalScore = Mathf.RoundToInt(-totalScore * (1/timeTaken));

        leaderBoard.gameObject.SetActive(true);
        Leaderboard.instance.SetLeaderboardEntry(finalScore);
        //Leaderboard.instance.SetLeaderboardEntry(-Mathf.RoundToInt(timeTaken * 1000.0f));
    }

}
