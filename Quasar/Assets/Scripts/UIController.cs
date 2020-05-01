using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    bool start_vis;
    bool settings_vis;
    bool lost_menu_vis;
    bool rules_vis;
    public Button but_1_8;
    public GameObject settings_panel;
    public GameObject lost_panel;
    public Button but_4_7;
    public Button but_100;
    public Button but_200;
    public Button but_500;
    public Button start_but;
    public Button settings_but;
    public Text number_text;
    public Text score_text;
    public Text comment_text;
    public Button music_but;
    public Button effects_but;
    public Text effects_text;
    public Text music_text;
    public Sprite cross;
    public Sprite gal;
    public Text rules_text;

    void Start()
    {
        rules_vis = false;
        lost_menu_vis = false;
        settings_vis = false;
        start_vis = true;
        but_1_8.gameObject.SetActive(false);
        but_4_7.gameObject.SetActive(false);
    }
    public void setText(Text text, string str)
    {
        text.text = str;
    }

    public void turnStartBut()
    {
        if (start_vis == false)
        {
            start_vis = true;
            start_but.gameObject.SetActive(true);
            but_1_8.gameObject.SetActive(false);
            but_4_7.gameObject.SetActive(false);
        }
        else
        {
            start_vis = false;
            start_but.gameObject.SetActive(false);
            but_1_8.gameObject.SetActive(true);
            but_4_7.gameObject.SetActive(true);
        }

    }
    
    public void turnLostMenu()
    {
        if (!lost_menu_vis)
        {
            lost_menu_vis = true;
            settings_but.enabled = false;
            if (start_vis) {start_but.gameObject.SetActive(false); }
            else { 
            but_1_8.gameObject.SetActive(false);
            but_4_7.gameObject.SetActive(false);}
            
            but_100.gameObject.SetActive(false);
            but_200.gameObject.SetActive(false);
            but_500.gameObject.SetActive(false);
            number_text.gameObject.SetActive(false);
            
            lost_panel.gameObject.SetActive(true);
            settings_panel.gameObject.SetActive(false);
        }
        else {
            lost_menu_vis = false;
            settings_but.enabled = true;
            but_100.gameObject.SetActive(true);
            but_200.gameObject.SetActive(true);
            but_500.gameObject.SetActive(true);
            number_text.gameObject.SetActive(true);
            start_but.gameObject.SetActive(true);
            lost_panel.gameObject.SetActive(false);
        }

    }
    public void turnSetBut()
    {
        if (settings_vis == false)
        {
            settings_vis = true;
            settings_panel.gameObject.SetActive(true);
            if (start_vis) { start_but.gameObject.SetActive(false); }
            else
            {
                but_1_8.gameObject.SetActive(false);
                but_4_7.gameObject.SetActive(false);
            }
            but_100.gameObject.SetActive(false);
            but_200.gameObject.SetActive(false);
            but_500.gameObject.SetActive(false);
            number_text.gameObject.SetActive(false);
        }
        else
        {   if (rules_vis) { turnRules(); }
            settings_vis = false;
            if (start_vis) { start_but.gameObject.SetActive(true); }
            else
            {
                but_1_8.gameObject.SetActive(true);
                but_4_7.gameObject.SetActive(true);
            }
            settings_panel.gameObject.SetActive(false);
            but_100.gameObject.SetActive(true);
            but_200.gameObject.SetActive(true);
            but_500.gameObject.SetActive(true);
            number_text.gameObject.SetActive(true);
        }

    }
    public void selectRate(int num)
    {
        if (num == 100)
        {
            but_200.GetComponent<Image>().color = new UnityEngine.Color32(14, 130, 118, 255);
            but_100.GetComponent<Image>().color = new UnityEngine.Color32(0, 244, 255, 255);
            but_500.GetComponent<Image>().color = new UnityEngine.Color32(14, 130, 118, 255);
        }
        else if (num == 200)
        {
            
            but_200.GetComponent<Image>().color = new UnityEngine.Color32(0, 244, 255, 255);
            but_100.GetComponent<Image>().color = new UnityEngine.Color32(14, 130,118, 255);
            but_500.GetComponent<Image>().color = new UnityEngine.Color32(14, 130, 118, 255);
        }
        else if (num == 500)
        {
     
            but_200.GetComponent<Image>().color = new UnityEngine.Color32(14, 130, 118, 255);
            but_100.GetComponent<Image>().color = new UnityEngine.Color32(14, 130, 118, 255);
            but_500.GetComponent<Image>().color = new Color32(0, 244, 255, 255);

        }
    }
    public void turnMusic(bool val) {
        if (val == false)
        {
            music_but.GetComponent<Image>().sprite=cross;
        }
        else {
            music_but.GetComponent<Image>().sprite = gal;
        }
    }
    public void colorWin()
    {
        comment_text.color = new UnityEngine.Color32(55, 245, 8, 255);
        number_text.color = new UnityEngine.Color32(55, 245, 8, 255);
    }
    public void colorNorm()
    {
        comment_text.color = new UnityEngine.Color32(0, 244, 255, 255);
        number_text.color = new UnityEngine.Color32(0, 244, 255, 255);
    }
    public void colorLose()
    {
        comment_text.color = new UnityEngine.Color32(248, 0, 20, 255);
        number_text.color = new UnityEngine.Color32(248, 0, 20, 255);
    }
    public void turnEffects(bool val) {
        if (val == false)
        {
            effects_but.GetComponent<Image>().sprite = cross; 
        }
        else
        {
            effects_but.GetComponent<Image>().sprite = gal;
        }
    }

    public void turnRules(){
        if (settings_vis)
        {
            if (rules_vis)
            {
                music_text.gameObject.SetActive(true);
                effects_text.gameObject.SetActive(true);
                effects_but.gameObject.SetActive(true);
                music_but.gameObject.SetActive(true);
                rules_text.gameObject.SetActive(false);
                rules_vis = false;
            }
            else {
                music_text.gameObject.SetActive(false);
                effects_text.gameObject.SetActive(false);
                effects_but.gameObject.SetActive(false);
                music_but.gameObject.SetActive(false);
                rules_text.gameObject.SetActive(true);
                rules_vis = true;
            }
        }
    }
}
