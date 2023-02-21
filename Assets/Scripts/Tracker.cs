using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tracker : MonoBehaviour
{
    public bool reverse = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
 
 void Update () {
     var pos = Camera.main.WorldToScreenPoint(transform.position);
     var dir = Input.mousePosition - pos;
     var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
     Quaternion newRota = new Quaternion();
     newRota = Quaternion.AngleAxis(angle, Vector3.forward);
     if (reverse) {
        newRota= Quaternion.Inverse(newRota);
        Vector3 rota=newRota.eulerAngles;
        rota = new Vector3(rota.x, rota.y, rota.z+180);
        transform.localRotation = Quaternion.Euler(rota);
        }
     else transform.rotation=newRota;

 }

}
