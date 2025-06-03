using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void SwitchToNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
