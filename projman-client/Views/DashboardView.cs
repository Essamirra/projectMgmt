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
    public partial class DashboardView : IBaseView
    {
        public DashboardView()
        {
            InitializeComponent();
            presenter_ = new DashboardPresenter(this); 
        }

        public void SetButtons(List<string> buttons_text)
        {
            int size = buttons_text.Count;
            buttons_layout.Controls.Clear();
            buttons_layout.RowCount = size;
            for (int i = 0; i < size; ++i)
            {
                buttons_layout.RowStyles[i].Height = 1.0f;
                buttons_layout.RowStyles[i].SizeType = SizeType.Percent;
                Button button = new Button();
                button.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, 
                    FontStyle.Bold | FontStyle.Italic,
                    GraphicsUnit.Point, ((byte)(204)));
                button.UseVisualStyleBackColor = true;
                button.Text = buttons_text[i];
                button.Anchor = AnchorStyles.None;
                button.Width = 300;
                button.Height = 80;

                buttons_layout.Controls.Add(button, 0, i);

                int index = i;
                button.Click += (s, e) => presenter_.onButtonClick(index);
            } 
        }

        public void Navigate(IBaseView view)
        {
            navigate(view);
        }

        DashboardPresenter presenter_;
    }
}
