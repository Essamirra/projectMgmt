﻿using System;
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
    public partial class EditProjectView : IBaseView
    {
        public EditProjectView(Project project)
        {
            InitializeComponent();
        }
    }
}
