using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    public GameObject rightPosition, leftPosition, deadPrefab;
    bool changePosition, startGame;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * Time.deltaTime);

        if(changePosition == true && startGame == true){
            transform.position = Vector3.Lerp(transform.position, new Vector3(rightPosition.transform.position.x, transform.position.y, transform.position.z), 10f * Time.deltaTime);
        }
        if(changePosition == false && startGame == true){
            transform.position = Vector3.Lerp(transform.position, new Vector3(leftPosition.transform.position.x, transform.position.y, transform.position.z), 10f * Time.deltaTime);
        }
    }

    public void OnTap()
    {
        startGame = true;

        if(changePosition == false){
            changePosition = true;
        } else if(changePosition == true){
            changePosition = false;
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "wall"){
            transform.gameObject.SetActive(false);
            for(int i = 0; i < 17; i++){
                Instantiate(deadPrefab, transform.position, Quaternion.identity);
            }
        }

        if(other.tag == "finish"){
            Debug.Log("Finish");
        }
    }
}
