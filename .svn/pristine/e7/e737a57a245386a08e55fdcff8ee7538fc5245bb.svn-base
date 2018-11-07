using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHC.Framework.Commons;
using WHC.Framework.BaseUI;

namespace ACA_System.UI
{
    public partial class FrmLogin : Form
    {
        public bool LoginState = false;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            ToolTip tp = new ToolTip();
            tp.SetToolTip(txtAccount, "默认登陆的调试账号为ACA");
            tp.SetToolTip(txtPassword, "默认调试密码为1");
            lblDate.Text = System.DateTime.Now.ToLongTimeString();
            AppConfig config = new AppConfig();
            this.Text = config.AppName;
            lblAppName.Text = config.AppName;
            if (this.txtAccount.Text != "")
            {
                txtPassword.Focus();
            }
            else txtAccount.Focus();
        }

        private void TxtAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (txtAccount.Text != "")
                {
                    txtPassword.Focus();
                }
                else
                {
                    MessageUtil.ShowWarning("账号不能为空，请输入登陆账号");
                    txtAccount.Focus();
                }
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (txtPassword.Text != "")
                {
                    //调用点击登陆按钮事件
                }
                else MessageUtil.ShowWarning("密码不能为空，请输入密码");

            }

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtAccount.Text!=null)
            {
                if(txtAccount.Text=="ACA" && txtPassword.Text=="123")
                {
                    this.DialogResult = DialogResult.OK;
                    LoginState = true;
                    return;
                }
                if (txtPassword.Text!=null)
                {
                    if (LoginJudge())  //判定为登陆成功
                    {
                        this.DialogResult = DialogResult.OK;
                        LoginState = true;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        LoginState = false;
                    }
                }
                
            }
        }
        public bool LoginJudge()  //从数据库中调入正确的账号和密码进行比对，来确认登入是否成功
        {
            return true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Application.ExitThread();
        }

        private void lklHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
