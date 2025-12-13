using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class diologue_call : MonoBehaviour
{
    public GameObject diologue;
    public Life life;
    public pause_menu pause_menu;
    public TextMeshProUGUI EText;
    private List<string> diologue_list = new List<string>();
    private string text1 = "Can't get through ?";
    private string text2 = "Switch your view !!!";
    private string text3 = "To do so - Press E";
    public bool first_time = true;
    private bool isDiologueActive = false;
    private int currentDiologueIndex = 0;

    void Start()
    {
        diologue_list.Add(text1);
        diologue_list.Add(text2);
        diologue_list.Add(text3);
        diologue.SetActive(false);
        first_time = PlayerPrefs.GetInt("HasDiologueCalled", 0) == 0;
    }

    private void StartDiologue()
    {
        diologue.SetActive(true);
        currentDiologueIndex = 0;
        EText.text = diologue_list[currentDiologueIndex];
        isDiologueActive = true;
        Time.timeScale = 0f;
        first_time = false;
        pause_menu.canPause = false;
    }

    private void NextLine()
    {
        currentDiologueIndex++;
        if (currentDiologueIndex < diologue_list.Count)
        {
            EText.text = diologue_list[currentDiologueIndex];
        }
    }

    private void EndDiologue()
    {
        diologue.SetActive(false);
        isDiologueActive = false;
        Time.timeScale = 1f;
        pause_menu.canPause = true;
    }

    void Update()
    {
        
        if (life.hasCalled && first_time)
        {
            StartDiologue();
            first_time = false;
            PlayerPrefs.SetInt("HasDiologueCalled", 1);
            PlayerPrefs.Save();
        }
        if (isDiologueActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentDiologueIndex < diologue_list.Count - 1)
                {
                    NextLine();
                }
                else
                {
                    EndDiologue();
                }
            }
        }
            
        
    }
}
