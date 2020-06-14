using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewApplication
{
    [TestFixture]
    public partial class CRUD : MetroFramework.Forms.MetroForm
    {
        //Create, read, update and delete
        //Създай, прочети, обнови и изтрий
        //Публичен метод CRUD() - иницялизира
        //метод InitializeComponent()
        //той държи всички данни за стартитане на Form.cs
        public CRUD()
        {
            //Метод InitializeComponent() 
            InitializeComponent();
        }

        [Test]
        public void ProstoTest()
        {
            var sum = 10;
            Assert.AreEqual(sum, 10);
        }

        [Test]
        //При зареждане на нова форма се използва метод 
        //Form1_Load(object sender, EventArgs e)
        private void Form1_Load(object sender, EventArgs e)
        {
            //сездавам нов обект db (DataBase) от тип ModelContext
            using (ModelContext db = new ModelContext())
            {
                //Достъпваме информация за базата чрез employeeBindingSource.DataSource
                //И го записваме базата данни в списък
                employeeBindingSource.DataSource = db.EmpList.ToList();
                //Компонентен тест за сравняване на стойности
                Assert.AreEqual(employeeBindingSource.DataSource, db.EmpList.ToList());
            }
            //Главен панел metroPanel е включен
            metroPanel.Enabled = true;
            //Главен панел metroPanel е включен
            Employee obj = employeeBindingSource.Current as Employee;
            if (obj != null)
            {
                try
                {
                    pic.Image = Image.FromFile(obj.ImageUrl);
                }
                catch
                {
                    pic.Image = null;
                }
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pic.Image = Image.FromFile(ofd.FileName);
                    Assert.AreEqual(pic.Image, Image.FromFile(ofd.FileName));
                    Employee obj = employeeBindingSource.Current as Employee;
                    if (obj != null)
                    {
                        obj.ImageUrl = ofd.FileName;
                        Assert.AreEqual(obj.ImageUrl, ofd.FileName);
                    }
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            pic.Image = null;
            metroPanel.Enabled = true;
            employeeBindingSource.Add(new Employee());
            employeeBindingSource.MoveLast();
            txt1Name.Focus();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            metroPanel.Enabled = true;
            txtName.Focus();
            Employee obj = employeeBindingSource.Current as Employee;
        }

        private void metroTextBox3_Click(object sender, EventArgs e)
        {
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            metroPanel.Enabled = false;
            employeeBindingSource.ResetBindings(false);
            Form1_Load(sender, e);
        }


        private void metroGrid_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Сигурен ли си че искаш да изтриеш този запис?", "Меssage", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (ModelContext db = new ModelContext())
                {
                    Employee obj = employeeBindingSource.Current as Employee;
                    if (obj != null)
                    {
                        if (db.Entry<Employee>(obj).State == EntityState.Detached)
                            db.Set<Employee>().Attach(obj);
                        db.Entry<Employee>(obj).State = EntityState.Deleted;
                        db.SaveChanges();
                        MetroFramework.MetroMessageBox.Show(this, "Изтриването е успешно!");
                        employeeBindingSource.RemoveCurrent();
                        metroPanel.Enabled = true;
                        pic.Image = null;
                        pictureBox1.Image = null;
                    }
                }
            }
        }

        private void metroGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Employee obj = employeeBindingSource.Current as Employee;
            if (obj != null)
            {
                try
                {
                    pic.Image = Image.FromFile(obj.ImageUrl);
                    pictureBox1.Image = Image.FromFile(obj.ImageUrl1);
                    pictureBox2.Image = Image.FromFile(obj.ImageUrl4);
                    pictureBox3.Image = Image.FromFile(obj.ImageUrl3);
                    pictureBox4.Image = Image.FromFile(obj.ImageUrl2);
                }
                catch
                {
                    pic.Image = null;
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                    pictureBox3.Image = null;
                    pictureBox4.Image = null;
                }
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            using (ModelContext db = new ModelContext())
            {
                Employee obj = employeeBindingSource.Current as Employee;
                if (obj != null)
                {
                    if (db.Entry<Employee>(obj).State == EntityState.Detached)
                        db.Set<Employee>().Attach(obj);
                    if (obj.EmpID == 0)
                        db.Entry<Employee>(obj).State = EntityState.Added;
                    else
                        db.Entry<Employee>(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    MetroFramework.MetroMessageBox.Show(this, "Записано успешно!");
                    metroGrid.Refresh();
                    metroPanel.Enabled = true;
                }
            }
        }

        private void txtDob_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Employee obj = employeeBindingSource.Current as Employee;
            if (obj != null)
            {
                try
                {
                    pic.Image = Image.FromFile(obj.ImageUrl1);
                }
                catch
                {
                    pic.Image = null;
                }
            }
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                    Employee obj = employeeBindingSource.Current as Employee;
                    if (obj != null)
                    {
                        obj.ImageUrl1 = ofd.FileName;
                    }
                }
            }
        }



        private void metroButton7_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox4.Image = Image.FromFile(ofd.FileName);
                    Employee obj = employeeBindingSource.Current as Employee;
                    if (obj != null)
                    {
                        obj.ImageUrl2 = ofd.FileName;
                    }
                }
            }
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox3.Image = Image.FromFile(ofd.FileName);
                    Employee obj = employeeBindingSource.Current as Employee;
                    if (obj != null)
                    {
                        obj.ImageUrl3 = ofd.FileName;
                    }
                }
            }
        }
        private void metroButton9_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image = Image.FromFile(ofd.FileName);
                    Employee obj = employeeBindingSource.Current as Employee;
                    if (obj != null)
                    {
                        obj.ImageUrl4 = ofd.FileName;
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Employee obj = employeeBindingSource.Current as Employee;
            if (obj != null)
            {
                try
                {
                    pic.Image = Image.FromFile(obj.ImageUrl4);
                }
                catch
                {
                    pic.Image = null;
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Employee obj = employeeBindingSource.Current as Employee;
            if (obj != null)
            {
                try
                {
                    pic.Image = Image.FromFile(obj.ImageUrl3);
                }
                catch
                {
                    pic.Image = null;
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Employee obj = employeeBindingSource.Current as Employee;
            if (obj != null)
            {
                try
                {
                    pic.Image = Image.FromFile(obj.ImageUrl2);
                }
                catch
                {
                    pic.Image = null;
                }
            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
