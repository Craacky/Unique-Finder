using System.Windows.Forms;

namespace Unique_Finder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
        }

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "Вы уверены, что хотите закрыть приложение?",
                "Подтверждение закрытия",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
