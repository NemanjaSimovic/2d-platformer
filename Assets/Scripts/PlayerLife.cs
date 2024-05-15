using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D Body;
    private Animator Animat;
    [SerializeField] AudioSource DeathSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        Animat = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        DeathSoundEffect.Play();
        Body.bodyType = RigidbodyType2D.Static;
        Animat.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
