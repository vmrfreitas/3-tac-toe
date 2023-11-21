using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public Toggle x_toggle;
    public Toggle o_toggle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void XSelected(){
        GameOptions.wildValue = 1;
        x_toggle.SetIsOnWithoutNotify(true);
        o_toggle.SetIsOnWithoutNotify(false);
    }

    public void OSelected(){
        GameOptions.wildValue = -1;
        x_toggle.SetIsOnWithoutNotify(false);
        o_toggle.SetIsOnWithoutNotify(true);
    }
}
