using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int kiwis = 0;

    [SerializeField] private Text KiwiCountText;
    [SerializeField] private AudioSource CollectSoundEffect;

    void Start()
    {
            KiwiCountText.text = "Kiwis: " + kiwis;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kiwi"))
        {
            CollectSoundEffect.Play();
            Destroy(collision.gameObject);
            kiwis++;
            KiwiCountText.text = "Kiwis: " + kiwis;
        }
    }
}
