using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class Bin : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource addSound;
    [SerializeField] private AudioSource clearSound;

    private List<GameObject> books = new List<GameObject>();

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
        BookGenerator.RemoveBook(book);
        book.SetActive(false); // this is wrong should add the book visually but just temporary
        if (books.Count >= 4) 
        {
            ScoreContents();
        }
    }

    private void ScoreContents()
    {
        clearSound.Play();
        books.Clear();

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
                    tracker[3][2] += 1;
                    break;
                case (BookData.Colors.Blue):
                    tracker[4][3] += 1;
                    break;
            }
        }

        int score = 0;
        for (int i = 0; i < 3;  i++)
        {
            int[] a = tracker[i];
            for (int j = 0; j < a.Length; j++)
            {
                int val = a[j];
                score += val * val;
            }
        }
    }
}
