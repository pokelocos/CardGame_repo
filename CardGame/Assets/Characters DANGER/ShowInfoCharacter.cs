using GemCardGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfoCharacter : MonoBehaviour
{
    public CharacterData data;

    public Image image;
    public Text nameFile;
    public Text life;
    public Text mana;
    public Text description;

    public void Awake()
    {
        SetInfo(data);
    }

    public void SetInfo(CharacterData data)
    {
        image.sprite = data.image;
        nameFile.text = data.characterTag;
        life.text = data.hp.ToString();
        mana.text = data.mp.ToString();

        description.text = "";
        foreach (var item in data.cardsData)
        {
           // description.text += item.cardName;
            var card = (Creature)item;            
            Debug.Log(card);
            if (card != null)
            {
                description.text += ": " + card.damage;
            }

            description.text +=  "\n";
        }

        //description.text = data.description;
    }

}
