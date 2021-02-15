using LambentLight.GUI.Api;
using System.Windows.Forms;

namespace LambentLight
{
    public partial class FormManager : Form
    {
        #region Field

        private readonly Client client = null;

        #endregion

        #region Constructor

        public FormManager(string host, string token)
        {
            InitializeComponent();

            Text = Text + " " + host;
            client = new Client(host, token);
        }

        #endregion
    }
}
