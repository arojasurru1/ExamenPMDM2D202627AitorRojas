using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceFollow;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;
    private Animator _animator;

    private Collider2D _collider;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayerDistance();
        if(_collider.IsTouchingLayers(1<<6)){//6 es la capa del collider de los pies del player
            death();
            }
    }

    void checkPlayerDistance()
    {
        /*
        Este método checkea si el jugador está a menor distancia de la de
        distanceFollow, en tal caso seguirá al jugador.
        */
        if (Vector2.Distance(transform.position, player.transform.position) < distanceFollow)
        {
            //moverse hacia player
            _animator.SetBool("isMoving",true);
        }
        else
        {
            _animator.SetBool("isMoving",false);
        }
    }

    public void death()
    {
        /*
        Este método inicia la animación de death del enemigo
        */
        _animator.SetTrigger("death");
    }

    public void destroyEnemy()
    {
        /*
        Este método destruye el objeto del enemigo
        */
        Destroy(gameObject);
    }

}
