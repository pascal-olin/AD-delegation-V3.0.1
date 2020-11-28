<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShapeA = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShapeR = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.OvalShape2 = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.OvalShape1 = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.debux = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.tbuser = New System.Windows.Forms.TextBox()
        Me.lblUserDN = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.debug = New System.Windows.Forms.CheckBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.TbGroup = New System.Windows.Forms.TextBox()
        Me.ListView3 = New System.Windows.Forms.ListView()
        Me.Auth = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Group_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.ListBox4 = New System.Windows.Forms.ListBox()
        Me.newgroupButton = New System.Windows.Forms.Button()
        Me.newgroupdescrbox = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LVAccess = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LVGroup = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.NewPasswordBox = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.newgroupBox = New System.Windows.Forms.TextBox()
        Me.wait = New System.Windows.Forms.RichTextBox()
        Me.newgroupprefixbox = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tips = New System.Windows.Forms.CheckBox()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.RecurseGrps = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShapeA, Me.RectangleShapeR, Me.RectangleShape2, Me.RectangleShape1, Me.OvalShape2, Me.OvalShape1, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1122, 873)
        Me.ShapeContainer1.TabIndex = 33
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShapeA
        '
        Me.RectangleShapeA.BorderColor = System.Drawing.SystemColors.Window
        Me.RectangleShapeA.FillColor = System.Drawing.SystemColors.Window
        Me.RectangleShapeA.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShapeA.Location = New System.Drawing.Point(341, 443)
        Me.RectangleShapeA.Name = "RectangleShapeA"
        Me.RectangleShapeA.Size = New System.Drawing.Size(223, 28)
        '
        'RectangleShapeR
        '
        Me.RectangleShapeR.BorderColor = System.Drawing.SystemColors.Window
        Me.RectangleShapeR.FillColor = System.Drawing.SystemColors.Window
        Me.RectangleShapeR.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShapeR.Location = New System.Drawing.Point(341, 478)
        Me.RectangleShapeR.Name = "RectangleShapeR"
        Me.RectangleShapeR.Size = New System.Drawing.Size(223, 28)
        '
        'RectangleShape2
        '
        Me.RectangleShape2.FillColor = System.Drawing.SystemColors.Info
        Me.RectangleShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape2.Location = New System.Drawing.Point(10, 114)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(907, 5)
        '
        'RectangleShape1
        '
        Me.RectangleShape1.FillColor = System.Drawing.SystemColors.Info
        Me.RectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape1.Location = New System.Drawing.Point(12, 430)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(907, 5)
        '
        'OvalShape2
        '
        Me.OvalShape2.BorderWidth = 3
        Me.OvalShape2.Location = New System.Drawing.Point(664, 833)
        Me.OvalShape2.Name = "OvalShape2"
        Me.OvalShape2.Size = New System.Drawing.Size(229, 50)
        '
        'OvalShape1
        '
        Me.OvalShape1.BorderWidth = 3
        Me.OvalShape1.Location = New System.Drawing.Point(336, 455)
        Me.OvalShape1.Name = "OvalShape1"
        Me.OvalShape1.Size = New System.Drawing.Size(229, 38)
        '
        'LineShape1
        '
        Me.LineShape1.BorderColor = System.Drawing.Color.Green
        Me.LineShape1.BorderWidth = 5
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 614
        Me.LineShape1.X2 = 618
        Me.LineShape1.Y1 = 809
        Me.LineShape1.Y2 = 932
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(550, 685)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 20)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "List user Groups"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'debux
        '
        Me.debux.Location = New System.Drawing.Point(12, 722)
        Me.debux.Name = "debux"
        Me.debux.Size = New System.Drawing.Size(332, 135)
        Me.debux.TabIndex = 1
        Me.debux.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 700)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Debug Information"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(384, 722)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(154, 20)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "dc=serco,dc=eu"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Red
        Me.Button2.Location = New System.Drawing.Point(815, 717)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(152, 28)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Get all groups of user"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(589, 183)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(126, 20)
        Me.TextBox2.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.TextBox2, "Enter here a search pattern for Users that you may want to check/add/remove" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "or g" &
        "roups you may want to check/add/remove")
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(384, 835)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(233, 20)
        Me.TextBox3.TabIndex = 6
        Me.TextBox3.Visible = False
        '
        'ListView1
        '
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(339, 854)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(328, 78)
        Me.ListView1.TabIndex = 7
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(124, 85)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(177, 20)
        Me.TextBox4.TabIndex = 8
        Me.TextBox4.Text = "userid"
        '
        'ListView2
        '
        Me.ListView2.HideSelection = False
        Me.ListView2.Location = New System.Drawing.Point(384, 760)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(203, 78)
        Me.ListView2.TabIndex = 9
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.Visible = False
        '
        'tbuser
        '
        Me.tbuser.Location = New System.Drawing.Point(561, 464)
        Me.tbuser.Name = "tbuser"
        Me.tbuser.ReadOnly = True
        Me.tbuser.Size = New System.Drawing.Size(203, 20)
        Me.tbuser.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.tbuser, "This is the subject user/group that you are" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "currently pointing to in order to ad" &
        "d or remove " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "it from the container group on the left")
        '
        'lblUserDN
        '
        Me.lblUserDN.Location = New System.Drawing.Point(415, 85)
        Me.lblUserDN.Name = "lblUserDN"
        Me.lblUserDN.Size = New System.Drawing.Size(315, 20)
        Me.lblUserDN.TabIndex = 11
        Me.lblUserDN.Text = "lblUserDN"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(552, 748)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(188, 28)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "List users in the selected group"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(573, 228)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(157, 134)
        Me.ListBox1.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.ListBox1, "Click on a subject username to display it's groups")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(127, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(236, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Your group membership, Select one to manage it"
        '
        'ListBox2
        '
        Me.ListBox2.BackColor = System.Drawing.SystemColors.Control
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(423, 176)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(144, 186)
        Me.ListBox2.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(417, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Group composed of:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(121, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(196, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Domain account of current Administrator"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(721, 183)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(194, 21)
        Me.Button4.TabIndex = 19
        Me.Button4.Text = "Search matching users/group"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'debug
        '
        Me.debug.AutoSize = True
        Me.debug.Location = New System.Drawing.Point(742, 94)
        Me.debug.Name = "debug"
        Me.debug.Size = New System.Drawing.Size(65, 17)
        Me.debug.TabIndex = 20
        Me.debug.Text = "debug ?"
        Me.debug.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(572, 782)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(148, 25)
        Me.Button5.TabIndex = 21
        Me.Button5.Text = "Get all OUS"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(552, 711)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(147, 31)
        Me.Button6.TabIndex = 22
        Me.Button6.Text = "Get this user OU"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TbGroup
        '
        Me.TbGroup.Location = New System.Drawing.Point(139, 464)
        Me.TbGroup.Name = "TbGroup"
        Me.TbGroup.ReadOnly = True
        Me.TbGroup.Size = New System.Drawing.Size(211, 20)
        Me.TbGroup.TabIndex = 23
        Me.ToolTip1.SetToolTip(Me.TbGroup, "This is your container group where target users can be inserted or removed")
        '
        'ListView3
        '
        Me.ListView3.BackColor = System.Drawing.SystemColors.Control
        Me.ListView3.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Auth, Me.Group_Name})
        Me.ListView3.Cursor = System.Windows.Forms.Cursors.Cross
        Me.ListView3.FullRowSelect = True
        Me.ListView3.GridLines = True
        Me.ListView3.HideSelection = False
        Me.ListView3.Location = New System.Drawing.Point(124, 176)
        Me.ListView3.MultiSelect = False
        Me.ListView3.Name = "ListView3"
        Me.ListView3.ShowItemToolTips = True
        Me.ListView3.Size = New System.Drawing.Size(298, 186)
        Me.ListView3.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.ListView3.TabIndex = 25
        Me.ToolTip1.SetToolTip(Me.ListView3, "This is the list of groups you are member of." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Select one of these groups to star" &
        "t viewing/modifying it. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.ListView3.UseCompatibleStateImageBehavior = False
        Me.ListView3.View = System.Windows.Forms.View.Details
        '
        'Auth
        '
        Me.Auth.Text = "Auth"
        '
        'Group_Name
        '
        Me.Group_Name.Text = "Group_Name"
        Me.Group_Name.Width = 234
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(742, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(178, 64)
        Me.PictureBox1.TabIndex = 26
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(112, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(410, 24)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Serco EA : AD Groups Editor for Data managers"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(381, 703)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Current OU"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(136, 448)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Container Group"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(558, 448)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Subject user"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(411, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 13)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "DN of current Administrator"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(588, 147)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(185, 26)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Search a user or group (e.g. Fred*) to " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "add him/her to the selected group" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(365, 443)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(173, 23)
        Me.Button7.TabIndex = 35
        Me.Button7.Text = "Add this user to that group"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(364, 483)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(173, 23)
        Me.Button8.TabIndex = 36
        Me.Button8.Text = "Remove this user from that group"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(705, 720)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(102, 22)
        Me.Button9.TabIndex = 37
        Me.Button9.Text = "Open This Group"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(746, 752)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(152, 24)
        Me.Button10.TabIndex = 38
        Me.Button10.Text = "predict behaviour"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Info
        Me.Label11.Font = New System.Drawing.Font("Arial Black", 12.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(13, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 69)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "1) " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You : the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Deleguee"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Info
        Me.Label12.Font = New System.Drawing.Font("Arial Black", 12.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 179)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(111, 92)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "2) " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Your Users " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and groups" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "selection" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        '
        'ListBox3
        '
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.Location = New System.Drawing.Point(573, 368)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(258, 56)
        Me.ListBox3.TabIndex = 42
        Me.ToolTip1.SetToolTip(Me.ListBox3, "Click on a subject group to fill up the action panel (3). " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This list represents " &
        "only the groups that you  (admin)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and the subject user/group have in common")
        '
        'ListBox4
        '
        Me.ListBox4.FormattingEnabled = True
        Me.ListBox4.Location = New System.Drawing.Point(752, 228)
        Me.ListBox4.Name = "ListBox4"
        Me.ListBox4.Size = New System.Drawing.Size(163, 134)
        Me.ListBox4.TabIndex = 57
        Me.ToolTip1.SetToolTip(Me.ListBox4, "Click on a subject group to display it's groups")
        '
        'newgroupButton
        '
        Me.newgroupButton.Location = New System.Drawing.Point(364, 561)
        Me.newgroupButton.Name = "newgroupButton"
        Me.newgroupButton.Size = New System.Drawing.Size(173, 23)
        Me.newgroupButton.TabIndex = 48
        Me.newgroupButton.Text = "Create a new group"
        Me.ToolTip1.SetToolTip(Me.newgroupButton, "Click here to create a new subject group")
        Me.newgroupButton.UseVisualStyleBackColor = True
        '
        'newgroupdescrbox
        '
        Me.newgroupdescrbox.Location = New System.Drawing.Point(561, 603)
        Me.newgroupdescrbox.Name = "newgroupdescrbox"
        Me.newgroupdescrbox.Size = New System.Drawing.Size(291, 20)
        Me.newgroupdescrbox.TabIndex = 53
        Me.ToolTip1.SetToolTip(Me.newgroupdescrbox, "Enter here a new subject group description. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please use a meaningful description" &
        " corresponding " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to this group's aim.")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Info
        Me.Label13.Font = New System.Drawing.Font("Arial Black", 12.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(13, 443)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(111, 92)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "3) " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Your action" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "on that " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "selection" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'LVAccess
        '
        Me.LVAccess.Text = "Access type"
        Me.LVAccess.Width = 102
        '
        'LVGroup
        '
        Me.LVGroup.Text = "AD Group name"
        Me.LVGroup.Width = 399
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(586, 206)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(103, 13)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "Subject Users found"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(417, 372)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(141, 26)
        Me.Label15.TabIndex = 44
        Me.Label15.Text = "Container Groups you share " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "with this user/group"
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(365, 523)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(173, 23)
        Me.Button11.TabIndex = 45
        Me.Button11.Text = "Reset this user password"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'NewPasswordBox
        '
        Me.NewPasswordBox.Location = New System.Drawing.Point(561, 526)
        Me.NewPasswordBox.Name = "NewPasswordBox"
        Me.NewPasswordBox.Size = New System.Drawing.Size(193, 20)
        Me.NewPasswordBox.TabIndex = 46
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(558, 510)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(118, 13)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "New password for user "
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(558, 549)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(95, 13)
        Me.Label17.TabIndex = 50
        Me.Label17.Text = "New Group Name "
        '
        'newgroupBox
        '
        Me.newgroupBox.Location = New System.Drawing.Point(659, 563)
        Me.newgroupBox.Name = "newgroupBox"
        Me.newgroupBox.Size = New System.Drawing.Size(193, 20)
        Me.newgroupBox.TabIndex = 49
        '
        'wait
        '
        Me.wait.BackColor = System.Drawing.Color.Yellow
        Me.wait.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.wait.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.wait.Location = New System.Drawing.Point(631, 851)
        Me.wait.Name = "wait"
        Me.wait.Size = New System.Drawing.Size(868, 453)
        Me.wait.TabIndex = 51
        Me.wait.Text = "Please wait as system computes"
        '
        'newgroupprefixbox
        '
        Me.newgroupprefixbox.Location = New System.Drawing.Point(561, 563)
        Me.newgroupprefixbox.Name = "newgroupprefixbox"
        Me.newgroupprefixbox.ReadOnly = True
        Me.newgroupprefixbox.Size = New System.Drawing.Size(92, 20)
        Me.newgroupprefixbox.TabIndex = 52
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(558, 587)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(117, 13)
        Me.Label18.TabIndex = 54
        Me.Label18.Text = "New Group Description"
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(740, 685)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(74, 20)
        Me.Button12.TabIndex = 55
        Me.Button12.Text = "Button12"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(659, 684)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(75, 23)
        Me.Button13.TabIndex = 56
        Me.Button13.Text = "Button13"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(749, 207)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(110, 13)
        Me.Label19.TabIndex = 58
        Me.Label19.Text = "Subject Groups found"
        '
        'tips
        '
        Me.tips.AutoSize = True
        Me.tips.Location = New System.Drawing.Point(815, 95)
        Me.tips.Name = "tips"
        Me.tips.Size = New System.Drawing.Size(73, 17)
        Me.tips.TabIndex = 59
        Me.tips.Text = "Tips on ? "
        Me.tips.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(126, 372)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(190, 24)
        Me.Button14.TabIndex = 60
        Me.Button14.Text = "Refresh Application"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'RecurseGrps
        '
        Me.RecurseGrps.AutoSize = True
        Me.RecurseGrps.Location = New System.Drawing.Point(126, 128)
        Me.RecurseGrps.Name = "RecurseGrps"
        Me.RecurseGrps.Size = New System.Drawing.Size(431, 17)
        Me.RecurseGrps.TabIndex = 61
        Me.RecurseGrps.Text = "Enable Recursive Groups Membership scanning (Very recent groups might be missing)" &
    ""
        Me.RecurseGrps.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1122, 873)
        Me.Controls.Add(Me.RecurseGrps)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.tips)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.ListBox4)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.newgroupdescrbox)
        Me.Controls.Add(Me.newgroupprefixbox)
        Me.Controls.Add(Me.wait)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.newgroupBox)
        Me.Controls.Add(Me.newgroupButton)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.NewPasswordBox)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.ListBox3)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ListView3)
        Me.Controls.Add(Me.TbGroup)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.debug)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.lblUserDN)
        Me.Controls.Add(Me.tbuser)
        Me.Controls.Add(Me.ListView2)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.debux)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "MainForm"
        Me.Text = "Serco EA : AD Groups Editor for Data managers"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents OvalShape1 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents OvalShape2 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShapeA As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShapeR As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents debux As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents tbuser As System.Windows.Forms.TextBox
    Friend WithEvents lblUserDN As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents debug As System.Windows.Forms.CheckBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TbGroup As System.Windows.Forms.TextBox
    Friend WithEvents ListView3 As System.Windows.Forms.ListView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ListBox3 As System.Windows.Forms.ListBox
    Friend WithEvents LVAccess As System.Windows.Forms.ColumnHeader
    Friend WithEvents LVGroup As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Auth As System.Windows.Forms.ColumnHeader
    Friend WithEvents Group_Name As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents NewPasswordBox As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents newgroupButton As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents newgroupBox As System.Windows.Forms.TextBox
    Friend WithEvents wait As System.Windows.Forms.RichTextBox
    Friend WithEvents newgroupprefixbox As System.Windows.Forms.TextBox
    Friend WithEvents newgroupdescrbox As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents ListBox4 As System.Windows.Forms.ListBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tips As System.Windows.Forms.CheckBox
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents RecurseGrps As System.Windows.Forms.CheckBox
End Class
