using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectControll : MonoBehaviour
{

    public float rotationSpeed = 10;

    [SerializeField] public bool active = true;
    [SerializeField] protected bool move = false;
    [SerializeField] protected bool horozantal = true;
    [SerializeField] protected bool vertical = false;
    [SerializeField] protected string level;
    [SerializeField] protected string nextLevel;
    [SerializeField] protected float tolerance = 5;
    private bool compleat = false;
    protected AudioSource sfx;

    void Awake(){
        sfx = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
       
        if (!compleat && active){
            if (Input.GetKey(KeyCode.Mouse0))
            {
                float h = Input.GetAxis("Mouse X");
                float v = Input.GetAxis("Mouse Y");
            
                if (Input.GetKey(KeyCode.LeftControl) && move)
                {
                    if (Mathf.Abs(h) > Mathf.Abs(v))
                        transform.position += new Vector3(0, 0, h);
                    else
                        transform.position += new Vector3(0, v, 0);
                }
                else
                {
                    if (horozantal)
                    {
                        if (Mathf.Abs(h) > Mathf.Abs(v))
                        {
                            transform.Rotate(0, h * rotationSpeed, 0, Space.World);
                        }
                    }
                    if (vertical)
                    {
                        if (Mathf.Abs(v) >= Mathf.Abs(h) && (v * rotationSpeed) != 0){
                            transform.Rotate(v * rotationSpeed, 0, 0, Space.World);
                        }
                    }
                }
            }
            else if (inLimit())
            {
                Debug.Log("object in corect place");
                compleat = true;
                LevelCompleatController.incetence.open();
                LevelCompleatController.incetence.saveLevel(level, 2);
                if (!string.IsNullOrEmpty(nextLevel))
                    LevelCompleatController.incetence.unlockLevel(nextLevel);
                sfx.Play();
            }
        }
    }

    abstract protected bool inLimit();
}