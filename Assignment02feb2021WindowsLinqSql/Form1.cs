using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment02feb2021WindowsLinqSql
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {         
        }
        private void GetData()
        {
            DMLQueriesDataContext dbml = new DMLQueriesDataContext();
            dataGridView1.DataSource = dbml.AdoEmps;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (DMLQueriesDataContext dbContext = new DMLQueriesDataContext())
            {
                AdoEmp newEmployee = new AdoEmp
                {
                    ename = "Hail Hydra",                   
                    esal = 55000,
                    depno = 100
                };

                dbContext.AdoEmps.InsertOnSubmit(newEmployee);
                dbContext.SubmitChanges();
            }

            GetData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (DMLQueriesDataContext dbContext = new DMLQueriesDataContext())
            {
                AdoEmp employee = dbContext.AdoEmps.SingleOrDefault(x => x.eid == 15);
                employee.esal = 65000;
                dbContext.SubmitChanges();
            }

            GetData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (DMLQueriesDataContext dbContext = new DMLQueriesDataContext())
            {
                AdoEmp employee = dbContext.AdoEmps.SingleOrDefault(x => x.eid == 15);
                dbContext.AdoEmps.DeleteOnSubmit(employee);
                dbContext.SubmitChanges();
            }

            GetData();
        }
    }
}
