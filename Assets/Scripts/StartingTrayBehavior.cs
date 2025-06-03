using UnityEngine;

public class StartingTrayBehavior : MonoBehaviour
{
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Book"))
        {
            audioSource.Play();
        }
    }
}
