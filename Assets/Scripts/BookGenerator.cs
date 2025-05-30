using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookGenerator : MonoBehaviour
{

    public Transform bookSpawnPoint;

    public GameObject book; //book prefab
   
    //master list of all returned books
    public List<GameObject> bookList;
    
    //how many randomly generated books should be loaded into the book return
    public int numOfBooks = 20;

    //how many books should be displayed at a time
    public int booksToDisplay = 5;

    //how many books have currently been sorted (resets at 0)
    public int booksLeft = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        for (int i = booksLeft; i < booksToDisplay; i++)
        {
            try
            {
                bookList[i].SetActive(true);
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
    }

    public void RemoveBook(GameObject b)
    {
        bookList.Remove(b);
        booksLeft--;
        if (booksLeft <= 1)
        {
            DisplayNewBooks();
        }
    }
}
