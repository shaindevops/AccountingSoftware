using System.Windows.Forms;

namespace SSG
{
    public class msgclass
    {
        public DialogResult MyMessagebox(string title, string eninfo, int buttons, int type)
        {
            FrmMsg m = new FrmMsg();
            m.lbltitle.Text = title;
            m.lbltext.Text = eninfo;
            //مسیج باکس اطلاعات
            if (buttons == 0 && type == 0)
            {
                m.btnyes.Text = "Okey";
                m.btncancel.Visible = false;
                m.picicon.Image = Properties.Resources.inf;
            }
            //مسیج باکس بله و خیر
            else if (buttons == 1 && type == 1)
            {
                m.btnyes.Text = "Yes";
                m.btncancel.Text = "No";
                m.picicon.Image = Properties.Resources.ques;
            }
            //مسیج باکس ارور
            else if (buttons == 2 && type == 2)
            {
                m.btnyes.Text = "Okey";
                m.btncancel.Visible = false;
                m.picicon.Image = Properties.Resources.err;
            }
            //مسیج باکس اخطار
            else if (buttons == 3 && type == 3)
            {
                m.btnyes.Text = "Okey";
                m.btncancel.Visible = false;
                m.picicon.Image = Properties.Resources.Warn;
            }
            m.ShowDialog();
            return m.DialogResult;
        }
    }
}
