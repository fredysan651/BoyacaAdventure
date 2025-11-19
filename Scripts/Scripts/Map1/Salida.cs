using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida : MonoBehaviour
{
    public string targetSceneName = "Mapa_1";

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if (other.tag == "Player")
        {
            print("Switching Scene to " + targetSceneName);
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
