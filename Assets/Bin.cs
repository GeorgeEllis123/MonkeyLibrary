using NUnit.Framework;
using System;
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
    }
}
