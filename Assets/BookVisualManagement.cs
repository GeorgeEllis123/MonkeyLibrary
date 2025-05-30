using System;
using UnityEngine;

public class BookVisualManagement : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] private Color red;
    [SerializeField] private Color orange;
    [SerializeField] private Color green;
    [SerializeField] private Color blue;

    [Header("Icons")]
    [SerializeField] private Sprite spaceShip;
    [SerializeField] private Sprite potionFlask;
    [SerializeField] private Sprite dragon;
    [SerializeField] private Sprite knight;
    [SerializeField] private Sprite person;
    [SerializeField] private Sprite portrait;
    [SerializeField] private Sprite solider;
    [SerializeField] private Sprite map;

    [Header("Numbers")]
    [SerializeField] private Sprite one;
    [SerializeField] private Sprite two;
    [SerializeField] private Sprite three;
    [SerializeField] private Sprite four;
    [SerializeField] private Sprite five;
    [SerializeField] private Sprite six;
    [SerializeField] private Sprite seven;
    [SerializeField] private Sprite eight;

    [Header("Refrences")]
    [SerializeField] private SpriteRenderer backgroundSide;
    [SerializeField] private SpriteRenderer iconSide;
    [SerializeField] private SpriteRenderer numberSide;
    [SerializeField] private SpriteRenderer backgroundCover;
    [SerializeField] private SpriteRenderer iconCover;
    [SerializeField] private SpriteRenderer numberCover;

    private BookData bd;

    private void Start()
    {
        bd = gameObject.GetComponent<BookData>();
        LoadInformation();
    }

    private void LoadInformation()
    {
        // do the same for bd.icon and bd.number see BoodData.cs for the Enums
        switch (bd.color)
        {
            case (BookData.Colors.Red):
                backgroundSide.color = red;
                backgroundCover.color = red;
                break;
            case (BookData.Colors.Orange):
                backgroundSide.color = orange;
                backgroundCover.color = orange;
                break;
            case (BookData.Colors.Green):
                backgroundSide.color = green;
                backgroundCover.color = green;
                break;
            case (BookData.Colors.Blue):
                backgroundSide.color = blue;
                backgroundCover.color = blue;
                break;
        }
    }
}
