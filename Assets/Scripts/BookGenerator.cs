using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookGenerator : MonoBehaviour
{
    public TextMeshProUGUI booksRemainingText;
    public Transform bookSpawnPoint;

    public GameObject book; //book prefab
    public List<GameObject> bookList; //master list of all returned books
    public int numOfBooks = 20; //how many randomly generated books should be loaded into the book return
    public int booksToDisplay = 5; //how many books should be displayed at a time

    private int booksInBatch = 0;
    private int booksLeft;

    void Start()
    {
        GenerateNewBooks();

        DisplayNewBooks();
    }

    public void DisplayNewBooks()
    {
        StartCoroutine(DisplayBooksWithDelay());
    }

    IEnumerator DisplayBooksWithDelay()
    {
        for (int i = booksInBatch; i < booksToDisplay; i++)
        {
            try
            {
                bookList[i].SetActive(true);
                booksInBatch++;
                booksLeft--;
                UpdateUI();
            } catch (System.Exception e)
            {
                Debug.Log("No More books");
            }
            
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void GenerateNewBooks()
    {
        //initialize list of procedurally generated books
        for (int i = 0; i < numOfBooks; i++)
        {
            GameObject b = Instantiate(book, bookSpawnPoint);
            BookData bdata = b.GetComponent<BookData>();
            bdata.GenerateData();
            b.SetActive(false); //deactivate by default
            bookList.Add(b);
        }
        booksLeft = bookList.Count;
        UpdateUI();
    }

    public void RemoveBook(GameObject b)
    {
        bookList.Remove(b);
        booksInBatch--;
        if (booksInBatch <= 1)
        {
            DisplayNewBooks();
        }
    }

    private void UpdateUI()
    {
        booksRemainingText.text = booksLeft.ToString();
    }
}
