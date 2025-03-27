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
                        dati= new DNDListRow() { Id=0};

                    }
                    //frm.UzstādaDatus(  new DNDModelForBinding() { Name = "das" ,UserName="abc"} );
                    //frm.DatuSaikne.DataSource = new List<DNDModelForBinding> { new DNDModelForBinding() { Name="das"} ,  
                    //   };
                    frm.UzstādaDatus(DatuBāze.DabūtDbInstanci.NolasītDNDIerakstu(dati.Id)??new DNDModelForBinding { UserName="ABC" }
                        );
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
        }
    
    }
}
