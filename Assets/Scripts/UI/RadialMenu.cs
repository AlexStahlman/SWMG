using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RadialMenu : MonoBehaviour
{
    public CanvasGroup radialMenuGroup;
    private List<RadialMenuEntry> menuEntries;
    public GameObject menuEntryObject;
    public float menuRadius;

    private RadialMenuEntry selectedEntry;

    public SpellManager spellManager;

    public RadialMenuEntry SelectedEntry { get => selectedEntry; set => selectedEntry = value; }

    void Start()
    {
        radialMenuGroup = GetComponent<CanvasGroup>();
        menuEntries = new List<RadialMenuEntry>();
        this.gameObject.SetActive(false);
    }

    void AddEntry()
    {
        GameObject entry = Instantiate(menuEntryObject, transform);
        RadialMenuEntry menuEntry = entry.GetComponent<RadialMenuEntry>();
        menuEntry.SetName();
        menuEntries.Add(menuEntry);
        RadialArrange();
    }
    void RemoveEntry()
    {

        RadialArrange();
        //Instantiate SpellScroll prefab
    }
    void GetEntry()
    {

    }
    public void RadialArrange()
    {
        float radius = menuRadius * menuEntries.Count - 1;
        float radianSep = (Mathf.PI * 2) / menuEntries.Count;
        for (int i = 0; i < menuEntries.Count; i++)
        {
            menuEntries[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(Mathf.Sin(radianSep * i) * radius, Mathf.Cos(radianSep * i) * radius, 0);
        }
    }

}
