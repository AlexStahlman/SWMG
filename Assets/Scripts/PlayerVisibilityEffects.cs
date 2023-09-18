using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisibilityEffects : MonoBehaviour
{
    [SerializeField] private LayerMask cutoutMask;
    private Camera cam;
    private RaycastHit[] hits={};
    // Start is called before the first frame update
    void Start()
    {
    cam=Camera.main;
    cutoutMask=LayerMask.GetMask("Walls");
    }
    void Cutout(){
        Vector2 playPos= cam.WorldToViewportPoint(transform.position);
        playPos.y/= (Screen.width/Screen.height);
        Vector3 camPlayer= transform.position-cam.transform.position;
        Vector3 camXY= new Vector3(cam.transform.position.x,transform.position.y,cam.transform.position.z);
        for(int i=0; i<hits.Length; i++){
        //if the x(player.y)z of the hitpoint has a greater distance from the camera x(player.y)z than the player, then dont apply
        Vector3 hitXY= new Vector3(hits[i].point.x,transform.position.y,hits[i].point.z);
        if((transform.position-camXY).magnitude>(hits[i].point-camXY).magnitude){
            hits[i].transform.GetComponent<Renderer>().material.SetFloat("_Opacity",0.0f);
        }
        }
        hits= Physics.RaycastAll(cam.transform.position, camPlayer, camPlayer.magnitude, cutoutMask);
        for(int i=0; i<hits.Length;i++){
            Material hitMat= hits[i].transform.GetComponent<Renderer>().material;
            hitMat.SetFloat("_Opacity",0.75f);
            hitMat.SetVector("_Player_Position", playPos);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Cutout();
    }
}
