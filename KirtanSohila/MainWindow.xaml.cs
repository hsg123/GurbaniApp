using System;
using System.Collections.Generic;
using System.Linq;
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
        public MainWindow()
        {
            dic = new Dictionary();
            InitializeComponent();
            gBani = new List<string>();
            tBani = new List<string>(); 
            eBani = new List<string>();
            p = ((StackPanel)this.FindName("gurbaniPanel"));
            FileReader f = new FileReader();
            f.GetContent(gBani, tBani, eBani);
            setGui();
        }

        public void setGui() {

            for (int i = 0; i < gBani.Count; i++)
            {
                addLabel(gBani[i],false,true);
                addLabel(tBani[i],false,false);
                addLabel(eBani[i],true,false);
            }
            
        }

        public void addLabel(String content, bool eng, bool gurmukhi) {

        
          
            if (gurmukhi)
            {
                WrapPanel pw = new WrapPanel();
                string[] words = content.Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    l = new Label();
                    l.MouseEnter += new MouseEventHandler(mouse_Enter);
                    //l.Padding = new Thickness(0);
                    //l.Margin = new Thickness(0);
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
            Label label = ((Label)this.FindName("dictionaryLabel"));
            Word w = dic.GetDef(s);
            label.Content += w.Gurmukhi + "," + 
                w.Trans + "," + w.Eng + "," + w.Def;
        }


    }
}
