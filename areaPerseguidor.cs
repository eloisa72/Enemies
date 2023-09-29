using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaPerseguidor : MonoBehaviour
{
    [SerializeField]GameObject enemy; 
    perseguidor scrEnemy;
    [SerializeField]GameObject player;
    public Transform limiteX1;
    public Transform limiteX2;
    public Transform limiteZ1;
    public Transform limiteZ2;
    
    void Start()
    {
        scrEnemy = enemy.GetComponent<perseguidor>();
    }

    // Update is called once per frame
    void Update()
    {
        if((player.transform.position.x<= limiteX1.position.x && player.transform.position.x>= limiteX2.position.x) && (player.transform.position.z>= limiteZ1.position.z || player.transform.position.z<= limiteZ2.position.z))
        {
            if(player.transform.position.z>= limiteZ1.position.z && player.transform.position.z<= limiteZ2.position.z)
            {
                scrEnemy.enabled = true;
            }else{scrEnemy.enabled = false;}
        }else{scrEnemy.enabled = false;}
        
    }
}
