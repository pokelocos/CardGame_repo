using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;


namespace CardGame
{
    public interface ICard 
    {
        List<Property> GetProperties();
    }
}
