using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LingYi_Photography
{
    public partial class AdministratorInformation : Form
    {
        readonly Administrator administrator;
        public AdministratorInformation(Administrator administrator)
        {
            this.administrator = administrator;
            InitializeComponent();
        }

        private void AdministratorInformation_Load(object sender, EventArgs e)
        {

        }
    }
}
