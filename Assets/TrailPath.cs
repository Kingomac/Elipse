using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailPath : MonoBehaviour
{
    private Rigidbody ball;
    public List<Vector3> x;
    private TrailRenderer tr;
    private int frame = 0;
    // Start is called before the first frame update
    void Start()
    {
        x = new List<Vector3>();
        ball = GetComponentInParent<Rigidbody>();
        tr = GetComponentInParent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(frame >= 10)
        {
            x.Add(ball.position);
            tr.SetPositions(x.ToArray());
            x.Clear();
            frame = 0;
        }
        frame++;
    }
}
