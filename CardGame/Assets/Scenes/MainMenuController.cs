using DataSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject ContinueButton;

    private void Awake()
    {

    }

    void Start()
    {
        var saveData = DataSystem.DataManager.LoadData<Data>();
        if (saveData == null)
        {
            saveData = DataSystem.DataManager.NewData<Data>();
        }
        
        if(saveData.run == null)
        {
            ContinueButton.gameObject.SetActive(false);
        }

    }

    void Update()
    {
        
    }
}
