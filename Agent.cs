using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AustinHarris.JsonRpc;

public class MyVector3
{
    public float x;
    public float y;
    public float z;

    public MyVector3(Vector3 v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
    }

    public Vector3 AsVector3()
    {
        return new Vector3(x, y, z);
    }
}
public class Agent : MonoBehaviour
{

    class Rpc : JsonRpcService
    {

        Agent agent;

        public Rpc(Agent agent)
        {
            this.agent = agent;
        }

        [JsonRpcMethod]
        void Say(string message)
        {
            Debug.Log($" you sent {message}");
        }

        [JsonRpcMethod]
        float GetHeight()
        {
            return agent.transform.position.y;
        }

        [JsonRpcMethod]
        MyVector3 GetPos()
        {
            return new MyVector3(agent.transform.position);
        }

        [JsonRpcMethod]

        void Translate(MyVector3 translate)
        {
            agent.transform.position += translate.AsVector3();
        }



    }
    Rpc rpc;
    // Start is called before the first frame update
    void Start()
    {
        rpc = new Rpc(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
