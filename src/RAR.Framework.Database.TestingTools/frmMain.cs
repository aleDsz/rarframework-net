using System;
using System.Windows.Forms;
using System.Data;
using RAR.Framework.Database.TestingTools.Entities;
using RAR.Framework.Database.Service;
using RAR.Framework.Database.Data;
using System.Collections.Generic;

namespace RAR.Framework.Database.TestingTools
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void cmd0_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            user.Login = "xadee.13@gmail.com";

            try
            {
                using (DataContext Data = new DataContext())
                {
                    List<Usuario> objRetorno;

                    Data.BeginTransaction(IsolationLevel.ReadUncommitted);

                    using (SelectService<Usuario> SelectService = new SelectService<Usuario>(user))
                    {
                        objRetorno = SelectService.Execute();
                        Data.CommitTransaction();
                    }

                    if (objRetorno != null)
                        foreach (var obj in objRetorno)
                            MessageBox.Show(obj.CPF);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmd1_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            user.Login = "xadee.13@gmail.com";
            user.Senha = "teste";

            try
            {
                using (DataContext Data = new DataContext())
                {
                    Data.BeginTransaction(IsolationLevel.ReadUncommitted);
                    using (InsertService InsertService = new InsertService(user))
                    {
                        InsertService.Execute();
                        Data.CommitTransaction();
                    }
                    MessageBox.Show("Usuário inserido");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}