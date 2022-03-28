using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    Level level;
    int timesHit;

    private void Start()
    {
        CountBreakableBlocks();
        
    }

    private void Awake()
    {
        SaveSystem.blocks.Add(this);

    }

    private void OnDestroy()
    {
        SaveSystem.blocks.Remove(this);
        
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable_1" || tag == "Breakable_3")
        {
            level.CountBlocks();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable_1" || tag == "Breakable_3")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        
        level.BlockDestroyed();
        FindObjectOfType<GameStatus>().AddToScore();
        TriggerSparklesVFX();
        
    }
    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 0.25f);
    }
}
