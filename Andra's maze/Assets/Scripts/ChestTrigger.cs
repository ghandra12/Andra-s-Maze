using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

public class ChestTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject endOfGameCamera;
    public GameObject endOfGameText;
    DateTime startTime;
    public TimeSpan timeElapsed { get; private set; }
    public int leaderboardSize = 5;
    // Start is called before the first frame update

    void Start()
    {
        startTime = DateTime.Now;
        player = GameObject.FindWithTag("Player");
        endOfGameCamera = GameObject.FindWithTag("EndOfGameCamera");
        endOfGameText = GameObject.FindWithTag("EndText");
    }

    // Update is called once per frame
    void Update()
    {
        this.timeElapsed = DateTime.Now - startTime;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.SetActive(false);

            endOfGameText.GetComponent<TMP_Text>().text += $"\nScore: {(int)timeElapsed.TotalSeconds}";

            DisplayLeaderBoard();

            endOfGameCamera.GetComponent<Camera>().enabled = true;
            endOfGameText.GetComponent<TMP_Text>().enabled = true;
        }
    }

    void DisplayLeaderBoard()
    {
        var leaderBoard = new Dictionary<string, int>();

        if (File.Exists("leaderboard.txt"))
        {
            using (var fileStream = File.OpenRead("leaderboard.txt"))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (!String.IsNullOrEmpty(line))
                    {
                        var parts = line.Split(' ');
                        var score = parts.LastOrDefault();
                        var name = string.Join(" ", parts.Take(parts.Length - 1));
                        leaderBoard.Add(name, int.Parse(score));
                    }
                }
            }
        }

        var playerName = "";

        if (File.Exists("temp.txt"))
        {
            using (var fileStream = File.OpenRead("temp.txt"))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
            {
                playerName = streamReader.ReadLine();
            }
        }

        if (leaderBoard.ContainsKey(playerName))
            leaderBoard[playerName] = (int)this.timeElapsed.TotalSeconds;
        else 
        leaderBoard.Add(playerName, (int)this.timeElapsed.TotalSeconds);

        using (FileStream fs = new FileStream("leaderboard.txt", FileMode.OpenOrCreate))
        {
            using (StreamWriter w = new StreamWriter(fs))
            {
                foreach(var lb in leaderBoard.OrderBy(l => l.Value))
                {
                    w.WriteLine($"{lb.Key} {lb.Value}");
                }
            }
        }

        int c = 1;

        endOfGameText.GetComponent<TMP_Text>().text += "\n\n";

        foreach (var lb in leaderBoard.OrderBy(l => l.Value))
        {
            endOfGameText.GetComponent<TMP_Text>().text += $"{c}. {lb.Key} {lb.Value}\n";
            c++;
            if (c-1 == leaderboardSize)
                break;
        }
    }
}
