using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TabSwitcher : MonoBehaviour
{
    public List<TMP_InputField> inputFields;
    int ndx;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inputFields.Count <= ndx)
            {
                ndx = 0;
            }
            ndx++;
            inputFields[ndx].Select();
        }
    }
}
