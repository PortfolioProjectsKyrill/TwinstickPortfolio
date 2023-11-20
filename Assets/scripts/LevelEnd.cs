using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public int level;
    private void OnTriggerEnter(Collider collision)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }
}
