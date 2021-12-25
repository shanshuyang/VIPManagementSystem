using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Admin;

namespace LingYi_Photography
{
    public partial class FormAdministratorInformation : Form
    {
        readonly Administrator administrator;
        public FormAdministratorInformation(Administrator administrator)
        {
            this.administrator = administrator;
            InitializeComponent();
        }
        


        private void AdministratorInformation_Load(object sender, EventArgs e)
        {

        }
    }
}
