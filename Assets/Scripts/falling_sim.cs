using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class falling_sim : MonoBehaviour
{
    public string faller = "";

    public float m = 80.0f; 
    private float g = 9.8f;
    private Vector3 y = new Vector3(0, -1f, 0);
    public float Cdg = 0.25f;
    public Vector3 v0 = new Vector3(50f, 0f, 0f);
    public Vector3 w = new Vector3(0, 0, 0); 
    private Vector3 p0;
    public float dt = 1f;
    public float t = 0f;
    public float s = 0f;
    private string path = "Assets/Scripts/";

    private Vector3 at;
    private Vector3 vt;
    private Vector3 pt;    

    // Start is called before the first frame update
    void Start()
    {
        p0 = transform.position;
        at = Vector3.zero;
        vt = v0;
        pt = p0;

        DeleteFile("acceleration");
        DeleteFile("speed");
        DeleteFile("position");
    }

    void FixedUpdate()
    {
        dt = Time.deltaTime;
        Vector3 frt = vt.normalized * Cdg * Mathf.Pow(vt.magnitude, 2);

        at = (m * g * y - frt) / m;
        Debug.Log("at : " + at);

        vt += at * dt;
        Debug.Log("vt : " + vt);

        pt += vt * dt + w * dt;
        Debug.Log("pt : " + pt);
        transform.position = pt;

        if(s >= 50f)
        {
            s = 0;
            writeData("acceleration", (int)t, at);
            writeData("speed", (int)t, vt);
            writeData("position", (int)t, pt);
        }

        t += dt;
        s++;
    }

    void writeData(string name, float dt, Vector3 vec)
    {
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path + name + faller +".txt", true);
        writer.WriteLine(dt + "\t" + vec.x + "\t" + vec.y);
        writer.Close();
    }

    void DeleteFile(string name)
    {
        string filePath = path + name + faller + ".txt";

        if(File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
