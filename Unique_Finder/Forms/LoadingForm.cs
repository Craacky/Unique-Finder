using System.Windows.Forms;

namespace Unique_Finder.Forms
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        public void UpdateLabel(string newText)
        {
            label1.Text = newText;
        }

        private void LoadingForm_Load(object sender, System.EventArgs e)
        {
            this.ControlBox = false;
            this.DoubleBuffered = true;
        }
    }
}
