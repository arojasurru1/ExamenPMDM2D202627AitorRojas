using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool tocandoSuelo = false;
    public bool tocaEnemigo = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground")){
            tocandoSuelo = true;
        }
        else if (collision.CompareTag("Enemy"))
        {
            tocaEnemigo = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground")){
            tocandoSuelo = false;
        }
        else if (collision.CompareTag("Enemy"))
        {
            tocaEnemigo = false;
        }
    }


}
