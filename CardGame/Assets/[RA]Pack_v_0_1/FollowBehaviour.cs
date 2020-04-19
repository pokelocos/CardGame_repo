using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class FollowBehaviour : MonoBehaviour
{
    public Vector3 delta;
    public Transform target;

    private void Awake()
    {
       
    }

    private void Update()
    {
        if(target != null && Vector3.Distance(target.position, this.transform.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(target.position + delta, this.transform.position,Time.deltaTime);
        }
    }

}

