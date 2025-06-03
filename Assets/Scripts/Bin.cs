using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class Bin : MonoBehaviour
{
    public BookGenerator bookGenerator;
    public BananaSpawner bananaSpawner;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource addSound;
    [SerializeField] private AudioSource clearSound;

    private TextMeshProUGUI scoreText;

    public List<GameObject> books = new List<GameObject>();

    private void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Book"))
        { 
            AddBook(other.gameObject);
        }
    }

    private void AddBook(GameObject book)
    {
        addSound.Play();
        books.Add(book);
        book.GetComponent<DragAndDroppable>().Lock();
        bookGenerator.RemoveBook(book);
        if (books.Count >= 4) 
        {
            ScoreContents();
        }
    }

    private void ScoreContents()
    {
        clearSound.Play();

        int[][] tracker = new int[3][];
        tracker[0] = new int[4]; // genre
        tracker[1] = new int[8]; // numbers
        tracker[2] = new int[4]; // colors

        foreach (GameObject b in books) 
        {
            BookData bd = b.GetComponent<BookData>();
            
            switch (bd.genre)
            {
                case (BookData.Genre.SciFi):
                    tracker[0][0] += 1;
                    break;
                case (BookData.Genre.Fantasy):
                    tracker[0][1] += 1;
                    break;
                case (BookData.Genre.Biography):
                    tracker[0][2]+= 1;
                    break;
                case (BookData.Genre.History):
                    tracker[0][3] += 1;
                    break;
            }

            switch (bd.number)
            {
                case (BookData.Number.One):
                    tracker[1][0] += 1;
                    break;
                case (BookData.Number.Two):
                    tracker[1][1] += 1;
                    break;
                case (BookData.Number.Three):
                    tracker[1][2] += 1;
                    break;
                case (BookData.Number.Four):
                    tracker[1][3] += 1;
                    break;
                case (BookData.Number.Five):
                    tracker[1][4] += 1;
                    break;
                case (BookData.Number.Six):
                    tracker[1][5] += 1;
                    break;
                case (BookData.Number.Seven):
                    tracker[1][6] += 1;
                    break;
                case (BookData.Number.Eight):
                    tracker[1][7] += 1;
                    break;
            }


            switch (bd.color)
            {
                case (BookData.Colors.Red):
                    tracker[2][0] += 1;
                    break;
                case (BookData.Colors.Orange):
                    tracker[2][1] += 1;
                    break;
                case (BookData.Colors.Green):
                    tracker[2][2] += 1;
                    break;
                case (BookData.Colors.Blue):
                    tracker[2][3] += 1;
                    break;
            }
        }

        int score = 0;
        for (int i = 0; i < tracker.Length;  i++)
        {
            int[] a = tracker[i];
            for (int j = 0; j < a.Length; j++)
            {
                int val = a[j];
                score += val * val;
            }
        }

        StartCoroutine(ClearBooks());
        UpdateScore(score);
    }

    private void UpdateScore(int score)
    {
        bananaSpawner.StartSpawningBananas(score);
        score += int.Parse(scoreText.text);
        scoreText.text = score.ToString("D3");
    }

    private IEnumerator ClearBooks()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (GameObject bd in books)
        {
            Destroy(bd); // you get an error if you move a book from one bin to another !!!!
        }
        books.Clear();
    }

}
