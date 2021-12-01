using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : Photon.MonoBehaviour
{

    public GameObject localCam;
    PhotonView view;
    public GameObject canvas;
    public VehicleCamera cam;
    // Start is called before the first frame update
    void Start()
    {
        view =GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
            
        if(view.isMine){
            localCam.SetActive(true);
            
            this.GetComponent<VehicleControl>().enabled = true;
            this.GetComponent<VehicleDamage>().enabled = true;
            canvas.SetActive(true);
            // control1.SetActive(true);
        }
        else{
            localCam.SetActive(false);
            this.GetComponent<VehicleControl>().enabled = false;
            this.GetComponent<VehicleDamage>().enabled = false;
            canvas.SetActive(false);
            
            // control1.SetActive(false);
        }
        
    }
}
