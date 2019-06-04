using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBrowser
{
    /// <summary>
    /// View page for browsing and searching movies
    /// </summary>
    public partial class MediaBrowser : Form
    {
        UserDTO _userDetails;
        IMediaManager mediaManager;
        DataTable _data;
        private Label lblTitle;
        private DataGridView mediaDataGrid;
        private TextBox txtSearch;
        private Label lblSearch;
        private ComboBox cmbxCriteria;
        private Label label1;
        private Button btnSearch;
        private Button btnClear;
        private Label lblMessages;
        List<string> columns;
        BindingSource bindingSource1;

        public MediaBrowser(UserDTO userDetails)
        {
            InitializeComponent();
            this._userDetails = userDetails;

            lblTitle.Text = string.Format("Welcome {0},", this._userDetails.UserName != "" ? this._userDetails.UserName : "User");
            this._userDetails = userDetails;
            mediaManager = new MediaManager();

            //lblTitle.Text = String.Format("Welcome {0}",userDetails.Tables[0].Rows[0]["username"]);
            DataSet data = mediaManager.QueryMovies();
            if (data.Tables.Count <= 0)
                throw new Exception("Error fetching data");

            this._data = data.Tables[0];
            PopulateMediaTable();
        }

        /// <summary>
        /// Fill the movies table on startup
        /// </summary>
        private void PopulateMediaTable()
        {
            bindingSource1 = new BindingSource();
            bindingSource1.DataSource = this._data;

            mediaDataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            mediaDataGrid.DataSource = bindingSource1;

            columns = ExtractColumnList();
            HideColumns(new List<string>() { "MediaID", "Genre", "Director", "Language" }, mediaDataGrid);

            cmbxCriteria.SelectedIndex = 0;
        }

        /// <summary>
        /// Extract all columns from a dataset's first/only table
        /// </summary>
        /// <returns></returns>
        private List<string> ExtractColumnList() {
            List<string> res = new List<string>();
            foreach (DataColumn col in this._data.Columns)
            {
                res.Add(col.ColumnName.ToString());
            }
            return res;
        }
        /// <summary>
        /// Hide columns on a given data grid view
        /// </summary>
        /// <param name="columnsListToHide"></param>
        /// <param name="dataGridView"></param>
        private void HideColumns(List<string> columnsListToHide, DataGridView dataGridView) {
            foreach (string col in columnsListToHide)
            {
                dataGridView.Columns[col].Visible = false;
            }
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.mediaDataGrid = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.cmbxCriteria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblMessages = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mediaDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(304, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(79, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "label1";
            // 
            // mediaDataGrid
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mediaDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.mediaDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mediaDataGrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.mediaDataGrid.Location = new System.Drawing.Point(49, 139);
            this.mediaDataGrid.Name = "mediaDataGrid";
            this.mediaDataGrid.Size = new System.Drawing.Size(763, 282);
            this.mediaDataGrid.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(437, 106);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(199, 20);
            this.txtSearch.TabIndex = 2;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(46, 106);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(78, 18);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Search by:";
            // 
            // cmbxCriteria
            // 
            this.cmbxCriteria.FormattingEnabled = true;
            this.cmbxCriteria.Items.AddRange(new object[] {
            "Title",
            "GenreName",
            "DirectorName",
            "LanguageName",
            "PublishYear"});
            this.cmbxCriteria.Location = new System.Drawing.Point(130, 104);
            this.cmbxCriteria.Name = "cmbxCriteria";
            this.cmbxCriteria.Size = new System.Drawing.Size(121, 21);
            this.cmbxCriteria.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(271, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "contains the keywords:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(642, 105);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(723, 106);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear Search";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblMessages
            // 
            this.lblMessages.AutoSize = true;
            this.lblMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessages.ForeColor = System.Drawing.Color.Red;
            this.lblMessages.Location = new System.Drawing.Point(46, 434);
            this.lblMessages.Name = "lblMessages";
            this.lblMessages.Size = new System.Drawing.Size(0, 18);
            this.lblMessages.TabIndex = 8;
            // 
            // MediaBrowser
            // 
            this.ClientSize = new System.Drawing.Size(871, 466);
            this.Controls.Add(this.lblMessages);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbxCriteria);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.mediaDataGrid);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "MediaBrowser";
            ((System.ComponentModel.ISupportInitialize)(this.mediaDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            EnumerableRowCollection<DataRow> query = null;
            string searchText = txtSearch.Text;
            string searchCrit = string.Empty;

            if (cmbxCriteria.SelectedItem != null && cmbxCriteria.SelectedItem.ToString() != "")
                searchCrit = cmbxCriteria.SelectedItem.ToString();



            try
            {
                if (searchCrit != "" && searchText != "")
                {
                    query = from movies in _data.AsEnumerable()
                            where movies.Field<String>(searchCrit).Contains(searchText)
                            select movies;

                    if (query.ToList<object>().Count <= 0)
                        ShowErrorMessage("Notice that the search is case-sensitive..");


                }
                else {
                    ShowErrorMessage("Search fields cannot be left empty.");
                }

                if (query != null)
                {
                    DataView view = query.AsDataView();
                    bindingSource1.DataSource = view;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Show warnings for the user. Remove it after 2.5 seconds.
        /// </summary>
        /// <param name="msg"></param>
        private void ShowErrorMessage(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
                lblMessages.Text = msg;
            lblMessages.Visible = true;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 2500;
            timer.Tick += (source, e) => { lblMessages.Visible = false; timer.Stop(); };
            timer.Start();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            EnumerableRowCollection<DataRow> query = null;

            query = from movies in _data.AsEnumerable()
                    select movies;

            DataView view = query.AsDataView();
            bindingSource1.DataSource = view;
        }
    }
}
