using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player=FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        float interpolation=player.speed*Time.deltaTime;
        Vector3 position=transform.position;
        position.x=Mathf.Lerp(transform.position.x,player.transform.position.x,interpolation);
        position.y=Mathf.Lerp(transform.position.y,player.transform.position.y,interpolation);
        position.z=transform.position.z;
        transform.position= position;
    }
}
