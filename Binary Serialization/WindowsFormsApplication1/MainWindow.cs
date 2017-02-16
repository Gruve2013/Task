using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
namespace BinarySerialization
{
    public partial class MainWindow : Form
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Serialize_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowser.ShowDialog();
            if (res == DialogResult.OK)
            {
                
                Folder folder = Serialize.GetFolder(folderBrowser.SelectedPath);
                BinaryFormatter binFormat = new BinaryFormatter();
                using (FileStream stream = new FileStream("Binary file", FileMode.OpenOrCreate))
                {
                    binFormat.Serialize(stream, folder);
                }
                buttonDeserialize.Enabled = true;
                buttonSerialize.Enabled = false;
            }
        }

        private void Deserialize_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowser.ShowDialog();
            if (res == DialogResult.OK)
            {
                BinaryFormatter formater = new BinaryFormatter();
                using (FileStream stream = new FileStream("Binary file", FileMode.Open))
                {
                    Deserialize.CreateFolder(folderBrowser.SelectedPath, (Folder)formater.Deserialize(stream));
                }
                buttonDeserialize.Enabled = false;
                buttonSerialize.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
