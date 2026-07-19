using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEditor.SearchService;

public class PlayerHandler : MonoBehaviour
{
    
    [Header("Health Config")]
    public int currentHealth = 5;
    [SerializeField] int maxHealth = 5;
    [SerializeField] Transform heartsContainer;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

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
    [SerializeField] private Mana manaHandler;
    [SerializeField] private SceneLoader sceneLoader;

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

    public Action<string, int, int> useSpell = null;
    public Action<string, int> useItem = null;
    private Enemy enemy;

    bool invinsibile = false;
    bool movingUp = false;
    bool movingSide = false;
    float speed = 5f;

    Animator anim;

    AudioSource audioSource;

    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        
        anim = GetComponent<Animator>();

        transform.position = new Vector3(-3,-3,0);
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
                StartCoroutine(Parry(parryCooldown));
            }


            if (Input.GetKey(upKey))
            {
                transform.position += new Vector3(0f,speed,0f) * Time.deltaTime;
                anim.SetBool("Up",true);
                anim.SetBool("Down",false);
                movingUp = true;
            }
                else if (Input.GetKey(downKey))
            {
                transform.position += new Vector3(0f,-speed,0f) * Time.deltaTime;
                anim.SetBool("Up",false);
                anim.SetBool("Down",true);
                movingUp = true;
            }
            else
            {
                movingUp = false;
                transform.position += new Vector3(0f,0f,0f);
                anim.SetBool("Up",false);
                anim.SetBool("Down",false);
            }


            if (Input.GetKey(rightKey))
            {
                transform.position += new Vector3(speed,0f,0f) * Time.deltaTime;
                anim.SetBool("Left",false);
                anim.SetBool("Right",true);
                movingSide = true;
            }
            else if (Input.GetKey(leftKey))
            {
                transform.position += new Vector3(-speed,0f,0f) * Time.deltaTime;
                anim.SetBool("Right",false);
                anim.SetBool("Left",true);
                movingSide = true;
            }
            else
            {
                movingSide = false;
                transform.position += new Vector3(0f,0f,0f);
                anim.SetBool("Right",false);
                anim.SetBool("Left",false);
            }
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            sceneLoader.playerDied.Invoke();
        }

        if (movingSide == false && movingUp == false)
        {
            anim.SetBool("Idle",true);
        }
        else
        {
            anim.SetBool("Idle",false);
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
    }

    void PlaySound(AudioClip soundLmao)
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

    IEnumerator Parry(float tickTock)
    {
        if (canParry == true && Input.GetKey(parryKey))
        {
            anim.SetBool("Parry",true);
            PlaySound(parryStartSound);
            canParry = false;
            parrying = true;
            gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            gameObject.GetComponent<CircleCollider2D>().radius = defaultParrySize;
            yield return new WaitForSeconds(0.4f);
            parrying = false;
            gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
            gameObject.GetComponent<CircleCollider2D>().radius = defaultHurtboxSize;
            anim.SetBool("Parry",false);
            yield return new WaitForSeconds(tickTock);
            canParry = true;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (invinsibile == false && col.tag == "Bullet")
        {
            invinsibile = true;
            PlaySound(playerHitSound);
            ChangeHealth(-1);
            StartCoroutine(waitIframes(invinsibilityTime));
        }
        else if (invinsibile == false && parrying == true && col.tag == "ParryableBullet")
        {
            // parryEffect.Clear();
            // parryEffect.Play();
            PlaySound(parryHitSound);
            invinsibile = true;
            manaHandler.parried?.Invoke();
            StartCoroutine(waitIframes(invinsibilityTime));
        }
        else if (invinsibile == false)
        {
            invinsibile = true;
            PlaySound(playerHitSound);
            ChangeHealth(-1);
            StartCoroutine(waitIframes(invinsibilityTime));
        }
    }
    
    void ItemUsed(string name, int healAmount){
        ChangeHealth(healAmount);
        string healedText = $"{name} healed {healAmount} heart";
        if (healAmount > 1) healedText += "s";
        healedText += "!";
        combatLog.incomingLog?.Invoke(healedText);
    }

    void SpellUsed(string name, int damageAmount, int manaCost){
        if (damageAmount < 0){ 
            ItemUsed(name, -damageAmount);
        } else {
            combatLog.incomingLog?.Invoke($"{name} dealt {damageAmount} damage!");
            enemy.incomingDamage?.Invoke(damageAmount);
        }
    }

    void ChangeHealth(int change){
        currentHealth = Mathf.Clamp(currentHealth + change, 0, maxHealth);
        for (int i = 0; i < maxHealth; i++){
            SpriteRenderer heartSprite = heartsContainer.GetChild(i).GetComponent<SpriteRenderer>();
            if (i >= currentHealth) heartSprite.sprite = emptyHeart;
            else heartSprite.sprite = fullHeart;
        }
    }
}
