using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioSource VictorySoundEffect;
    private Animator Animat;
    private bool Cleared = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !Cleared)
        {
            VictorySoundEffect.Play();
            Animat.SetTrigger("finish");
            Cleared = true;
            Invoke("ChangeLevel", 2);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Animat = GetComponent<Animator>();
    }

    private void ChangeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cleared = false;
    }
}
