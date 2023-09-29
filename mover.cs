using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{

    float horizontal; 
    float vertical;
    Rigidbody meuRb;
    
    [SerializeField] bool noChao = false;
    [SerializeField] Transform contatoChao;
    [SerializeField] LayerMask camadaChao;

    [SerializeField] float forcaPulo = 10f;
    [SerializeField] float velocidadeX = 10f;
    [SerializeField] float velocidadeZ = 10f;


    // Start is called before the first frame update
    void Start()
    {
        meuRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        noChao = Physics.Linecast(this.transform.position, contatoChao.position, camadaChao);
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (noChao)
        {
            if (Input.GetButtonDown("Jump")) 
            {
                meuRb.AddForce(new Vector3(0f, forcaPulo), ForceMode.Impulse);
                
            }
        }
        else
        {
            meuRb.velocity = new Vector3(meuRb.velocity.x, meuRb.velocity.y, meuRb.velocity.z);
        }
        
    }

    void FixedUpdate()
    {
        meuRb.velocity = new Vector3(horizontal * velocidadeX * Time.deltaTime, meuRb.velocity.y, vertical * velocidadeZ * Time.fixedDeltaTime);
    }

    public void OnCollisionEnter(Collision quem)
    {
        if(quem.gameObject.tag == "perseguidor" || quem.gameObject.tag == "ronda")
        {
            //não destroi necessariamente mas perde vida
            Destroy(this.gameObject);
        }
    }
}
