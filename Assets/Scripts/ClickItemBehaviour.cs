using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickItemBehaviour : MonoBehaviour
{
    [SerializeField] GameObject destroyEffect;
    [SerializeField] int score;
    [SerializeField] float easyDrag, mediumDrag, hardDrag;
    [SerializeField] Rigidbody rb;
    
    private void Update()
    {
        if(transform.position.y < -0.6f)
        {
            GameController.instance.SufferDamage();
            Destroy(this.gameObject);
        }
        
        switch (ScoreManager.instance.dificuldade)
        {
            case DificuldadeType.Easy:
                rb.drag = easyDrag;
                break;
            case DificuldadeType.Medium:
                rb.drag = mediumDrag;
                break;
            case DificuldadeType.Hard:
                rb.drag = hardDrag;
                break;
        }
    }

    public void HitMe()
    {
        Instantiate(destroyEffect, transform.position, transform.rotation);

        if (gameObject.CompareTag("Click"))
        {
            SoundManager.instance.PlayDonutHitSound();
        } else
        {
            SoundManager.instance.PlayWaffleHitSound();
        }

        ScoreManager.instance.UpdateScore(score);
        Destroy(gameObject);
    }

}
