using UnityEngine;
using System.Collections;
using UnityEditor;

namespace CardGame
{
    public class CardEditorWindow : EditorWindow
    {

        [MenuItem("Window/Card Creator")]
        public static void ShowWindow()
        {
            GetWindow<CardEditorWindow>("Card Creator");

            
        }

        private void OnGUI()
        {
            var target = Selection.activeObject;
            if((CardData)target != null)
            {
                CardGui((CardData)target);
            }
            else if ((CardSetData)target != null)
            {
                CardSetGui((CardSetData)target);
            }
        }

        private void CardGui(CardData data)
        {

        }

        private void CardSetGui(CardSetData data)
        {

        }

        private void OnFocus()
        {

        }

        private void OnLostFocus()
        {

        }
    }
}