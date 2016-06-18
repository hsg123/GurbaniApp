using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KirtanSohila
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<String> gBani, tBani, eBani;
        //private WrapPanel p;
        private StackPanel p;
        private Label l;
        private Dictionary dic;
        private WMPLib.WindowsMediaPlayer wPlayer;
        public MainWindow()
        {
            dic = new Dictionary();
            InitializeComponent();
            gBani = new List<string>();
            tBani = new List<string>(); 
            eBani = new List<string>();
            p = ((StackPanel)this.FindName("gurbaniPanel"));
            FileReader f = new FileReader();
            wPlayer = new WMPLib.WindowsMediaPlayer();
            f.GetContent(gBani, tBani, eBani);
            setGui();
        }

        public void setGui() {

            for (int i = 0; i < gBani.Count; i++)
            {
                addLabel(gBani[i],false,true,i);
                addLabel(tBani[i],false,false,i);
                addLabel(eBani[i],true,false,i);
            }
            
        }

        public void addLabel(String content, bool eng, bool gurmukhi,int index) {
            if (gurmukhi)
            {
                WrapPanel pw = new WrapPanel();
                string[] words = content.Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    l = new Label();
                    l.MouseEnter += new MouseEventHandler(mouse_Enter);
                    l.MouseDown += new MouseButtonEventHandler(mouse_Down);
                    l.Padding = new Thickness(4, 0, 4, 0);
                    l.Tag = index.ToString();
                    l.Content = word;
                    pw.Children.Add(l);
                }
                p.Children.Add(pw);
            }
            else
            {
                l = new Label();
                l.Content = content;
                if (eng)
                    l.Padding = new Thickness(0, 0, 0, 10);
                else
                    l.Padding = new Thickness(0);
                l.Margin = new Thickness(0);
                p.Children.Add(l);
            }
        }

        void mouse_Enter(object sender, EventArgs e)
        {
            String s = (String)(((Label)sender).Content);
            RichTextBox label = ((RichTextBox)this.FindName("dictionaryLabel"));
            List<Word> w = dic.GetDef(s);
            label.Document.Blocks.Clear();
            if (w != null)
            {
                foreach( Word word in w){
                    label.Document.Blocks.Add(new Paragraph(new Run(word.Gurmukhi + "," +
                    word.Trans + "," + word.Eng + "," +
                    Environment.NewLine + Environment.NewLine)));
                }
            }else
            {
                label.Document.Blocks.Add(new Paragraph(new Run("Defintion not found in dictionary")));
            }
            
        }
        
        void mouse_Down(object sender, EventArgs e)
        {
            //String word = (String)(((Label)sender).Content);
            String line = (String)(((Label)sender).Tag);
            if (File.Exists(@"soundFiles\" + line + ".mp3"))
            {
                wPlayer.URL = @"soundFiles\" + line + ".mp3";
                wPlayer.controls.play();
            }
        }


    }
}
