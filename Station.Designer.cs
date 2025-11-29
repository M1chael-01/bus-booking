namespace BusBooking
{
    partial class Station
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Station));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.addedDate = new System.Windows.Forms.TextBox();
            this.deleteDestination = new System.Windows.Forms.Button();
            this.clearDestination = new System.Windows.Forms.Button();
            this.addDestination = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.editDestination = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.destinationName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.stationTextBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.table = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(41)))), ((int)(((byte)(79)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 735);
            this.panel1.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Image = global::BusBooking.Properties.Resources.icons8_trip_24;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(0, 544);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(294, 63);
            this.label6.TabIndex = 6;
            this.label6.Text = "My Account";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.ShowAccountForm);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Image = global::BusBooking.Properties.Resources.icons8_trip_24;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(0, 481);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(294, 63);
            this.label5.TabIndex = 5;
            this.label5.Text = "Drivers";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.ShowDriversForm);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Image = global::BusBooking.Properties.Resources.icons8_trip_24;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(0, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(294, 63);
            this.label4.TabIndex = 4;
            this.label4.Text = "Station";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Image = global::BusBooking.Properties.Resources.icons8_trip_24;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(0, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 63);
            this.label3.TabIndex = 3;
            this.label3.Text = "Busses";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.ShowBussesForm);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Image = global::BusBooking.Properties.Resources.icons8_trip_24;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(0, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 63);
            this.label2.TabIndex = 2;
            this.label2.Text = "Passengers";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.ShowPassengerForm);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.ForeColor = System.Drawing.Color.Transparent;
            this.label13.Image = global::BusBooking.Properties.Resources.icons8_trip_24;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(0, 229);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(294, 63);
            this.label13.TabIndex = 1;
            this.label13.Text = "Trips";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label13.Click += new System.EventHandler(this.ShowTripsForm);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::BusBooking.Properties.Resources.bus_done;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.pictureBox1.Size = new System.Drawing.Size(294, 229);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(41)))), ((int)(((byte)(79)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.addedDate);
            this.panel2.Controls.Add(this.deleteDestination);
            this.panel2.Controls.Add(this.clearDestination);
            this.panel2.Controls.Add(this.addDestination);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.editDestination);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.destinationName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(294, 521);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1222, 214);
            this.panel2.TabIndex = 22;
            // 
            // addedDate
            // 
            this.addedDate.BackColor = System.Drawing.Color.White;
            this.addedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addedDate.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addedDate.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.addedDate.Location = new System.Drawing.Point(419, 100);
            this.addedDate.Multiline = true;
            this.addedDate.Name = "addedDate";
            this.addedDate.Size = new System.Drawing.Size(355, 39);
            this.addedDate.TabIndex = 23;
            // 
            // deleteDestination
            // 
            this.deleteDestination.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.deleteDestination.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteDestination.Dock = System.Windows.Forms.DockStyle.Right;
            this.deleteDestination.FlatAppearance.BorderSize = 0;
            this.deleteDestination.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteDestination.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteDestination.ForeColor = System.Drawing.Color.White;
            this.deleteDestination.Location = new System.Drawing.Point(822, 0);
            this.deleteDestination.Name = "deleteDestination";
            this.deleteDestination.Size = new System.Drawing.Size(102, 212);
            this.deleteDestination.TabIndex = 22;
            this.deleteDestination.Text = "DELETE";
            this.deleteDestination.UseVisualStyleBackColor = false;
            this.deleteDestination.Click += new System.EventHandler(this.DeleteDestination);
            // 
            // clearDestination
            // 
            this.clearDestination.BackColor = System.Drawing.Color.Red;
            this.clearDestination.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearDestination.Dock = System.Windows.Forms.DockStyle.Right;
            this.clearDestination.FlatAppearance.BorderSize = 0;
            this.clearDestination.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearDestination.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearDestination.ForeColor = System.Drawing.Color.White;
            this.clearDestination.Location = new System.Drawing.Point(924, 0);
            this.clearDestination.Name = "clearDestination";
            this.clearDestination.Size = new System.Drawing.Size(102, 212);
            this.clearDestination.TabIndex = 21;
            this.clearDestination.Text = "CLEAR";
            this.clearDestination.UseVisualStyleBackColor = false;
            this.clearDestination.Click += new System.EventHandler(this.ClearDestination);
            // 
            // addDestination
            // 
            this.addDestination.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.addDestination.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addDestination.Dock = System.Windows.Forms.DockStyle.Right;
            this.addDestination.FlatAppearance.BorderSize = 0;
            this.addDestination.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addDestination.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addDestination.ForeColor = System.Drawing.Color.White;
            this.addDestination.Location = new System.Drawing.Point(1026, 0);
            this.addDestination.Name = "addDestination";
            this.addDestination.Size = new System.Drawing.Size(102, 212);
            this.addDestination.TabIndex = 20;
            this.addDestination.Text = "ADD";
            this.addDestination.UseVisualStyleBackColor = false;
            this.addDestination.Click += new System.EventHandler(this.AddDestination);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(414, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 25);
            this.label10.TabIndex = 18;
            this.label10.Text = "Date";
            // 
            // editDestination
            // 
            this.editDestination.BackColor = System.Drawing.Color.Red;
            this.editDestination.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editDestination.Dock = System.Windows.Forms.DockStyle.Right;
            this.editDestination.FlatAppearance.BorderSize = 0;
            this.editDestination.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editDestination.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editDestination.ForeColor = System.Drawing.Color.White;
            this.editDestination.Location = new System.Drawing.Point(1128, 0);
            this.editDestination.Name = "editDestination";
            this.editDestination.Size = new System.Drawing.Size(92, 212);
            this.editDestination.TabIndex = 16;
            this.editDestination.Text = "EDIT";
            this.editDestination.UseVisualStyleBackColor = false;
            this.editDestination.Click += new System.EventHandler(this.EditDestination);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(15, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "Destination name";
            // 
            // destinationName
            // 
            this.destinationName.BackColor = System.Drawing.Color.White;
            this.destinationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.destinationName.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationName.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.destinationName.Location = new System.Drawing.Point(15, 100);
            this.destinationName.Multiline = true;
            this.destinationName.Name = "destinationName";
            this.destinationName.Size = new System.Drawing.Size(355, 39);
            this.destinationName.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.stationTextBox);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(294, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1222, 66);
            this.panel3.TabIndex = 23;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Red;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Image = global::BusBooking.Properties.Resources.icons8_close_20;
            this.button6.Location = new System.Drawing.Point(528, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(126, 66);
            this.button6.TabIndex = 18;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.ClearTextBox);
            // 
            // stationTextBox
            // 
            this.stationTextBox.BackColor = System.Drawing.Color.White;
            this.stationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stationTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.stationTextBox.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stationTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.stationTextBox.Location = new System.Drawing.Point(0, 0);
            this.stationTextBox.Multiline = true;
            this.stationTextBox.Name = "stationTextBox";
            this.stationTextBox.Size = new System.Drawing.Size(420, 66);
            this.stationTextBox.TabIndex = 17;
            this.stationTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchByEnter);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::BusBooking.Properties.Resources.icons8_search_20;
            this.button3.Location = new System.Drawing.Point(415, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 66);
            this.button3.TabIndex = 16;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.SearchByClick);
            // 
            // table
            // 
            this.table.AllowUserToAddRows = false;
            this.table.AllowUserToDeleteRows = false;
            this.table.AllowUserToResizeColumns = false;
            this.table.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.table.BackgroundColor = System.Drawing.Color.White;
            this.table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(51)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.table.ColumnHeadersHeight = 30;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.table.DefaultCellStyle = dataGridViewCellStyle3;
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.GridColor = System.Drawing.Color.WhiteSmoke;
            this.table.Location = new System.Drawing.Point(294, 66);
            this.table.Name = "table";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Tai Le", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.table.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.table.RowHeadersWidth = 80;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(4);
            this.table.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.table.RowTemplate.Height = 32;
            this.table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.table.ShowCellErrors = false;
            this.table.ShowCellToolTips = false;
            this.table.ShowEditingIcon = false;
            this.table.ShowRowErrors = false;
            this.table.Size = new System.Drawing.Size(1222, 455);
            this.table.TabIndex = 27;
            // 
            // Station
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1516, 735);
            this.Controls.Add(this.table);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Station";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Station";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AppLoad);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox addedDate;
        private System.Windows.Forms.Button deleteDestination;
        private System.Windows.Forms.Button clearDestination;
        private System.Windows.Forms.Button addDestination;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button editDestination;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox destinationName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox stationTextBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView table;
    }
}