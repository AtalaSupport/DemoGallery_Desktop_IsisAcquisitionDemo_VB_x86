Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports Atalasoft.Isis
Imports Atalasoft.Imaging.Metadata

Namespace IsisDemo
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1 : Inherits System.Windows.Forms.Form
		Private _fileSaveDir As String = ""
		Private _fileCount As Integer
		Private _multipageFile As String = ""
		Private _usingIsisCodecs As Boolean
		Private _driverColorFormats As IsisPixelFormat()
		Private _acquisition As Atalasoft.Isis.IsisAcquisition
		Private panelControls As System.Windows.Forms.Panel
		Private splitter1 As System.Windows.Forms.Splitter
		Private label1 As System.Windows.Forms.Label
		Private WithEvents cboDevices As System.Windows.Forms.ComboBox
		Private WithEvents btnAcquire As System.Windows.Forms.Button
		Private chkShowDialog As System.Windows.Forms.CheckBox
		Private groupBox1 As System.Windows.Forms.GroupBox
		Private panelIimage As System.Windows.Forms.Panel
		Private picImage As System.Windows.Forms.PictureBox
		Private label2 As System.Windows.Forms.Label
		Private WithEvents cboPixelFormat As System.Windows.Forms.ComboBox
		Private label3 As System.Windows.Forms.Label
		Private WithEvents cboScanMode As System.Windows.Forms.ComboBox
		Private label4 As System.Windows.Forms.Label
		Private WithEvents cboFileType As System.Windows.Forms.ComboBox
		Private label5 As System.Windows.Forms.Label
		Private cboCompression As System.Windows.Forms.ComboBox
		Private label6 As System.Windows.Forms.Label
		Private cboResolution As System.Windows.Forms.ComboBox
		Private chkSaveMultipage As System.Windows.Forms.CheckBox
		Private label7 As System.Windows.Forms.Label
        Private WithEvents cboAcquiredImageType As System.Windows.Forms.ComboBox
        Friend WithEvents ButtonAbout As System.Windows.Forms.Button
        Private WithEvents label11 As System.Windows.Forms.Label
        Private WithEvents numScanAhead As System.Windows.Forms.NumericUpDown
        Private WithEvents labl10 As System.Windows.Forms.Label
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not components Is Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Friend WithEvents label9 As System.Windows.Forms.Label
        Friend WithEvents numPageCountLimit As System.Windows.Forms.NumericUpDown
        Friend WithEvents label8 As System.Windows.Forms.Label
        Private Sub InitializeComponent()
            Me.panelControls = New System.Windows.Forms.Panel
            Me.ButtonAbout = New System.Windows.Forms.Button
            Me.label9 = New System.Windows.Forms.Label
            Me.numPageCountLimit = New System.Windows.Forms.NumericUpDown
            Me.label8 = New System.Windows.Forms.Label
            Me.groupBox1 = New System.Windows.Forms.GroupBox
            Me.cboAcquiredImageType = New System.Windows.Forms.ComboBox
            Me.label7 = New System.Windows.Forms.Label
            Me.chkSaveMultipage = New System.Windows.Forms.CheckBox
            Me.cboResolution = New System.Windows.Forms.ComboBox
            Me.label6 = New System.Windows.Forms.Label
            Me.cboCompression = New System.Windows.Forms.ComboBox
            Me.label5 = New System.Windows.Forms.Label
            Me.cboFileType = New System.Windows.Forms.ComboBox
            Me.label4 = New System.Windows.Forms.Label
            Me.cboScanMode = New System.Windows.Forms.ComboBox
            Me.label3 = New System.Windows.Forms.Label
            Me.cboPixelFormat = New System.Windows.Forms.ComboBox
            Me.label2 = New System.Windows.Forms.Label
            Me.chkShowDialog = New System.Windows.Forms.CheckBox
            Me.btnAcquire = New System.Windows.Forms.Button
            Me.cboDevices = New System.Windows.Forms.ComboBox
            Me.label1 = New System.Windows.Forms.Label
            Me.splitter1 = New System.Windows.Forms.Splitter
            Me.panelIimage = New System.Windows.Forms.Panel
            Me.picImage = New System.Windows.Forms.PictureBox
            Me.label11 = New System.Windows.Forms.Label
            Me.numScanAhead = New System.Windows.Forms.NumericUpDown
            Me.labl10 = New System.Windows.Forms.Label
            Me.panelControls.SuspendLayout()
            CType(Me.numPageCountLimit, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.groupBox1.SuspendLayout()
            Me.panelIimage.SuspendLayout()
            CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numScanAhead, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'panelControls
            '
            Me.panelControls.Controls.Add(Me.label11)
            Me.panelControls.Controls.Add(Me.numScanAhead)
            Me.panelControls.Controls.Add(Me.labl10)
            Me.panelControls.Controls.Add(Me.ButtonAbout)
            Me.panelControls.Controls.Add(Me.label9)
            Me.panelControls.Controls.Add(Me.numPageCountLimit)
            Me.panelControls.Controls.Add(Me.label8)
            Me.panelControls.Controls.Add(Me.groupBox1)
            Me.panelControls.Controls.Add(Me.chkShowDialog)
            Me.panelControls.Controls.Add(Me.btnAcquire)
            Me.panelControls.Controls.Add(Me.cboDevices)
            Me.panelControls.Controls.Add(Me.label1)
            Me.panelControls.Dock = System.Windows.Forms.DockStyle.Left
            Me.panelControls.Location = New System.Drawing.Point(0, 0)
            Me.panelControls.Name = "panelControls"
            Me.panelControls.Size = New System.Drawing.Size(224, 562)
            Me.panelControls.TabIndex = 0
            '
            'ButtonAbout
            '
            Me.ButtonAbout.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.ButtonAbout.Location = New System.Drawing.Point(77, 527)
            Me.ButtonAbout.Name = "ButtonAbout"
            Me.ButtonAbout.Size = New System.Drawing.Size(75, 23)
            Me.ButtonAbout.TabIndex = 11
            Me.ButtonAbout.Text = "About ..."
            Me.ButtonAbout.UseVisualStyleBackColor = True
            '
            'label9
            '
            Me.label9.Location = New System.Drawing.Point(168, 111)
            Me.label9.Name = "label9"
            Me.label9.Size = New System.Drawing.Size(40, 16)
            Me.label9.TabIndex = 10
            Me.label9.Text = "pages."
            '
            'numPageCountLimit
            '
            Me.numPageCountLimit.Location = New System.Drawing.Point(120, 109)
            Me.numPageCountLimit.Name = "numPageCountLimit"
            Me.numPageCountLimit.Size = New System.Drawing.Size(40, 20)
            Me.numPageCountLimit.TabIndex = 9
            '
            'label8
            '
            Me.label8.Location = New System.Drawing.Point(16, 111)
            Me.label8.Name = "label8"
            Me.label8.Size = New System.Drawing.Size(112, 16)
            Me.label8.TabIndex = 8
            Me.label8.Text = "Limit scan count to:"
            '
            'groupBox1
            '
            Me.groupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.groupBox1.Controls.Add(Me.cboAcquiredImageType)
            Me.groupBox1.Controls.Add(Me.label7)
            Me.groupBox1.Controls.Add(Me.chkSaveMultipage)
            Me.groupBox1.Controls.Add(Me.cboResolution)
            Me.groupBox1.Controls.Add(Me.label6)
            Me.groupBox1.Controls.Add(Me.cboCompression)
            Me.groupBox1.Controls.Add(Me.label5)
            Me.groupBox1.Controls.Add(Me.cboFileType)
            Me.groupBox1.Controls.Add(Me.label4)
            Me.groupBox1.Controls.Add(Me.cboScanMode)
            Me.groupBox1.Controls.Add(Me.label3)
            Me.groupBox1.Controls.Add(Me.cboPixelFormat)
            Me.groupBox1.Controls.Add(Me.label2)
            Me.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.groupBox1.Location = New System.Drawing.Point(16, 163)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(192, 349)
            Me.groupBox1.TabIndex = 4
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "Scan Settings"
            '
            'cboAcquiredImageType
            '
            Me.cboAcquiredImageType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cboAcquiredImageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboAcquiredImageType.Items.AddRange(New Object() {"AtalaImage", ".NET Bitmap"})
            Me.cboAcquiredImageType.Location = New System.Drawing.Point(16, 72)
            Me.cboAcquiredImageType.Name = "cboAcquiredImageType"
            Me.cboAcquiredImageType.Size = New System.Drawing.Size(160, 21)
            Me.cboAcquiredImageType.TabIndex = 12
            '
            'label7
            '
            Me.label7.Location = New System.Drawing.Point(16, 56)
            Me.label7.Name = "label7"
            Me.label7.Size = New System.Drawing.Size(120, 16)
            Me.label7.TabIndex = 11
            Me.label7.Text = "Acquired Image Type:"
            '
            'chkSaveMultipage
            '
            Me.chkSaveMultipage.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkSaveMultipage.Location = New System.Drawing.Point(16, 256)
            Me.chkSaveMultipage.Name = "chkSaveMultipage"
            Me.chkSaveMultipage.Size = New System.Drawing.Size(152, 16)
            Me.chkSaveMultipage.TabIndex = 8
            Me.chkSaveMultipage.Text = "Save as a multipage file."
            '
            'cboResolution
            '
            Me.cboResolution.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cboResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboResolution.Location = New System.Drawing.Point(16, 168)
            Me.cboResolution.Name = "cboResolution"
            Me.cboResolution.Size = New System.Drawing.Size(160, 21)
            Me.cboResolution.TabIndex = 5
            '
            'label6
            '
            Me.label6.Location = New System.Drawing.Point(16, 152)
            Me.label6.Name = "label6"
            Me.label6.Size = New System.Drawing.Size(112, 16)
            Me.label6.TabIndex = 4
            Me.label6.Text = "Resolution:"
            '
            'cboCompression
            '
            Me.cboCompression.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cboCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboCompression.Location = New System.Drawing.Point(16, 304)
            Me.cboCompression.Name = "cboCompression"
            Me.cboCompression.Size = New System.Drawing.Size(160, 21)
            Me.cboCompression.Sorted = True
            Me.cboCompression.TabIndex = 10
            '
            'label5
            '
            Me.label5.Location = New System.Drawing.Point(16, 288)
            Me.label5.Name = "label5"
            Me.label5.Size = New System.Drawing.Size(80, 16)
            Me.label5.TabIndex = 9
            Me.label5.Text = "Compression:"
            '
            'cboFileType
            '
            Me.cboFileType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cboFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboFileType.Location = New System.Drawing.Point(16, 224)
            Me.cboFileType.Name = "cboFileType"
            Me.cboFileType.Size = New System.Drawing.Size(160, 21)
            Me.cboFileType.Sorted = True
            Me.cboFileType.TabIndex = 7
            '
            'label4
            '
            Me.label4.Location = New System.Drawing.Point(16, 208)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(88, 16)
            Me.label4.TabIndex = 6
            Me.label4.Text = "File Type:"
            '
            'cboScanMode
            '
            Me.cboScanMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cboScanMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboScanMode.Items.AddRange(New Object() {"Memory", "File"})
            Me.cboScanMode.Location = New System.Drawing.Point(88, 24)
            Me.cboScanMode.Name = "cboScanMode"
            Me.cboScanMode.Size = New System.Drawing.Size(88, 21)
            Me.cboScanMode.TabIndex = 1
            '
            'label3
            '
            Me.label3.Location = New System.Drawing.Point(16, 26)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(80, 16)
            Me.label3.TabIndex = 0
            Me.label3.Text = "Scan Mode:"
            '
            'cboPixelFormat
            '
            Me.cboPixelFormat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cboPixelFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboPixelFormat.Location = New System.Drawing.Point(16, 120)
            Me.cboPixelFormat.Name = "cboPixelFormat"
            Me.cboPixelFormat.Size = New System.Drawing.Size(160, 21)
            Me.cboPixelFormat.TabIndex = 3
            '
            'label2
            '
            Me.label2.Location = New System.Drawing.Point(16, 104)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(80, 16)
            Me.label2.TabIndex = 2
            Me.label2.Text = "Pixel Format:"
            '
            'chkShowDialog
            '
            Me.chkShowDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkShowDialog.Location = New System.Drawing.Point(16, 58)
            Me.chkShowDialog.Name = "chkShowDialog"
            Me.chkShowDialog.Size = New System.Drawing.Size(176, 16)
            Me.chkShowDialog.TabIndex = 2
            Me.chkShowDialog.Text = "Show Scanner Dialog"
            '
            'btnAcquire
            '
            Me.btnAcquire.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnAcquire.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAcquire.Location = New System.Drawing.Point(16, 80)
            Me.btnAcquire.Name = "btnAcquire"
            Me.btnAcquire.Size = New System.Drawing.Size(192, 24)
            Me.btnAcquire.TabIndex = 3
            Me.btnAcquire.Text = "&Acquire"
            '
            'cboDevices
            '
            Me.cboDevices.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cboDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboDevices.Location = New System.Drawing.Point(16, 32)
            Me.cboDevices.Name = "cboDevices"
            Me.cboDevices.Size = New System.Drawing.Size(192, 21)
            Me.cboDevices.Sorted = True
            Me.cboDevices.TabIndex = 1
            '
            'label1
            '
            Me.label1.Location = New System.Drawing.Point(16, 16)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(56, 16)
            Me.label1.TabIndex = 0
            Me.label1.Text = "Device:"
            '
            'splitter1
            '
            Me.splitter1.Location = New System.Drawing.Point(224, 0)
            Me.splitter1.MinExtra = 200
            Me.splitter1.MinSize = 200
            Me.splitter1.Name = "splitter1"
            Me.splitter1.Size = New System.Drawing.Size(6, 562)
            Me.splitter1.TabIndex = 1
            Me.splitter1.TabStop = False
            '
            'panelIimage
            '
            Me.panelIimage.AutoScroll = True
            Me.panelIimage.BackColor = System.Drawing.SystemColors.Window
            Me.panelIimage.Controls.Add(Me.picImage)
            Me.panelIimage.Dock = System.Windows.Forms.DockStyle.Fill
            Me.panelIimage.Location = New System.Drawing.Point(230, 0)
            Me.panelIimage.Name = "panelIimage"
            Me.panelIimage.Size = New System.Drawing.Size(482, 562)
            Me.panelIimage.TabIndex = 2
            '
            'picImage
            '
            Me.picImage.BackColor = System.Drawing.SystemColors.Window
            Me.picImage.Location = New System.Drawing.Point(0, 0)
            Me.picImage.Name = "picImage"
            Me.picImage.Size = New System.Drawing.Size(100, 100)
            Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.picImage.TabIndex = 3
            Me.picImage.TabStop = False
            '
            'label11
            '
            Me.label11.Location = New System.Drawing.Point(167, 138)
            Me.label11.Name = "label11"
            Me.label11.Size = New System.Drawing.Size(40, 16)
            Me.label11.TabIndex = 14
            Me.label11.Text = "pages."
            '
            'numScanAhead
            '
            Me.numScanAhead.Location = New System.Drawing.Point(121, 136)
            Me.numScanAhead.Name = "numScanAhead"
            Me.numScanAhead.Size = New System.Drawing.Size(40, 20)
            Me.numScanAhead.TabIndex = 13
            Me.numScanAhead.Value = New Decimal(New Integer() {5, 0, 0, 0})
            '
            'labl10
            '
            Me.labl10.AutoSize = True
            Me.labl10.Location = New System.Drawing.Point(19, 137)
            Me.labl10.Name = "labl10"
            Me.labl10.Size = New System.Drawing.Size(71, 13)
            Me.labl10.TabIndex = 12
            Me.labl10.Text = "Scan ahead: "
            '
            'Form1
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(712, 562)
            Me.Controls.Add(Me.panelIimage)
            Me.Controls.Add(Me.splitter1)
            Me.Controls.Add(Me.panelControls)
            Me.Name = "Form1"
            Me.Text = "Atalasoft DotImage ISIS Demo"
            Me.panelControls.ResumeLayout(False)
            Me.panelControls.PerformLayout()
            CType(Me.numPageCountLimit, System.ComponentModel.ISupportInitialize).EndInit()
            Me.groupBox1.ResumeLayout(False)
            Me.panelIimage.ResumeLayout(False)
            Me.panelIimage.PerformLayout()
            CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numScanAhead, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
#End Region

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread()> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.DoEvents()
            Application.Run(New Form1())
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' This will throw an exception if there is no license.
            Try
                Dim img As Atalasoft.Imaging.AtalaImage = New Atalasoft.Imaging.AtalaImage()
                img.Dispose()

                _acquisition = New Atalasoft.Isis.IsisAcquisition()
            Catch e1 As Atalasoft.Imaging.AtalasoftLicenseException
                MessageBox.Show("This demo requires a license for 'DotImage' and 'DotImage ISIS'." & Constants.vbCrLf & Constants.vbCrLf & "You can get an evaluation license using the Activation utility or" & Constants.vbCrLf & "from http://www.atalasoft.com/portal/requestevaluation.aspx.", "No License Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Return
            End Try

            If _acquisition.Devices.Count = 0 Then
                MessageBox.Show("No ISIS drivers where found on your system.", "No ISIS Drivers")
                Me.cboDevices.Enabled = False
                Me.groupBox1.Enabled = False
                Me.btnAcquire.Enabled = False
                Me.chkShowDialog.Enabled = False
                Return
            End If

            ' Fill the combobox with devices and make the default device selected.
            Me.cboDevices.Items.AddRange(_acquisition.Devices.ToArray())

            ' It's possible that the Default property will return null.
            ' This can happen if the user never used an ISIS driver before.
            If Not _acquisition.Devices.Default Is Nothing Then
                Dim index As Integer = Me.cboDevices.Items.IndexOf(_acquisition.Devices.Default)
                If index <> -1 Then
                    Me.cboDevices.SelectedIndex = index
                End If
            End If

            Me.cboScanMode.SelectedIndex = 0
            Me.cboAcquiredImageType.SelectedIndex = 0

            HookEvents(True)

            ' Show the version of DotImage ISIS in the title bar.
            Me.Text = "Atalasoft DotImage ISIS Demo - Version " & GetDotImageIsisVersion()
        End Sub

        Private Sub HookEvents(ByVal enable As Boolean)
            If enable Then
                AddHandler _acquisition.AcquireCanceled, AddressOf _acquisition_AcquireCanceled
                AddHandler _acquisition.AcquireFinished, AddressOf _acquisition_AcquireFinished
                AddHandler _acquisition.BarcodeDetected, AddressOf _acquisition_BarcodeDetected
                AddHandler _acquisition.ErrorNotification, AddressOf _acquisition_ErrorNotification
                AddHandler _acquisition.ImageAcquired, AddressOf _acquisition_ImageAcquired
                AddHandler _acquisition.ImageAcquiring, AddressOf _acquisition_ImageAcquiring
                AddHandler _acquisition.FileAcquisition, AddressOf _acquisition_FileAcquisition
            Else
                RemoveHandler _acquisition.AcquireCanceled, AddressOf _acquisition_AcquireCanceled
                RemoveHandler _acquisition.AcquireFinished, AddressOf _acquisition_AcquireFinished
                RemoveHandler _acquisition.BarcodeDetected, AddressOf _acquisition_BarcodeDetected
                RemoveHandler _acquisition.ErrorNotification, AddressOf _acquisition_ErrorNotification
                RemoveHandler _acquisition.ImageAcquired, AddressOf _acquisition_ImageAcquired
                RemoveHandler _acquisition.ImageAcquiring, AddressOf _acquisition_ImageAcquiring
                RemoveHandler _acquisition.FileAcquisition, AddressOf _acquisition_FileAcquisition
            End If
        End Sub

#Region "Isis Events"

        Private Sub _acquisition_AcquireCanceled(ByVal sender As Object, ByVal e As EventArgs)
            System.Diagnostics.Debug.WriteLine("Acquire Canceled")
        End Sub

        Private Sub _acquisition_AcquireFinished(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub _acquisition_BarcodeDetected(ByVal sender As Object, ByVal e As IsisBarcodeDetectedEventArgs)
            System.Diagnostics.Debug.WriteLine("Barcode Detected: " & e.Text)
        End Sub

        Private Sub _acquisition_ErrorNotification(ByVal sender As Object, ByVal e As IsisErrorNotificationEventArgs)
            If e.Exception Is Nothing Then
                MessageBox.Show(Me, "Error:" & Constants.vbCrLf & Constants.vbCrLf & e.Message + (""), "Error Notification", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(Me, "Error:" & Constants.vbCrLf & Constants.vbCrLf & e.Message + (e.Exception.Message), "Error Notification", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub _acquisition_ImageAcquiring(ByVal sender As Object, ByVal e As IsisImageAcquiringEventArgs)
            ' This event is raised before each page is acquired, allowing it to be canceled.
            Dim count As Integer = CInt(Me.numPageCountLimit.Value)

            If count > 0 Then
                ' suggested by Michael C for proper cancel in ISIS, the scanAhead needs to 
                ' adjust downard
                If _acquisition.ActiveDevice.Settings.ScanAheadCount > count - e.PageCount Then
                    _acquisition.ActiveDevice.Settings.ScanAheadCount = count - e.PageCount
                End If
                ' changed > to >+ for "off by 1 error"
                If e.PageCount >= count Then
                    ' added to ensure scanner stops scanning
                    _acquisition.ActiveDevice.Settings.ScanAhead = False
                    e.Cancel = True
                End If
            End If
        End Sub

        Private Sub _acquisition_ImageAcquired(ByVal sender As Object, ByVal e As IsisImageAcquiredEventArgs)
            ' This event is raised for each page during an acquisition.
            If Not Me.picImage.Image Is Nothing Then
                Me.picImage.Image.Dispose()
            End If

            ' Set the AcquiredImageType property on the IsisAcquisition or IsisController 
            ' to specify whether you receive an AtalaImage or a .NET Bitmap.
            If Not e.Image Is Nothing Then
                Me.picImage.Image = e.Image.ToBitmap()
                e.Image.Dispose()
            ElseIf Not e.Bitmap Is Nothing Then
                Me.picImage.Image = e.Bitmap
            End If

            If e.JobSeparator Then
                System.Diagnostics.Debug.WriteLine("Job Separator")
            End If
        End Sub

        Private Sub _acquisition_FileAcquisition(ByVal sender As Object, ByVal e As IsisFileAcquisitionEventArgs)
            ' This event is raised for each page during a file acquisition.
            If Me.chkSaveMultipage.Checked AndAlso (e.FileType = IsisFileType.Tiff OrElse e.FileType = IsisFileType.Pdf OrElse e.FileType = IsisFileType.Dcx) Then
                e.Append = True ' This can be true for the first page as well.
            End If

            e.FileName = GetCustomFileName(GetFileExtension(e.FileType))

        End Sub

#End Region

        Private Sub btnAcquire_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAcquire.Click
            ' Remove the current image.
            If Not Me.picImage.Image Is Nothing Then
                Me.picImage.Image.Dispose()
            End If
            Me.picImage.Image = Nothing

            Me.Cursor = Cursors.WaitCursor
            EnableControls(False)
            _multipageFile = ""

            Try
                Dim dev As IsisDevice = Me._acquisition.ActiveDevice
                If dev.Open() Then
                    Try
                        ' Set requested properties.
                        dev.Settings.PixelFormat = CType(Me.cboPixelFormat.SelectedItem, IsisPixelFormat)
                        dev.Settings.Resolution = CType(Me.cboResolution.SelectedItem, Rational)

                        If Me.numScanAhead.Value > 0 Then
                            dev.Settings.ScanAhead = True
                            dev.Settings.ScanAheadCount = CInt(Me.numScanAhead.Value)
                        Else
                            dev.Settings.ScanAhead = False
                            dev.Settings.ScanAheadCount = 0
                        End If

                        If Me.chkShowDialog.Checked Then
                            If (Not Me._acquisition.ShowDeviceDialog(Me)) Then
                                Return
                            End If
                        End If

                        If Me.cboScanMode.SelectedIndex = 0 Then
                            dev.Acquire()
                        Else
                            If _fileSaveDir.Length = 0 Then
                                Dim dlg As FolderBrowserDialog = New FolderBrowserDialog()
                                dlg.Description = "Select where these images will be saved."
                                If dlg.ShowDialog(Me) = DialogResult.OK Then
                                    _fileSaveDir = dlg.SelectedPath
                                    dev.AcquireToFile(CType(Me.cboFileType.SelectedItem, IsisFileType), CType(Me.cboCompression.SelectedItem, IsisCompression))
                                End If
                                dlg.Dispose()
                            Else
                                dev.AcquireToFile(CType(Me.cboFileType.SelectedItem, IsisFileType), CType(Me.cboCompression.SelectedItem, IsisCompression))
                            End If
                        End If
                    Finally
                        dev.Close()
                    End Try
                End If
            Finally
                EnableControls(True)
                Me.Cursor = Cursors.Default
            End Try
        End Sub

#Region "Combobox Selection Changed Events"

        Private Sub cboDevices_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDevices.SelectedIndexChanged
            ' Clear and rebuild the scanner options.
            Me.cboFileType.Items.Clear()
            Me.cboCompression.Items.Clear()
            Me.cboPixelFormat.Items.Clear()
            Me.cboResolution.Items.Clear()

            Me.Cursor = Cursors.WaitCursor

            ' Set the active device and query its capabilities.
            Me._acquisition.ActiveDevice = CType(Me.cboDevices.SelectedItem, IsisDevice)
            If Me._acquisition.ActiveDevice.Open() = False Then
                Me.Cursor = Cursors.Default
                Return
            End If

            Try
                Dim settings As IsisSettings = _acquisition.ActiveDevice.Settings

                ' Drivers must support color format, so there is no need to use QuerySupport on it.
                _driverColorFormats = settings.GetSupportedColorFormats()
                If Not _driverColorFormats Is Nothing Then
                    FillColorFormatControl(_driverColorFormats, settings.PixelFormat)
                End If

                If settings.QuerySupport(IsisSetting.FileType) Then
                    _usingIsisCodecs = False

                    Dim fileTypes As IsisFileType() = settings.GetSupportedFileTypes()
                    If Not fileTypes Is Nothing Then
                        FillFileTypeControl(fileTypes, settings.FileType)
                    End If
                Else
                    _usingIsisCodecs = True

                    ' See if there are other ISIS drivers which can be used to save the file.
                    Dim fts As IsisFileType() = _acquisition.CodecManager.GetFileTypes()
                    If Not fts Is Nothing Then
                        If fts.Length > 0 Then FillFileTypeControl(fts, fts(0))
                    End If
                End If

                If settings.QuerySupport(IsisSetting.ResolutionX) Then
                    Dim resolutions As Rational() = settings.GetSupportedResolutions()
                    If Not resolutions Is Nothing Then
                        For Each rat As Rational In resolutions
                            Me.cboResolution.Items.Add(rat)
                        Next rat
                    End If

                    Dim resIndex As Integer = Me.cboResolution.Items.IndexOf(settings.Resolution)
                    If resIndex <> -1 Then
                        Me.cboResolution.SelectedIndex = resIndex
                    End If
                End If
            Finally
                Me._acquisition.ActiveDevice.Close()
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub cboAcquiredImageType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAcquiredImageType.SelectedIndexChanged
            If Me.cboAcquiredImageType.Text = "AtalaImage" Then
                Me._acquisition.AcquiredImageType = (IsisAcquiredImageType.AtalaImage)
            Else
                Me._acquisition.AcquiredImageType = (IsisAcquiredImageType.Bitmap)
            End If
        End Sub

        Private Sub cboFileType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFileType.SelectedIndexChanged
            Dim ff As IsisFileType = CType(Me.cboFileType.SelectedItem, IsisFileType)
            Me.chkSaveMultipage.Enabled = (ff = IsisFileType.Tiff OrElse ff = IsisFileType.Pdf OrElse ff = IsisFileType.Dcx)
            If (Not Me.chkSaveMultipage.Enabled) Then
                Me.chkSaveMultipage.Checked = False
            End If

            If _usingIsisCodecs Then
                If Me.cboScanMode.Text.Equals("File") Then
                    FillFileTypeColorFormats()
                End If

                Me.cboCompression.Items.Clear()
                Dim comps As IsisCompression() = Me._acquisition.CodecManager(ff).GetSupportedCompressions()
                If Not comps Is Nothing Then
                    For Each c As IsisCompression In comps
                        Me.cboCompression.Items.Add(c)
                    Next c

                    Me.cboCompression.SelectedIndex = 0
                End If
            Else
                If Me._acquisition.ActiveDevice.Open() Then
                    Try
                        Me._acquisition.ActiveDevice.Settings.FileType = ff
                        Dim comps As IsisCompression() = Me._acquisition.ActiveDevice.Settings.GetSupportedCompressions()
                        If Not comps Is Nothing Then
                            For Each c As IsisCompression In comps
                                Me.cboCompression.Items.Add(c)
                            Next c

                            Me.cboCompression.SelectedIndex = 0
                        End If
                    Finally
                        Me._acquisition.ActiveDevice.Close()
                    End Try
                End If
            End If
        End Sub

        Private Sub cboScanMode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboScanMode.SelectedIndexChanged
            Dim fileMode As Boolean = Me.cboScanMode.Text.Equals("File")
            Me.cboFileType.Enabled = fileMode
            Me.cboCompression.Enabled = fileMode
            Me.chkSaveMultipage.Enabled = fileMode

            If fileMode Then
                If Me.cboFileType.SelectedIndex <> -1 Then
                    FillFileTypeColorFormats()
                End If
            ElseIf Not _driverColorFormats Is Nothing Then
                If _driverColorFormats.Length > 0 Then
                    FillColorFormatControl(_driverColorFormats, _driverColorFormats(0))
                End If
            End If
        End Sub

        Private Sub cboPixelFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPixelFormat.SelectedIndexChanged
            ' Only allow supported compressions.
            If _usingIsisCodecs AndAlso Me.cboFileType.SelectedIndex <> -1 AndAlso Me.cboPixelFormat.SelectedIndex <> -1 Then
                Dim ft As IsisFileType = CType(Me.cboFileType.SelectedItem, IsisFileType)
                Dim pf As IsisPixelFormat = CType(Me.cboPixelFormat.SelectedItem, IsisPixelFormat)

                Dim comps As IsisCompression() = Me._acquisition.CodecManager(ft).GetSupportedCompressions(pf)
                If Not comps Is Nothing Then
                    Me.cboCompression.Items.Clear()
                    For Each comp As IsisCompression In comps
                        Me.cboCompression.Items.Add(comp)
                    Next comp

                    Me.cboCompression.SelectedIndex = 0
                End If
            End If
        End Sub

#End Region

        Private Sub EnableControls(ByVal enabled As Boolean)
            Me.btnAcquire.Enabled = enabled
            Me.cboDevices.Enabled = enabled
            Me.chkShowDialog.Enabled = enabled
            Me.groupBox1.Enabled = enabled
        End Sub

        Private Sub FillFileTypeColorFormats()
            If (Not _usingIsisCodecs) OrElse _driverColorFormats Is Nothing Then
                Return
            End If

            ' Fill the color format list so it only contains
            ' valid formats for the selected file type.
            Dim ft As IsisFileType = CType(Me.cboFileType.SelectedItem, IsisFileType)
            Dim cfs As IsisPixelFormat() = _acquisition.CodecManager(ft).GetSupportedColorFormats()
            If Not cfs Is Nothing Then
                ' Make sure the color format is supported by the driver.
                Dim list As ArrayList = New ArrayList()
                For Each cf As IsisPixelFormat In cfs
                    For Each dcf As IsisPixelFormat In _driverColorFormats
                        If dcf = cf Then
                            list.Add(cf)
                            Exit For
                        End If
                    Next dcf
                Next cf

                cfs = CType(list.ToArray(GetType(IsisPixelFormat)), IsisPixelFormat())

                If Not cfs Is Nothing Then
                    FillColorFormatControl(cfs, cfs(0))
                End If
            End If

            Me.chkSaveMultipage.Enabled = (ft = IsisFileType.Dcx OrElse ft = IsisFileType.Pdf OrElse ft = IsisFileType.Tiff)
        End Sub

        Private Sub FillColorFormatControl(ByVal formats As IsisPixelFormat(), ByVal selected As IsisPixelFormat)
            Me.cboPixelFormat.Items.Clear()

            If Not formats Is Nothing Then
                Dim selectedIndex As Integer = 0
                Dim index As Integer = 0

                For Each cf As IsisPixelFormat In formats
                    Me.cboPixelFormat.Items.Add(cf)
                    If cf = selected Then
                        selectedIndex = index
                    End If
                    index += 1
                Next cf

                Me.cboPixelFormat.SelectedIndex = selectedIndex
            End If
        End Sub

        Private Sub FillFileTypeControl(ByVal fileTypes As IsisFileType(), ByVal selected As IsisFileType)
            Me.cboFileType.Items.Clear()

            If Not fileTypes Is Nothing Then
                Dim selectedIndex As Integer = 0
                Dim index As Integer = 0

                For Each ft As IsisFileType In fileTypes
                    Me.cboFileType.Items.Add(ft)
                    If ft = selected Then
                        selectedIndex = index
                        Me.chkSaveMultipage.Enabled = (ft = IsisFileType.Tiff OrElse ft = IsisFileType.Pdf OrElse ft = IsisFileType.Dcx)
                    End If
                    index += 1
                Next ft

                Me.cboFileType.SelectedIndex = selectedIndex
            End If
        End Sub

        Private Function GetCustomFileName(ByVal extension As String) As String
            ' Use the same filename for multipage support.
            If _multipageFile.Length > 0 Then
                Return _multipageFile
            End If

            Dim filename As String = _fileSaveDir & "\scan_" & _fileCount.ToString() & extension

            Do While System.IO.File.Exists(filename)
                _fileCount += 1
                filename = _fileSaveDir & "\scan_" & _fileCount.ToString() & extension
            Loop

            If Me.chkSaveMultipage.Checked Then
                _multipageFile = filename
            End If

            Return filename
        End Function

        Private Function GetFileExtension(ByVal fileType As IsisFileType) As String
            Select Case fileType
                Case IsisFileType.Bmp
                    Return ".bmp"
                Case IsisFileType.Dcx
                    Return ".dcx"
                Case IsisFileType.Gif
                    Return ".gif"
                Case IsisFileType.Jbig
                    Return ".jbg"
                Case IsisFileType.Jpeg
                    Return ".jpg"
                Case IsisFileType.Jpeg2000
                    Return ".jp2"
                Case IsisFileType.Pcx
                    Return ".pcx"
                Case IsisFileType.Pda
                    Return ".pda"
                Case IsisFileType.Pdf
                    Return ".pdf"
                Case IsisFileType.Png
                    Return ".png"
                Case IsisFileType.Cals
                    Return ".cal"
                Case IsisFileType.MoDca
                    Return ".dca"
                Case Else
                    Return ".tif"
            End Select
        End Function

        Private Function GetDotImageIsisVersion() As String
            Try
                Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.Load("Atalasoft.dotImage.Isis")
                Dim ver As Version = asm.GetName().Version
                Return ver.ToString()
            Catch
                Return "unknown"
            End Try
        End Function

        Private Sub ButtonAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAbout.Click
            Dim aboutBox As AtalaDemos.AboutBox.About = New AtalaDemos.AboutBox.About("Atalasoft DotImage ISIS Demo", "ISIS Demo")
            aboutBox.Description = "Basic scanner selection and acquisition using Atalasoft's ISIS components." & vbCrLf & vbCrLf & _
            "This is a slightly scaled down ISIS version of our TWAIN Acquisition Demo. Its main purpose is to demonstrate the basics of how select from available ISIS scanners, and how to control various basic settings like pixel format, resolution, and whether or not to show the device's default scanning dialog." & vbCrLf & vbCrLf & _
            "The source code should provide a solid foundation in understanding how to work with our ISIS scanning components, while the running demo provides a quick means to 'sanity check' whether your scanner is visible to DotImage."
            aboutBox.ShowDialog()
        End Sub
    End Class
End Namespace
