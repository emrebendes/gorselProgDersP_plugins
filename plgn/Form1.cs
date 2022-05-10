using System.Reflection;
using Islem;
using static Islem.Islem;

namespace plgn
{
    public partial class Form1 : Form
    {
        List<IHesap> pluginler = new List<IHesap>();
        public Form1()
        {
            
            InitializeComponent();
            PluginYukle(@".\plgns");
        }

        void PluginYukle(String yol)
        { 
            String[] dosyalar = Directory.GetFiles(yol,"*.dll");
    
            foreach (String s in dosyalar)
            { 
                Assembly asm = Assembly.LoadFrom(s);
                Type[] t = asm.GetTypes();
                foreach (Type t2 in t)
                {
                    
                    if (t2.IsClass && typeof(Islem.Islem.IHesap).IsAssignableFrom(t2))
                    {
                        IHesap nesne  = (IHesap)Activator.CreateInstance(t2);
                        pluginler.Add( nesne );
                        listBox1.Items.Add(nesne.Isim);
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IHesap HesapYap = pluginler[listBox1.SelectedIndex];
            int snc = HesapYap.Hesapla(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            label1.Text = snc.ToString();
        }
    }
}