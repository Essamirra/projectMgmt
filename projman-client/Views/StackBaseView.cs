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
    public partial class StackBaseView : UserControl
    {
        public StackBaseView() : this(new LoginView())
        { }

        public StackBaseView(IBaseView init_view)
        {
            InitializeComponent();
            stack_.Push(init_view);
            stack_.Peek().WantBack += back_button_Click;
            stack_.Peek().WantOpenView += navigate;
            updateBaseView();
        }

        private void navigate(object sender, BaseViewArgs args)
        {
            stack_.Peek().WantOpenView -= navigate;
            stack_.Peek().WantBack -= back_button_Click;
            stack_.Push(args.View);
            stack_.Peek().WantBack += back_button_Click;
            stack_.Peek().WantOpenView += navigate;
            updateBaseView();
        }

        private void updateBaseView()
        {
            content_panel.Controls.Clear();
            content_panel.Controls.Add(stack_.Peek());
            stack_.Peek().Dock = DockStyle.Fill;
            Refresh();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            if (stack_.Count > 1)
            {
                stack_.Peek().WantOpenView -= navigate;
                stack_.Pop();
                stack_.Peek().WantOpenView += navigate;
                updateBaseView();
            }
        }


        private Stack<IBaseView> stack_ = new Stack<IBaseView>();
    }
}
