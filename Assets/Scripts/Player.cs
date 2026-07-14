using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour{
    private int maxHealth = 5;
    private int currentHealth;
    private int attackDamage;
    [SerializeField] private float moveSpeed = 5;
    private Rigidbody2D rb; 
    public event Action useItem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 totalMovement = Vector2.zero;
        if (Keyboard.current.leftArrowKey.isPressed){
            totalMovement += Vector2.left;
        } 
        if (Keyboard.current.rightArrowKey.isPressed){
            totalMovement += Vector2.right;
        } 
        if (Keyboard.current.upArrowKey.isPressed){
            totalMovement += Vector2.up;
        } 
        if (Keyboard.current.downArrowKey.isPressed){
            totalMovement += Vector2.down;
        }

        rb.linearVelocity = totalMovement.normalized * moveSpeed;// * Time.deltaTime;
    }
}
