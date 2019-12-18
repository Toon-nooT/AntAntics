<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AntAntics
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TrackBarH = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TrackBarHueTolerance = New System.Windows.Forms.TrackBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TrackBarSMin = New System.Windows.Forms.TrackBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TrackBarSMax = New System.Windows.Forms.TrackBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TrackBarVMax = New System.Windows.Forms.TrackBar()
        Me.TrackBarVMin = New System.Windows.Forms.TrackBar()
        Me.TrackBarBlur = New System.Windows.Forms.TrackBar()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TrackBarErode = New System.Windows.Forms.TrackBar()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TrackBarDilate = New System.Windows.Forms.TrackBar()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TrackBarMaxContour = New System.Windows.Forms.TrackBar()
        Me.TrackBarMinContour = New System.Windows.Forms.TrackBar()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBoxHue = New System.Windows.Forms.PictureBox()
        Me.CheckBoxUseCalibration = New System.Windows.Forms.CheckBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        CType(Me.TrackBarH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarHueTolerance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarSMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarSMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarVMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarVMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarBlur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarErode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarDilate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarMaxContour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarMinContour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxHue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 50
        '
        'TrackBarH
        '
        Me.TrackBarH.BackColor = System.Drawing.Color.Black
        Me.TrackBarH.Location = New System.Drawing.Point(338, 283)
        Me.TrackBarH.Maximum = 179
        Me.TrackBarH.Name = "TrackBarH"
        Me.TrackBarH.Size = New System.Drawing.Size(231, 45)
        Me.TrackBarH.TabIndex = 2
        Me.TrackBarH.Value = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(344, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Camera"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(418, 315)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Hue filter"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(338, 504)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Denoise Hue filter"
        '
        'TrackBarHueTolerance
        '
        Me.TrackBarHueTolerance.BackColor = System.Drawing.Color.Black
        Me.TrackBarHueTolerance.Location = New System.Drawing.Point(338, 331)
        Me.TrackBarHueTolerance.Maximum = 40
        Me.TrackBarHueTolerance.Minimum = 1
        Me.TrackBarHueTolerance.Name = "TrackBarHueTolerance"
        Me.TrackBarHueTolerance.Size = New System.Drawing.Size(231, 45)
        Me.TrackBarHueTolerance.TabIndex = 8
        Me.TrackBarHueTolerance.Value = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(418, 363)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Tolerance"
        '
        'TrackBarSMin
        '
        Me.TrackBarSMin.Location = New System.Drawing.Point(350, 386)
        Me.TrackBarSMin.Maximum = 254
        Me.TrackBarSMin.Name = "TrackBarSMin"
        Me.TrackBarSMin.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarSMin.Size = New System.Drawing.Size(45, 104)
        Me.TrackBarSMin.TabIndex = 10
        Me.TrackBarSMin.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBarSMin.Value = 110
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(351, 376)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Saturation"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(347, 389)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Min."
        '
        'TrackBarSMax
        '
        Me.TrackBarSMax.Location = New System.Drawing.Point(382, 386)
        Me.TrackBarSMax.Maximum = 255
        Me.TrackBarSMax.Minimum = 1
        Me.TrackBarSMax.Name = "TrackBarSMax"
        Me.TrackBarSMax.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarSMax.Size = New System.Drawing.Size(45, 104)
        Me.TrackBarSMax.TabIndex = 13
        Me.TrackBarSMax.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBarSMax.Value = 255
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(379, 477)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Max."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(521, 477)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Max."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(489, 389)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Min."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(493, 376)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Value"
        '
        'TrackBarVMax
        '
        Me.TrackBarVMax.Location = New System.Drawing.Point(524, 386)
        Me.TrackBarVMax.Maximum = 255
        Me.TrackBarVMax.Minimum = 1
        Me.TrackBarVMax.Name = "TrackBarVMax"
        Me.TrackBarVMax.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarVMax.Size = New System.Drawing.Size(45, 104)
        Me.TrackBarVMax.TabIndex = 18
        Me.TrackBarVMax.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBarVMax.Value = 255
        '
        'TrackBarVMin
        '
        Me.TrackBarVMin.Location = New System.Drawing.Point(492, 386)
        Me.TrackBarVMin.Maximum = 254
        Me.TrackBarVMin.Name = "TrackBarVMin"
        Me.TrackBarVMin.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarVMin.Size = New System.Drawing.Size(45, 104)
        Me.TrackBarVMin.TabIndex = 15
        Me.TrackBarVMin.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBarVMin.Value = 110
        '
        'TrackBarBlur
        '
        Me.TrackBarBlur.Location = New System.Drawing.Point(423, 537)
        Me.TrackBarBlur.Name = "TrackBarBlur"
        Me.TrackBarBlur.Size = New System.Drawing.Size(104, 45)
        Me.TrackBarBlur.TabIndex = 20
        Me.TrackBarBlur.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(338, 537)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Gaussian Blur"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(338, 588)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Erode"
        '
        'TrackBarErode
        '
        Me.TrackBarErode.Location = New System.Drawing.Point(423, 588)
        Me.TrackBarErode.Maximum = 20
        Me.TrackBarErode.Name = "TrackBarErode"
        Me.TrackBarErode.Size = New System.Drawing.Size(104, 45)
        Me.TrackBarErode.TabIndex = 22
        Me.TrackBarErode.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBarErode.Value = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(337, 639)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(34, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Dilate"
        '
        'TrackBarDilate
        '
        Me.TrackBarDilate.Location = New System.Drawing.Point(422, 639)
        Me.TrackBarDilate.Maximum = 20
        Me.TrackBarDilate.Name = "TrackBarDilate"
        Me.TrackBarDilate.Size = New System.Drawing.Size(104, 45)
        Me.TrackBarDilate.TabIndex = 24
        Me.TrackBarDilate.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBarDilate.Value = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(930, 114)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 13)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "Max."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(898, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(27, 13)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Min."
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(902, 13)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Contour size"
        '
        'TrackBarMaxContour
        '
        Me.TrackBarMaxContour.Location = New System.Drawing.Point(933, 23)
        Me.TrackBarMaxContour.Maximum = 255
        Me.TrackBarMaxContour.Minimum = 1
        Me.TrackBarMaxContour.Name = "TrackBarMaxContour"
        Me.TrackBarMaxContour.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarMaxContour.Size = New System.Drawing.Size(45, 104)
        Me.TrackBarMaxContour.TabIndex = 30
        Me.TrackBarMaxContour.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBarMaxContour.Value = 255
        '
        'TrackBarMinContour
        '
        Me.TrackBarMinContour.Location = New System.Drawing.Point(901, 23)
        Me.TrackBarMinContour.Maximum = 254
        Me.TrackBarMinContour.Name = "TrackBarMinContour"
        Me.TrackBarMinContour.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarMinContour.Size = New System.Drawing.Size(45, 104)
        Me.TrackBarMinContour.TabIndex = 27
        Me.TrackBarMinContour.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBarMinContour.Value = 30
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(933, 315)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(139, 17)
        Me.CheckBox1.TabIndex = 33
        Me.CheckBox1.Text = "Show calibration screen"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(933, 338)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(139, 23)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "Calibrate"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox5
        '
        Me.PictureBox5.Location = New System.Drawing.Point(569, 258)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(320, 180)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 32
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Location = New System.Drawing.Point(569, 12)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(320, 180)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 26
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New System.Drawing.Point(12, 504)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(320, 180)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 4
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(12, 258)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(320, 180)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(320, 180)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBoxHue
        '
        Me.PictureBoxHue.BackgroundImage = Global.AntAntics.My.Resources.Resources.hue
        Me.PictureBoxHue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBoxHue.Location = New System.Drawing.Point(338, 258)
        Me.PictureBoxHue.Name = "PictureBoxHue"
        Me.PictureBoxHue.Size = New System.Drawing.Size(231, 70)
        Me.PictureBoxHue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxHue.TabIndex = 3
        Me.PictureBoxHue.TabStop = False
        '
        'CheckBoxUseCalibration
        '
        Me.CheckBoxUseCalibration.AutoSize = True
        Me.CheckBoxUseCalibration.Location = New System.Drawing.Point(933, 376)
        Me.CheckBoxUseCalibration.Name = "CheckBoxUseCalibration"
        Me.CheckBoxUseCalibration.Size = New System.Drawing.Size(94, 17)
        Me.CheckBoxUseCalibration.TabIndex = 35
        Me.CheckBoxUseCalibration.Text = "use calibration"
        Me.CheckBoxUseCalibration.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(933, 421)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(100, 96)
        Me.RichTextBox1.TabIndex = 36
        Me.RichTextBox1.Text = ""
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(626, 532)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(139, 23)
        Me.Button2.TabIndex = 37
        Me.Button2.Text = "Save Settings"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(786, 532)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(139, 23)
        Me.Button3.TabIndex = 38
        Me.Button3.Text = "Load Settings"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(626, 561)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(139, 23)
        Me.Button4.TabIndex = 39
        Me.Button4.Text = "Save Calibration Settings"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(786, 561)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(139, 23)
        Me.Button5.TabIndex = 40
        Me.Button5.Text = "Load Calibration Settings"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'AntAntics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(1132, 773)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.CheckBoxUseCalibration)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TrackBarMaxContour)
        Me.Controls.Add(Me.TrackBarMinContour)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TrackBarDilate)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TrackBarErode)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TrackBarBlur)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TrackBarVMax)
        Me.Controls.Add(Me.TrackBarVMin)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TrackBarSMax)
        Me.Controls.Add(Me.TrackBarSMin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TrackBarHueTolerance)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.TrackBarH)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBoxHue)
        Me.Name = "AntAntics"
        Me.Text = "AntAntics"
        CType(Me.TrackBarH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarHueTolerance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarSMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarSMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarVMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarVMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarBlur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarErode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarDilate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarMaxContour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarMinContour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxHue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox2 As PictureBox
    Public WithEvents TrackBarH As TrackBar
    Friend WithEvents PictureBoxHue As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Public WithEvents TrackBarHueTolerance As TrackBar
    Friend WithEvents Label4 As Label
    Friend WithEvents TrackBarSMin As TrackBar
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TrackBarSMax As TrackBar
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TrackBarVMax As TrackBar
    Friend WithEvents TrackBarVMin As TrackBar
    Friend WithEvents TrackBarBlur As TrackBar
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TrackBarErode As TrackBar
    Friend WithEvents Label13 As Label
    Friend WithEvents TrackBarDilate As TrackBar
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents TrackBarMaxContour As TrackBar
    Friend WithEvents TrackBarMinContour As TrackBar
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents CheckBoxUseCalibration As CheckBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
End Class
