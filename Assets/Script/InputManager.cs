using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct MInput{
    //the key that triggers
    public KeyCode trigger;
    //if clicked
    public bool clicked;
    //if hold
    public bool hold;
    //time in sec since last input
    public float lastInput;
}

public enum GInput { comfirm,cancel,pause, up, down, left,right, button1, button2};

public class InputManager : MonoBehaviour
{
    //singelton setting
    private static InputManager _instance;
    public static InputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<InputManager>();
            }

            return _instance;
        }
    }
    //input key setting
    public KeyCode comfirm_key;
    public KeyCode cancel_key;
    public KeyCode pause_key;
    public KeyCode up_key;
    public KeyCode down_key;
    public KeyCode left_key;
    public KeyCode right_key;
    public KeyCode button1_key;
    public KeyCode button2_key;

    //input variables
    /*public MInput confirm;
    public MInput cancel;
    public MInput pause;
    public MInput up;
    public MInput down;
    public MInput left;
    public MInput right;
    public MInput button1;
    public MInput button2;
    public List<MInput> allInputs;*/
    public Dictionary<GInput, MInput> allInputs;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        //allInputs.Add(GInput.comfirm, new MInput());
        /*confirm.trigger = comfirm_key;allInputs.Add(confirm);
        cancel.trigger = cancel_key; allInputs.Add(cancel);
        pause.trigger = pause_key; allInputs.Add(pause);
        up.trigger = up_key; allInputs.Add(up);
        down.trigger = down_key; allInputs.Add(down);
        right.trigger = right_key; allInputs.Add(right);
        left.trigger = left_key; allInputs.Add(left);
        button1.trigger = button1_key; allInputs.Add(button1);
        button2.trigger = button2_key; allInputs.Add(button2);*/
    }

    // Update is called once per frame
    void Update()
    {

        /*for (int i = 0; i < allInputs.Count; i++)
        {
            MInput temp=new MInput();
            temp.clicked = Input.GetKeyDown(allInputs[i].trigger);
            temp.hold = Input.GetKey(allInputs[i].trigger);
            if (temp.clicked || temp.hold)
            {
                temp.lastInput = 0;
            }
            else
            {
                temp.lastInput = allInputs[i].lastInput + Time.unscaledDeltaTime;
            }
            allInputs[i] = temp;
        }
        Debug.Log(button1.lastInput);*/
    }
}
