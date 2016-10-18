using System.Collections.Generic;
namespace morse
{
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            combo(textBox1.Text,false);//syöttää textbox6.tekstin
            textBox2.Text = tulos;//laitetaan tulos textbox7 kenttään
        }
        //Morse-aakkoset
        public string tulos = "";
        //alustetaan käyttämät kirjaimet/numerot
        string[] teksti = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        //alustetaan morse_aakoset tarkoittamat merkit teksti taulukon kanssa
        string[] morse_aakkoset = { "sha","ni","ki","que","nay","qui","ti","la","kay","ri","barack","obama","di","ta","ee","ray","cli","gurl","na","qua","kwa","ise","fi","quee","mi","si" };
        List<string> teksti1 = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };//list all languanges
        List<string> morse_aakkoset1 = new List<string>() { "sha", "ni", "ki", "que", "nay", "qui", "ti", "la", "kay", "ri", "barack", "obama", "di", "ta", "ee", "ray", "cli", "gurl", "na", "qua", "kwa", "ise", "fi", "quee", "mi", "si" };
        private void Morse_muuta(string taulu)
        {
            tulos = "";
            //taulu = textbox6.text
            //teksti taulukko
            //morse_aakkoset taulukko
            for (int i = 0; i < taulu.Length; i++)//esim aaa = taulu.length[3]
            {
                for (int ii = 0; ii < teksti.Length; ii++)//käy läpi teksti taulukon
                {
                    //jos löytyy sama merkki taulu[i] == taulu[ii] kohdassa, 
                    //laitetaan tulokseen morse_aakkoset[ii] taulusta oleva merkki
                    //koska ii on sama kummassakin taulukossa
                    if (taulu[i].ToString() == teksti[ii] || taulu[i].ToString() == teksti[ii].ToUpper())//käy pienet ja isot kirjaimet läpi
                    {
                        tulos += " " + morse_aakkoset[ii];//tulostaa vastauksen tulos stringiin
                    }
                }
            }
        }
        private void Morse_muuta1(string taulu)
        {
            tulos = "";
            for (int i = 0; i < taulu.Length; i++)
            {
                tulos += morse_aakkoset1[teksti1.FindIndex(x => x.StartsWith(taulu[i].ToString()))]+" ";
            }
            
        }
        private void Morse_decode(string taulu)
        {
            tulos = "";
            //taulu = textbox6.text
            //teksti taulukko
            //morse_aakkoset taulukko
            string[] tmp = taulu.Split(' ');
            
            for (int i = 0; i < tmp.Length; i++)//esim aaa = taulu.length[3]
            {
                for (int ii = 0; ii < morse_aakkoset.Length; ii++)//käy läpi teksti taulukon
                {
                    //jos löytyy sama merkki taulu[i] == taulu[ii] kohdassa, 
                    //laitetaan tulokseen morse_aakkoset[ii] taulusta oleva merkki
                    //koska ii on sama kummassakin taulukossa
                    if (tmp[i].ToString() == morse_aakkoset[ii] || tmp[i].ToString() == morse_aakkoset[ii].ToUpper())//käy pienet ja isot kirjaimet läpi
                    {
                        tulos += " " + teksti[ii];//tulostaa vastauksen tulos stringiin
                    }
                }
            }
        }
        private void Morse_decode1(string taulu)
        {
            tulos = "";
            string[] tmp = taulu.Split(' ');
            for (int i = 0; i < tmp.Length-1; i++)
            {
                tulos += teksti1[morse_aakkoset1.FindIndex(x => x.EndsWith(tmp[i]))];
            }
        }
        private void combo(string taulu, bool decode)
        {
            tulos = "";
            string[] tmp = taulu.Split(' ');
            int taulunkoko=taulu.Length;
            if (decode) { taulunkoko = tmp.Length - 1; }
            for (int i = 0; i < taulunkoko; i++)
            {
                if (!decode) tulos += morse_aakkoset1[teksti1.FindIndex(x => x.StartsWith(taulu[i].ToString()))] + " ";//encode
                else                 tulos += teksti1[morse_aakkoset1.FindIndex(x => x.EndsWith(tmp[i]))];//decode
            }

        }

        private void button2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            combo(textBox2.Text,true);//syöttää textbox6.tekstin
            textBox1.Text = tulos;//laitetaan tulos textbox7 kenttään
        }

        bool test = true;
        private void button3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (test)
            {
                Morse_muuta(textBox1.Text);//syöttää textbox6.tekstin
                textBox2.Text = tulos;//laitetaan tulos textbox7 kenttään
                test = false;
            }
            else
            {
                Morse_decode(textBox2.Text);//syöttää textbox6.tekstin
                textBox1.Text = tulos;//laitetaan tulos textbox7 kenttään
                test = true;
            }
        }
        //Morse-aakkoset
    }
}
