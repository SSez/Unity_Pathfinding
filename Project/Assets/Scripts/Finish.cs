using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("EndScreen");
        }
    }
}
