using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.DataFormats;

namespace DnDCharacterSheet
{
    public partial class DNDList : Form
    {
        public DNDList()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var rinda = SarakstaTabula.Rows[e.RowIndex];
                //var proc = Process.GetProcesses().Where(x => x.ProcessName == "notepad").First();
                //IWin32Window w = Control.FromHandle(proc.MainWindowHandle);



                using (CharacterSheet frm = new CharacterSheet())
                {
                    var dati = rinda.DataBoundItem as DNDListRow;
                    if (dati == null)
                    {
                        dati = new DNDListRow() { Id = 0 };

                    }

                    frm.UzstādaDatus(DatuBāze.DabūtDbInstanci.NolasītDNDIerakstu(dati.Id) ?? new DNDModelForBinding());
                    //Uzliek atsauci uz izsaucošo formu, lai varētu atjaunināt datus sarakstā
                    frm.SarakstaForma = this;
                    frm.ShowDialog();
                }
            }
        }
        private List<DNDListRow> dati;
        private void DNDList_Load(object sender, EventArgs e)
        {
            if (Program.UserId == null)
            {
                //Nav piesledzies lietotājs
                this.Close();
                Application.Run(new LoginForm());
                return;
            }

            IelasītDatus();

        }
        public void IelasītDatus()
        {

            if (Program.UserId == null)
            {
                return;
            }
            dati = DatuBāze.DabūtDbInstanci.NolasītDNDSarakstu(Program.UserId.Value);
            dNDListRowBindingSource.DataSource = dati;
            dNDListRowBindingSource.ResetBindings(true);

            if (Program.IsAdmin)
            {

                var lietotaji = DatuBāze.DabūtDbInstanci.GetAllUses();
                systemUsersBindingSource.DataSource = lietotaji;
                systemUsersBindingSource.ResetBindings(true);
                
            } else
            {
                systemUsersBindingSource.DataSource = null;
                tabControl1.TabPages.Remove(tabPage2);

            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (e.RowIndex >= 0)
                {
                    var users = dataGridView1.Rows[e.RowIndex];

                    using (EditPassword frm = new EditPassword())
                    {
                        var dati = users.DataBoundItem as SystemUsers;
                        if (dati == null)
                        {
                            return;
                        }
                        frm.UserId = dati.UserId;
                        frm.ShowDialog();
                    }
                }

            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.RowIndex >= 0)
                {
                    var users = dataGridView1.Rows[e.RowIndex];

                    using (EditPassword frm = new EditPassword())
                    {
                        var dati = users.DataBoundItem as SystemUsers;
                        if (dati == null)
                        {
                            return;
                        }
                        DatuBāze.DabūtDbInstanci.UserSave(dati.UserId, dati.IsAdmin);
                    }
                }

            }
        }

        private void buttonAddDnd_Click(object sender, EventArgs e)
        {
            using (CharacterSheet frm = new CharacterSheet())
            { 
                frm.UzstādaDatus(  new DNDModelForBinding());
                //Uzliek atsauci uz izsaucošo formu, lai varētu atjaunināt datus sarakstā
                frm.SarakstaForma = this;
                frm.ShowDialog();
            }
        }
    }
}
