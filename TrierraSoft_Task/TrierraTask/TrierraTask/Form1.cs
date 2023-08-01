using System.Data;
using System.Data.SqlClient;

namespace TrierraTask
{
    public partial class Form1 : Form
    {
        private const string stringConnection = "Data Source=DESKTOP-T1O7SGL;Database=TrierraSoft;Trusted_Connection=True;MultipleActiveResultSets=true";
        private SqlConnection sqlConnection;
        private SqlCommand command;
        private SqlDataAdapter sda;
        private DataTable table;
        public string currentValue = string.Empty;

        public Form1()
        {
            InitializeComponent();
            BindDataGrid();
            dataGridView1.Columns["ParentID"].ReadOnly = true;
            dataGridView1.Columns["ChildID"].ReadOnly = true;
        }

        private void BindDataGrid()
        {
            sqlConnection = new SqlConnection(stringConnection);
            command = new SqlCommand("SELECT * FROM [dbo].[GetAll]");
            command.CommandType = CommandType.Text;
            command.Connection = this.sqlConnection;
            sda = new SqlDataAdapter(command);
            table = new DataTable();
            sda.Fill(this.table);
            dataGridView1.DataSource = this.table;
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var columnHeader = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                if (columnHeader.Contains("Parent"))
                {
                    sda.UpdateCommand = new SqlCommand(
                      "UPDATE Parent SET ParentName = @ParentName " +
                      "WHERE ParentID = @ParentID", sqlConnection);

                    sda.UpdateCommand.Parameters.Add("@ParentName", SqlDbType.VarChar, 50, "ParentName");

                    SqlParameter parameter = sda.UpdateCommand.Parameters.Add("@ParentID", SqlDbType.Int);
                    parameter.SourceColumn = "ParentID";
                    parameter.SourceVersion = DataRowVersion.Original;

                }
                else if (columnHeader.Contains("Child"))
                {
                    var childIdHeaderIndex = dataGridView1.Columns["ChildID"].Index;
                    var childID = dataGridView1.Rows[e.RowIndex].Cells[childIdHeaderIndex].Value.ToString();
                    if (string.IsNullOrEmpty(childID))
                    {
                        MessageBox.Show("Child doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        BindDataGrid();
                        return;
                    }

                    sda.UpdateCommand = new SqlCommand(
                      "UPDATE Child SET ChildName = @ChildName " +
                      "WHERE ChildID = @ChildID", sqlConnection);

                    sda.UpdateCommand.Parameters.Add("@ChildName", SqlDbType.VarChar, 50, "ChildName");

                    SqlParameter parameter = sda.UpdateCommand.Parameters.Add("@ChildID", SqlDbType.Int);
                    parameter.SourceColumn = "ChildID";
                    parameter.SourceVersion = DataRowVersion.Original;
                }

                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                DataRow dataRow = dataTable.Rows[e.RowIndex];
                dataRow[columnHeader] = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                sda.Update(dataTable);
                currentValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(sqlConnection);
            form2.ShowDialog();
            BindDataGrid();
        }

        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
            {
                currentValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                if (string.IsNullOrEmpty(currentValue))
                {
                    MessageBox.Show("Name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }
    }
}
