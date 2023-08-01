using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace TrierraTask
{
    public partial class Form2 : Form
    {
        private SqlConnection connection;

        public Form2(SqlConnection sqlConnection)
        {
            InitializeComponent();
            this.connection = sqlConnection;
            ParentTextBox.Text = null;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string parentName = ParentTextBox.Text;
            string childName = ChildTextBox.Text;
            try
            {
                connection.Open();
                var command = new SqlCommand("[dbo].[CreateNewParentWithChild] @ParentName, @ChildName", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@ParentName", parentName);
                if (ChildTextBox.Text != string.Empty)
                {
                    command.Parameters.AddWithValue("@ChildName", childName);
                }
                else
                {
                    command.Parameters.AddWithValue("@ChildName", DBNull.Value);
                }
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("New row was created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ParentTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (ParentTextBox.Text.Length > 50)
            {
                e.Cancel = true;
                MessageBox.Show("Parent name is too long", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ParentTextBox.Text.Length == 0)
            {
                e.Cancel = true;
                MessageBox.Show("Parent name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
