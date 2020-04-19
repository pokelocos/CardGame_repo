using DataSystem;
using MapSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterController : MonoBehaviour
{

    public void SelectRol(CharacterData data)
    {
        var saveData = DataSystem.DataManager.LoadData<Data>();
        if (saveData == null)
        {
            saveData = DataSystem.DataManager.NewData<Data>();            
        }

        var character = new Character(data.characterTag, data.hp, data.GetCards(), new List<Card>(), new List<Gem>());
        var map = MapGenerator.GenerateMap(20, 20, 100, 3);

        saveData.run = new Run(character,map);
        DataSystem.DataManager.SaveData<Data>(saveData);
    }
}
