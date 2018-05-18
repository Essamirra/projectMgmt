using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projman_client
{
    public partial class EditUserView : IBaseView
    {
        public EditUserView(User user)
        {
            InitializeComponent();
        }
    }
}
