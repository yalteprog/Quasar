using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int number;
    private int min_rate;
    private float score;
    public int rate;
    private int musicOn;
    private int effectsOn;
    public UIController uicont;
    public AudioController audiocont;

    void Start()
    {
        min_rate = 100;
        score = PlayerPrefs.GetFloat("score");
        if (score == 0) { score = 1000; }
        musicOn = PlayerPrefs.GetInt("music");
        effectsOn = PlayerPrefs.GetInt("effects");
        if (effectsOn == 0) {
            effectsOn = 1;
            turnEffects();
        }
        if (musicOn == 0)
        {
            musicOn = 1;
            turnMusic();
        }
        rate = min_rate;
        number = 0;
        uicont.setText(uicont.number_text, "" + number);
        uicont.setText(uicont.score_text, "" + score);
        uicont.selectRate(min_rate);
    }

    public void add1_8ToNumber()
    {
        if (number > 14 || number == 0)
        {

        }
        else
        {
            System.Random r = new System.Random();
            number += 1 + r.Next((int)8);
            uicont.setText(uicont.number_text, "" + number);
            checkWin();
        }

    }

    public void add4_7ToNumber()
    {
        if (number > 14 || number == 0)
        {

        }
        else
        {
            System.Random r = new System.Random();
            number += 4 + r.Next((int)4);
            uicont.setText(uicont.number_text, "" + number);
            checkWin();
        }
    }

    public void startset()
    {
        
        if (number > 14 || number == 0)
        {
            
            bool rate_suc = doRate();
            if (rate_suc)
            {
                uicont.colorNorm();
                uicont.turnStartBut();
                uicont.setText(uicont.comment_text, "");
                number = 0;


                System.Random r = new System.Random();
                number += 1 + r.Next((int)5);
                uicont.setText(uicont.number_text, "" + number);
            }
        }
    }

    private bool doRate()
    {

        if (score < rate)
        {
            if (score < min_rate)
            {
                uicont.turnLostMenu();
                return false;
            }
            return false;
        }
        else
        {
            score -= rate;
            uicont.setText(uicont.score_text, "" + score);
            PlayerPrefs.SetFloat("score", score);
            return true;
        }

    }

    public void restart()
    {
       uicont.turnLostMenu();
        score = 1000;
        uicont.setText(uicont.score_text, "" + score);
        PlayerPrefs.SetFloat("score", score);
    }

    public void checkWin()
    {

        if (number > 14)
        {
            uicont.turnStartBut();
            if (number == 15)
            {

                setWin(0.25, rate);
            }
            else if (number == 16)
            {
                setWin(0.5, rate);
            }
            else if (number == 17)
            {
                setWin(1, rate);
            }
            else if (number == 18)
            {
                setWin(1.25, rate);
            }
            else if (number == 19)
            {
                setWin(1.5, rate);
            }
            else if (number == 20)
            {
                setWin(2, rate);
            }
            else { setWin(0, rate); }
        }
    }

    private void setWin(double mult, int rate)
    {

        if (mult == 0) { uicont.setText(uicont.comment_text, "You lost(-" + rate + ")");
        uicont.colorLose();
        }
        else if (mult == 0.25) { uicont.setText(uicont.comment_text, "You lost(-" + rate * 0.75 + ")");
        uicont.colorLose();
        }
        else if (mult == 0.5) { uicont.setText(uicont.comment_text, "You lost(-" + rate * 0.5 + ")");
        uicont.colorLose();
        }
        else if (mult == 1) { uicont.setText(uicont.comment_text, "You Won(+" + 0 + ")");
        uicont.colorWin();
        }
        else if (mult == 1.25) { uicont.setText(uicont.comment_text, "You Won(+" + rate * 0.25 + ")");
        uicont.colorWin();
        }
        else if (mult == 1.5) { uicont.setText(uicont.comment_text, "You Won(+" + rate * 0.5 + ")");
        uicont.colorWin();
        }
        else if (mult == 2) { uicont.setText(uicont.comment_text, "You Won(+" + rate + ")");
        uicont.colorWin();
        }
        score += (float)(mult * rate);
        uicont.setText(uicont.score_text, "" + score);
        PlayerPrefs.SetFloat("score", score);
    }

    public void changeRate(int new_rate)
    {
        if (number > 14 || number == 0)
        {
            rate = new_rate;
            uicont.selectRate(new_rate);
        }
    }

    public void turnMusic() {
        if (musicOn == 1) {
            musicOn = 0;
            PlayerPrefs.SetInt("music", musicOn);
            audiocont.turnBackMusicOff();
            uicont.turnMusic(false);
        }
        else {
            musicOn = 1;
            PlayerPrefs.SetInt("music", musicOn);
            audiocont.turnBackMusicOn();
            uicont.turnMusic(true);
        }
    }

    public void turnEffects() {
        if (effectsOn == 1)
        {
            effectsOn = 0;
            PlayerPrefs.SetInt("effects", effectsOn);
            audiocont.turnEffectsOff();
            uicont.turnEffects(false);
        }
        else {
            effectsOn = 1;
            PlayerPrefs.SetInt("effects", effectsOn);
            audiocont.turnEffectsOn();
            uicont.turnEffects(true);
        }
    }
    public void turnRules() { uicont.turnRules(); }
}
