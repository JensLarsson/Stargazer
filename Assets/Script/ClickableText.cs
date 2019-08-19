using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableText : MonoBehaviour, IPointerClickHandler
{
    TextMeshProUGUI text;
    public Color32 linkColour = Color.cyan, linkHighlight = Color.magenta;

    bool linkMouseOver = true, ShitsFuckedThisFixesABug = false;

    private void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
        ColourLinks();
    }

    public void ColourLinks()
    {
        text.ForceMeshUpdate();
        int linkCount = text.textInfo.linkCount;
        for (int linkIndex = 0; linkIndex < linkCount; linkIndex++) //Loops through each link in the text
        {
            var linkInfo = text.textInfo.linkInfo[linkIndex]; //Takes out the identifier of the link atribute

            //loops through each character in the link
            for (int i = linkInfo.linkTextfirstCharacterIndex; i < linkInfo.linkTextfirstCharacterIndex + linkInfo.linkTextLength; i++)
            {
                if (char.IsWhiteSpace(text.textInfo.characterInfo[i].character))
                {
                    continue; //continue if current char is a whitespace, as those have no vertexes
                }
                int meshIndex = text.textInfo.characterInfo[i].materialReferenceIndex;
                int vertexIndex = text.textInfo.characterInfo[i].vertexIndex;

                Color32[] vertexColors = text.textInfo.meshInfo[meshIndex].colors32;
                vertexColors[vertexIndex + 0] = linkColour;
                vertexColors[vertexIndex + 1] = linkColour;
                vertexColors[vertexIndex + 2] = linkColour;
                vertexColors[vertexIndex + 3] = linkColour;
            }
        }
        text.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //If a text link is clicked
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, Input.mousePosition, null);
            if (linkIndex > -1)
            {
                var linkInfo = text.textInfo.linkInfo[linkIndex]; //Takes out the identifier of the link atribute
                var linkID = linkInfo.GetLinkID().ToString(); //Gets the ID of the identified attribute


                Debug.Log(linkID);//Implement action here
                TextCommandManager.ExecuteCommand(linkID);
                linkInfo.textComponent = null;
                text.text = text.text.Remove(linkInfo.linkIdFirstCharacterIndex + linkID.Length+1, linkInfo.linkTextLength);
                text.ForceMeshUpdate();
            }
        }
    }

    private void Update()
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, Input.mousePosition, null);
        ColourLinks(); // This is run every frame due to a bug, even though it should only run as the mousecursor leaves 

        if (linkIndex > -1)
        {
            var linkInfo = text.textInfo.linkInfo[linkIndex]; //Takes out the identifier of the link atribute
            for (int i = linkInfo.linkTextfirstCharacterIndex; i < linkInfo.linkTextfirstCharacterIndex + linkInfo.linkTextLength; i++)
            {
                if (char.IsWhiteSpace(text.textInfo.characterInfo[i].character))
                {
                    continue;
                }
                int meshIndex = text.textInfo.characterInfo[i].materialReferenceIndex;
                int vertexIndex = text.textInfo.characterInfo[i].vertexIndex;

                Color32[] vertexColors = text.textInfo.meshInfo[meshIndex].colors32;
                vertexColors[vertexIndex + 0] = linkHighlight;
                vertexColors[vertexIndex + 1] = linkHighlight;
                vertexColors[vertexIndex + 2] = linkHighlight;
                vertexColors[vertexIndex + 3] = linkHighlight;
            }
            text.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
        }
    }
}
