using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    
    [Header("Health Config")]
    public int currentHealth = 5;
    [SerializeField] int maxHealth = 5;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;
    public bool dead = false;

    [Header("Controls")]
    [SerializeField] string upKey = "w";
    [SerializeField] string downKey = "s";
    [SerializeField] string leftKey = "a";
    [SerializeField] string rightKey = "d";
    [SerializeField] string parryKey = "f";

    [Header("Player Config")]
    [SerializeField] float invinsibilityTime = 1f;
    [SerializeField] float parryCooldown = 1;
    [SerializeField] float defaultParrySize = 0.7f;
    [SerializeField] float defaultHurtboxSize = 0.4f;
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private CombatLog combatLog;

    [Header("Sound Effects")]
    [SerializeField] AudioClip playerHitSound;
    [SerializeField] AudioClip parryStartSound;
    [SerializeField] AudioClip parryHitSound;

    [Header("Particles")]
    [SerializeField] ParticleSystem parryEffect;

    [Header("Sprites")]
    [SerializeField] Sprite baseSprite;
    [SerializeField] Sprite hurtSprite;

    [HideInInspector]
    public bool parrying = false;
    bool canParry = true;
    SpriteRenderer spriteR;

    public Action<string, int> useSpell = null;
    public Action<string, int> useItem = null;
    private Enemy enemy;

    bool invinsibile = false;
    float speed = 5f;
    AudioSource audioSource;

    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        
        transform.position = new Vector3(-3,-3,0);
        player = GetComponent<Player>();
        currentHealth = maxHealth;
        useItem += ItemUsed;
        useSpell += SpellUsed;
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (turnManager.enemyTurn)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 2f;
            }
            else
            {
                speed = 5f;
            }


            if (Input.GetKey(parryKey))
            {
                StartCoroutine(parry(parryCooldown));
            }


            if (Input.GetKey(upKey))
            {
                transform.position += new Vector3(0f,speed,0f) * Time.deltaTime;
            }
                else if (Input.GetKey(downKey))
            {
                transform.position += new Vector3(0f,-speed,0f) * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(0f,0f,0f);
            }


            if (Input.GetKey(rightKey))
            {
                transform.position += new Vector3(speed,0f,0f) * Time.deltaTime;
            }
            else if (Input.GetKey(leftKey))
            {
                transform.position += new Vector3(-speed,0f,0f) * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(0f,0f,0f);
            }
        }



        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            dead = true;
        }
    }

    void playSound(AudioClip soundLmao)
    {
        audioSource.clip = soundLmao;
        audioSource.Play();
    }

    IEnumerator waitIframes(float tickTock)
    {
        spriteR.sprite = hurtSprite;
        yield return new WaitForSeconds(tickTock);
        invinsibile = false;
        spriteR.sprite = baseSprite;
    }

    IEnumerator parry(float tickTock)
    {
        if (canParry == true && Input.GetKey(parryKey))
        {
            playSound(parryStartSound);
            canParry = false;
            parrying = true;
            gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            gameObject.GetComponent<CircleCollider2D>().radius = defaultParrySize;
            yield return new WaitForSeconds(0.4f);
            parrying = false;
            gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
            gameObject.GetComponent<CircleCollider2D>().radius = defaultHurtboxSize;
            yield return new WaitForSeconds(tickTock);
            canParry = true;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (invinsibile == false && col.tag == "Bullet")
        {
            invinsibile = true;
            playSound(playerHitSound);
            currentHealth--;
            player.hitByBullet?.Invoke(-1);
            StartCoroutine(waitIframes(invinsibilityTime));
        }
        else if (invinsibile == false && parrying == true && col.tag == "ParryableBullet")
        {
            parryEffect.Clear();
            parryEffect.Play();
            playSound(parryHitSound);
            invinsibile = true;
            StartCoroutine(waitIframes(invinsibilityTime));
        }
        else if (invinsibile == false)
        {
            invinsibile = true;
            playSound(playerHitSound);
            currentHealth--;
            StartCoroutine(waitIframes(invinsibilityTime));
        }
    }



    
    void ItemUsed(string name, int healAmount){
        currentHealth = Mathf.Clamp(currentHealth + healAmount, 0, maxHealth);
        string healedText = $"{name} healed {healAmount} heart";
        if (healAmount > 1) healedText += "s";
        healedText += "!";
        combatLog.incomingLog?.Invoke(healedText);
    }

    void SpellUsed(string name, int damageAmount){
        if (damageAmount < 0){ 
            ItemUsed(name, -damageAmount);
        } else {
            enemy.incomingDamage?.Invoke(damageAmount);
            combatLog.incomingLog?.Invoke($"{name} dealt {damageAmount} damage!");
        }
    }
}
