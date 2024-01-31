using registerapi.Models;
using System.Windows.Forms;

namespace registerapi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new registrationContext())
            {
                dataGridView1.DataSource = context.Infos.ToList();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new registrationContext())
            {
                try
                {
                    context.Remove(context.Infos.SingleOrDefault(b => b.Id == int.Parse(textBox1.Text)));
                    context.SaveChanges();
                    MessageBox.Show("Information Deleted successfully..");
                    Form1_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("cannot delete Information please Verify ID");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new registrationContext())
            {
                try
                {
                    var task = context.Infos.SingleOrDefault(t => t.Id == int.Parse(textBox1.Text));
                    if (task != null)
                    {
                        if(textBox4.Text != null && textBox2.Text != null && textBox3.Text != null)
                        {
                            task.Name = textBox2.Text;
                            task.Email = textBox3.Text;
                            task.Profession = textBox4.Text;
                            task.Dateofbirth = dateTimePicker1.Value;
                            
                        }

                        context.SaveChanges();
                        MessageBox.Show("data Updated Successfully...");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                      
                        Form1_Load(sender, e);
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot Fetch Data with Given Id..");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var context = new registrationContext())
            {
                try
                {
                    var task = context.Infos.Single(t => t.Id == int.Parse(textBox1.Text));
                    if (task != null)
                    {
                        textBox2.Text = task.Name;
                        textBox3.Text = task.Email;
                        textBox4.Text = task.Profession;
                        dateTimePicker1.Value = Convert.ToDateTime(task.Dateofbirth);
                        MessageBox.Show("Data retrived Successfully..");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot Fetch Data with Given Id");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //adding task details in task table
            Models.Info t = new Models.Info();
            t.Name = textBox2.Text;
            t.Email = textBox3.Text;
            t.Profession = textBox4.Text;
            t.Dateofbirth = dateTimePicker1.Value;

            var context = new registrationContext();
            context.Infos.Add(t);
            context.SaveChanges();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            Form1_Load(sender, e);
            MessageBox.Show("information added Successfully ");
        }
    }
}