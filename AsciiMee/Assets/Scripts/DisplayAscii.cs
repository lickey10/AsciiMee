using UnityEngine;
using System.Collections;
using System;

public class DisplayAscii : MonoBehaviour {
    public UnityEngine.UI.Text txtResults;
    public UnityEngine.UI.InputField txtResults2;
    public Texture2D picture;

    // Use this for initialization
    void Start () {
        if(picture != null)
        {
            //convert picture to ascii
            txtResults.text = ConvertToAscii(picture);
            txtResults2.text = txtResults.text;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public static string ConvertToAscii(Texture2D image)
    {
        //Bitmap image = byteArrayToImage(imageArray);
        bool toggle = false;
        string sb = "";

        for (int h = image.height - 1; h >= 0 ; h--)
        {
            for (int w = 0; w < image.width; w++)
            {
                if (w % 2 == 0)
                {
                    Color pixelColor = image.GetPixel(w, h);
                    //Average out the RGB components to find the Gray Color
                    //int red = (int)((pixelColor.r + pixelColor.g + pixelColor.b) * 1000) / 3;
                    //int green = (int)((pixelColor.r + pixelColor.g + pixelColor.b) * 1000) / 3;
                    //int blue = (int)((pixelColor.r + pixelColor.g + pixelColor.b) * 1000) / 3;
                    //Color grayColor = new Color(red, green, blue);

                    //Use the toggle flag to minimize height-wise stretch
                    if (!toggle)
                    {
                        //int index = (int)(grayColor.r * 10) / 255;
                        //sb.Append(_AsciiChars[index]);
                        sb += string.Format("{3}", pixelColor.r, pixelColor.g, pixelColor.b, getAsciiChar((int)(pixelColor.grayscale * 1000)));
                    }
                }
            }
            if (!toggle)
            {
                //sb.Append("<BR>");
                sb += Environment.NewLine;
                toggle = true;
            }
            else
            {
                toggle = false;
            }
        }

        return sb.ToString();
    }

    private static string getAsciiChar(int alpha)
    {
        if (alpha >= 750)//white or very light
            return " ";
        if (alpha >= 600)
            return ",";
        if (alpha >= 560)
            return "1";
        if (alpha >= 520)
            return "!";
        if (alpha >= 480)
            return "\"";
        if (alpha >= 440)
            return "+";
        if (alpha >= 400)
            return "}";
        if (alpha >= 360)
            return "*";
        if (alpha >= 320)
            return "^";
        if (alpha >= 280)
            return ":";
        if (alpha >= 240)
            return "|";
        if (alpha >= 200)
            return "L";
        if (alpha >= 180)
            return ">";
        if (alpha >= 160)
            return "D";
        if (alpha >= 140)
            return "X";
        if (alpha >= 120)
            return "W";
        if (alpha >= 100)
            return "9";
        if (alpha >= 80)
            return "%";
        if (alpha >= 60)
            return "$";
        if (alpha >= 40)
            return "@";

        //if (alpha == 1)
        //    return '@';
        //if (alpha == 2)
        //    return '$';
        //if (alpha == 3)
        //    return '%';
        //if (alpha == 4)
        //    return '|';
        //if (alpha == 5)
        //    return '!';
        //if (alpha == 6)
        //    return ':';
        //if (alpha == 7)
        //    return '\'';
        //if (alpha == 8)
        //    return ';';
        //if (alpha == 9)
        //    return ' ';

        return "&";//very dark
    }
}
