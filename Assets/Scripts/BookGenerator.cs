using System.Collections.Generic;
using UnityEngine;

public class BookGenerator : MonoBehaviour
{

    public GameObject book;
    //master list of all returned books
    public GameObject[] bookList;
    //how many randomly generated books should be loaded into the book return
    public int numOfBooks = 20;

    public int booksOnDisplay = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initialize list of procedurally generated books
        for (int i = 0; i < numOfBooks; i++)
        {
            GameObject b = Instantiate(book);
            BookData bdata = b.GetComponent<BookData>();
            bdata.GenerateData(); // whatever the method is to randomize the book data
            bookList.SetValue(b, i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
