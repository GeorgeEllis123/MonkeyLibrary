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
        switch (bd.color)
        {
            case BookData.Colors.Red:
                backgroundSide.color = red;
                backgroundCover.color = red;
                break;
            case BookData.Colors.Orange:
                backgroundSide.color = orange;
                backgroundCover.color = orange;
                break;
            case BookData.Colors.Green:
                backgroundSide.color = green;
                backgroundCover.color = green;
                break;
            case BookData.Colors.Blue:
                backgroundSide.color = blue;
                backgroundCover.color = blue;
                break;
        }

        switch (bd.icon)
        {
            case BookData.Icon.SpaceShip:
                if (spaceShip != null)
                {
                    iconSide.sprite = spaceShip;
                    iconCover.sprite = spaceShip;
                }
                break;
            case BookData.Icon.PotionFlask:
                if (potionFlask != null)
                {
                    iconSide.sprite = potionFlask;
                    iconCover.sprite = potionFlask;
                }
                break;
            case BookData.Icon.Dragon:
                if (dragon != null)
                {
                    iconSide.sprite = dragon;
                    iconCover.sprite = dragon;
                }
                break;
            case BookData.Icon.Knight:
                if (knight != null)
                {
                    iconSide.sprite = knight;
                    iconCover.sprite = knight;
                }
                break;
            case BookData.Icon.Person:
                if (person != null)
                {
                    iconSide.sprite = person;
                    iconCover.sprite = person;
                }
                break;
            case BookData.Icon.Portrait:
                if (portrait != null)
                {
                    iconSide.sprite = portrait;
                    iconCover.sprite = portrait;
                }
                break;
            case BookData.Icon.Solider:
                if (solider != null)
                {
                    iconSide.sprite = solider;
                    iconCover.sprite = solider;
                }
                break;
            case BookData.Icon.Map:
                if (map != null)
                {
                    iconSide.sprite = map;
                    iconCover.sprite = map;
                }
                break;
        }

        switch (bd.number)
        {
            case BookData.Number.One:
                if (one != null)
                {
                    numberSide.sprite = one;
                    numberCover.sprite = one;
                }
                break;
            case BookData.Number.Two:
                if (two != null)
                {
                    numberSide.sprite = two;
                    numberCover.sprite = two;
                }
                break;
            case BookData.Number.Three:
                if (three != null)
                {
                    numberSide.sprite = three;
                    numberCover.sprite = three;
                }
                break;
            case BookData.Number.Four:
                if (four != null)
                {
                    numberSide.sprite = four;
                    numberCover.sprite = four;
                }
                break;
            case BookData.Number.Five:
                if (five != null)
                {
                    numberSide.sprite = five;
                    numberCover.sprite = five;
                }
                break;
            case BookData.Number.Six:
                if (six != null)
                {
                    numberSide.sprite = six;
                    numberCover.sprite = six;
                }
                break;
            case BookData.Number.Seven:
                if (seven != null)
                {
                    numberSide.sprite = seven;
                    numberCover.sprite = seven;
                }
                break;
            case BookData.Number.Eight:
                if (eight != null)
                {
                    numberSide.sprite = eight;
                    numberCover.sprite = eight;
                }
                break;
        }
    }
}
