using System.Collections.Generic;
using UnityEngine;

public class BookGenerator : MonoBehaviour
{

    public GameObject book; //book prefab
   
    //master list of all returned books
    public List<GameObject> bookList;
    
    //how many randomly generated books should be loaded into the book return
    public int numOfBooks = 20;

    //how many books should be displayed at a time
    public int booksOnDisplay = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateNewBooks();

        DisplayNewBooks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayNewBooks()
    {
        //display first few books
        for (int i = 0; i < booksOnDisplay; i++)
        {
            bookList[i].SetActive(true);
            bookList[i].transform.position = new Vector2(((i - 6) + (i * 2)), bookList[i].transform.position.y); //the math on this positioning might be totally wrong
        }
    }

    public void GenerateNewBooks()
    {
        //initialize list of procedurally generated books
        for (int i = 0; i < numOfBooks; i++)
        {
            GameObject b = Instantiate(book);
            BookData bdata = b.GetComponent<BookData>();
            bdata.GenerateData();
            b.SetActive(false); //deactivate by default
            bookList.Add(b);
        }
    }
}
