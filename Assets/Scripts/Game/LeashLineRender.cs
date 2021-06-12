using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeashLineRender : MonoBehaviour
{
    public GameObject LeashStart;
    public GameObject LeashTarget;

    public LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, LeashStart.transform.position);
        line.SetPosition(1, LeashTarget.transform.position);
    }
}
