using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public CheckGround checkGround;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        /* Sabiendo la función de este método
        genere las instrucciones necesarias...
        */
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkGround.tocaEnemigo)
        {
            impulse(jumpForce);
        }
    }

    void FixedUpdate()
    {
        checkMove();
        checkJump();
    }

    private void checkMove()
    {
        /* Genere el código para que el jugador se mueva...
        añada las animaciones pertinentes
        */
        if (Input.GetKey(KeyCode.A))
        {
            _rigidBody.velocity = new Vector2(-1*speed,_rigidBody.velocity.y);
            _spriteRenderer.flipX = true;
            _animator.SetBool("isRunning",true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rigidBody.velocity = new Vector2(speed,_rigidBody.velocity.y);
            _spriteRenderer.flipX = false;
            _animator.SetBool("isRunning",true);
        }
        if(Mathf.Abs(_rigidBody.velocity.x) <= 0.5f)
        {
            _animator.SetBool("isRunning",false);
        }

    }    
    
    private void checkJump()
    {
        /* Genere el código para que el jugador salte...
        añada las animaciones pertinentes
        */
        if (checkGround.tocandoSuelo && Input.GetKey(KeyCode.Space))
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x,jumpForce);
            _animator.SetBool("isJumping",true);
        }
        else
        {
            _animator.SetBool("isJumping",false);
        }
    }

    public void impulse(float impulse)
    {
        /*
        Este método se ejecutará cuando el jugador salte sobre 
        la cabeza del enemigo impulsado al jugador hacia arriba.
        */
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x,impulse);
        _animator.SetBool("isJumping",true);
    }



}
