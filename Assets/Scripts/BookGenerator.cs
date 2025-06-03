using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BookGenerator : MonoBehaviour
{
    public TextMeshProUGUI booksRemainingText;
    public Transform bookSpawnPoint;

    public GameObject book; //book prefab
    public List<GameObject> bookList; //master list of all returned books
    public int numOfBooks = 20; //how many randomly generated books should be loaded into the book return
    public int booksToDisplay = 5; //how many books should be displayed at a time
    public Transform remainingContainer;
    public GameObject bookIconPrefab;
    public GameObject resetPanel;
    public GameObject resetButton;

    private List<GameObject> icons = new List<GameObject>();

    private int booksInBatch = 0;
    private int booksLeft;
    private bool menuActive = false;

    void Start()
    {
        GenerateNewBooks();

        DisplayNewBooks();
    }

    private void Update()
    {
        if (booksInBatch <= 0 && booksLeft <= 0 && !menuActive)
        {
            menuActive = true;
            resetPanel.SetActive(true);
        }

        if (menuActive)
        {
            Image panelImage = resetPanel.GetComponent<Image>();
            Color panelColor = panelImage.color;
            if (panelColor.a < 0.5f)
            {
                panelColor.a += Time.deltaTime * 0.5f; // Adjust speed as needed
                panelImage.color = panelColor;
            }
            TextMeshProUGUI buttonText = resetButton.GetComponent<TextMeshProUGUI>();
            Color textColor = buttonText.color;
            if (textColor.a < 1f)
            {
                textColor.a += Time.deltaTime * 1.0f;
                buttonText.color = textColor;
            }

        }
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
        foreach (var icon in icons)
        {
            Destroy(icon);
        }
        icons.Clear();

        for (int i = 0; i < booksLeft; i++)
        {
            GameObject icon = Instantiate(bookIconPrefab, remainingContainer);
            icon.SetActive(true);
            icons.Add(icon);
        }
    }
}
