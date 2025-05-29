using UnityEngine;
public class BookData : MonoBehaviour
{
    public enum Colors { Red, Orange, Green, Blue }
    public enum Icon { SpaceShip, PotionFlask, Dragon, Knight, Person, Portrait, Solider, Map }
    public enum Number { One, Two, Three, Four, Five, Six, Seven, Eight }

    public enum Genre { SciFi, Fantasy, Biography, History }

    public Colors color;
    public Icon icon;
    public Number number;
    public Genre genre;

    public void GenerateData()
    {
        System.Array colorAsArray = System.Enum.GetValues(typeof(Colors));
        color = (Colors)colorAsArray.GetValue(UnityEngine.Random.Range(0, colorAsArray.Length));

        System.Array numberAsArray = System.Enum.GetValues(typeof(Number));
        number = (Number)numberAsArray.GetValue(UnityEngine.Random.Range(0, numberAsArray.Length));

        System.Array genreAsArray = System.Enum.GetValues(typeof(Genre));
        genre = (Genre)genreAsArray.GetValue(UnityEngine.Random.Range(0, genreAsArray.Length));

        System.Array iconAsArray = System.Enum.GetValues(typeof(Icon));
        switch (genre)
        {
            case Genre.SciFi:
                icon = (Icon)iconAsArray.GetValue(UnityEngine.Random.Range(0, 2));
                break;
            case Genre.Fantasy:
                icon = (Icon)iconAsArray.GetValue(UnityEngine.Random.Range(2, 4));
                break;
            case Genre.Biography:
                icon = (Icon)iconAsArray.GetValue(UnityEngine.Random.Range(4, 6));
                break;
            case Genre.History:
                icon = (Icon)iconAsArray.GetValue(UnityEngine.Random.Range(6, 8));
                break;
        }
    }

}
