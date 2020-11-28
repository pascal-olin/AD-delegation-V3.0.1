Option Strict On
Imports ActiveDs
Imports System.DirectoryServices
Imports System.DirectoryServices.ActiveDirectory
Imports System.DirectoryServices.AccountManagement
Imports System.Text
Imports System.Collections.Generic
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Public Class MainForm
    Dim valid_uname As Boolean = False
    Dim valid_gname As Boolean = False
    Dim target_is_group As Boolean = False
    'Dim predict_array As New Dictionary(Of String, Integer)
    'Dim predict_array As New Dictionary(Of String, Integer)
    Private Function naming_convention(ByVal name As String) As String
        If CStr(name) = "France" Then Return ("SCHG")
        If CStr(name) = "Germany" Then Return ("SDAR")
        If CStr(name) = "Germany - Teltow" Then Return ("SDAR")
        If CStr(name) = "Holland" Or CStr(name) = "Netherland" Then Return ("SKAT")
        If CStr(name) = "Belgium" Then Return ("SBRU")
        If CStr(name) = "Italy" Then Return ("SFRA")
        If CStr(name) = "SEA" Then Return ("SEA")
        If CStr(name) = "SEA Sales" Then Return ("SEA Sales")
        If CStr(name) = "Domain Admins" Then Return ("SEA ICT")
        Return ("unknown")
    End Function


    Private Function get_user_ou() As List(Of String)
        Dim bits As String() = lblUserDN.Text.Split(New Char() {","c}) 'we have stored the full container in textbox5 during the above (private) loop. 
        ' now we process it !
        ' Loop through result strings with For Each
        Dim bit As String
        Dim str_container As String = ""
        Dim ou As New List(Of String)
        ou.Add("a")
        ou.Add("b")
        ou.Add("c")
        ou(1) = "A" 'Ou name 
        ou(2) = "A" 'full path of this ou
        Dim fullpath As String = ""
        For Each bit In New ReverseIterator(bits)
            ' For Each bit In bits
            'right now we should have the distinguished name split into bit ...
            'we therefore have each OU name ... and what we want it the comments field (and maybe some others) of each OU
            ' we are processing the context in reverse order, this means that we are able to recreate the 
            'container, bit by bit, in other terms, we examine the ous one after the other in the right order
            debux.AppendText("object found for that user: " & bit & vbCrLf)
            'Dim initial As String = GetChar(CStr(bit), 2)
            Dim initial As String = bit.Substring(0, 2) 'check if this an OU or anything else (e.g. dc= or CN=)
            If Not UCase(initial) = "OU" Then
                ' if the node is not an OU we still build our container with relevant information (have to as it has to be complete
                ' we just do not examine the properties for anything else than an OU
                debux.AppendText("not an ou : " & bit & " " & initial & vbCrLf)
                If Not UCase(initial) = "CN" Then str_container = "," & bit & str_container
                Continue For
            End If
            str_container = "," & bit & str_container
            'If we reach this point, it means that the node we are investigating (bit) is an OU
            ou(1) = bit.Substring(3)
            'getting this OU properties one after the other. 
            debux.AppendText("found OU : " & ou(1) & " full path " & ou(2) & vbCrLf)
        Next
        ou(2) = str_container
        Return (ou)
    End Function

    Class ReverseIterator
        Implements IEnumerable

        ' a low-overhead ArrayList to store references
        Dim items As New ArrayList()

        Sub New(ByVal collection As IEnumerable)
            ' load all the items in the ArrayList, but in reverse order
            Dim o As Object
            For Each o In collection
                items.Insert(0, o)
            Next
        End Sub
        Public Function GetEnumerator() As System.Collections.IEnumerator _
            Implements System.Collections.IEnumerable.GetEnumerator
            ' return the enumerator of the inner ArrayList
            Return items.GetEnumerator()
        End Function
    End Class
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'this will simply list the group of the username selected in listbox1 and return these groups samAccounName in listbox3.
        Dim userName As String = ""
        Dim domainName As String = String.Empty
        domainName = TextBox1.Text

        'Console.WriteLine("Getting the user's group membership info...")
        debux.AppendText("getting users group" & vbCrLf)

        Try 'catch error if we cannot proceed with the search e.g. no DC available.
            Dim ctx As New PrincipalContext(ContextType.Domain)
            'Dim ctx As New PrincipalContext(ContextType.Machine)
            Dim qbeuser As New UserPrincipal(ctx)
            qbeuser.SamAccountName = CStr(tbuser.Text)
            Dim p As New PrincipalSearcher(qbeuser)
            Dim members = p.FindAll
            ListBox3.Items.Clear() 'housekeeping reset admin group list. 
            ListBox4.Items.Clear() 'housekeeping reset user group list. 
            ' reset_action_colors() 'housekeeping : reset actions buttons and fields.
            Dim cntuser As Integer = members.Count
            If cntuser = 0 Then
                MsgBox("Retry", CType(vbOK, MsgBoxStyle), "No user with that name found")
                Exit Sub
            End If
            Using members
                For Each member In members
                    Me.debux.AppendText("number of users found by search : " & CStr(cntuser) & vbCrLf)
                    Me.debux.AppendText(member.SamAccountName & member.DisplayName & vbCrLf)
                    'ListBox2.Items.Add(member.SamAccountName)
                    ' here, we get all the groups our user is memberof, we will display only the groups contained in the OU he is part of.
                    Using p1 = UserPrincipal.FindByIdentity(ctx, member.SamAccountName)
                        Dim groups = p1.GetGroups()
                        'ok careful here : changing groups feed to be getAuthorisationGroups instead of getgroups
                        'Dim groups = p1.GetAuthorizationGroups()

                        Using groups
                            For Each group In groups
                                Me.debux.AppendText(group.SamAccountName & group.DisplayName & vbCrLf)
                                ' lv2.SubItems.Add(group.SamAccountName & group.DisplayName & vbCrLf)
                                ' AddItemToListView(group.DisplayName, group.SamAccountName)
                                'Dim initial As String = GetChar(CStr(group.SamAccountName), 1)
                                Dim initial As String = group.SamAccountName.Substring(0, 4)
                                'warning warning .... ethically we will display only the user group fro which the administrator has acces. 
                                'warning warning ... this means that admin cannot delete users from groups that they are not meant to administer
                                'warning warning ... This behaviour seems (to me at least) the only defendable (and will prevent a lot of issues I guess) 
                                ' If (initial = "SCHG" Or initial = "SBRU" Or initial = "SDAR" Or initial = "SKAT" Or initial = "SFRA" Or initial = "SEA " Or initial = "SEA_") Then
                                If (True) Then
                                    'add the group in listbox4 (all groups for that user) 
                                    ListBox4.Items.Add(CStr(group.SamAccountName))
                                    'check if this group is part of our list of groups for the admin 
                                    'Dim prefix As String = "-->"
                                    Dim admrw As Boolean = True
                                    ' prefix = "!!!"
                                    Dim tt3 As ListViewItem = ListView3.FindItemWithText(group.SamAccountName, True, 0, False)
                                    If tt3 Is Nothing Then admrw = False
                                    'If (ListView3.Items.Find(group.SamAccountName, False)) Is Nothing Then prefix = ">-<"
                                    'If Not initial = "x" Then 'for the moment, we display only the groups starting by S, 
                                    'I need to find a way to display only those of the OU. (that shall come later, see button 5 code)
                                    Dim pto As String()
                                    'pto = New String() {"allowedChildClasses"}
                                    'pto = New String() {"allowedAttributes"}
                                    pto = New String() {"allowedAttributesEffective"}
                                    For Each ptt In pto
                                        debux.AppendText("string is " & ptt & vbCrLf)
                                    Next
                                    'Dim testrw As New DirectoryEntry("LDAP://" & group.DistinguishedName, "serco-eu\pascal olin", "OBafgkmn0")

                                    Dim testrw As New DirectoryEntry("LDAP://" & group.DistinguishedName)

                                    'Dim testrw As New DirectoryEntry("LDAP://dc=serco,dc=eu")
                                    debux.AppendText("checking rights to group " & group.DistinguishedName & vbCrLf)
                                    testrw.RefreshCache(pto)
                                    Dim thisgroupro As Boolean = True
                                    Dim s3 As Integer
                                    s3 = testrw.Properties("allowedAttributesEffective").Count
                                    debux.AppendText("number of attributesEffective for this group " & CStr(s3) & " " & group.DistinguishedName & vbCrLf)
                                    thisgroupro = True
                                    If s3 > 0 Then thisgroupro = False
                                    If (thisgroupro = True Or admrw = False) Then
                                        'ListBox3.Items.Add(prefix & "READ : " & CStr(group.SamAccountName))
                                        'ListBox3.d()
                                    Else
                                        ListBox3.Items.Add(CStr(group.SamAccountName))
                                    End If
                                    'Label2.Visible = True 'name our list ? 
                                End If 'if the initial 4 chars of the group is not one of ours, then simply do not display it (good enough for me) 
                            Next
                        End Using
                    End Using

                Next
            End Using
        Catch ex As Exception
            Dim extext As String
            extext = ex.Message
            MsgBox("Operation Get user groups failed with severe exception: " & vbCrLf & extext, , "Error")
            Me.Close() 'close form 1, call all destruct methods
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim debuxswitch As Boolean = False
        Label5.Text = "Serco EA : AD Groups Editor for Data managers, Version " & Application.ProductVersion()
        Me.Text = "Serco EA : AD Groups Editor for Data managers, Version " & Application.ProductVersion()
        OvalShape1.BorderColor = Color.White
        OvalShape1.BorderWidth = 0
        Button7.Enabled = False 'add user button 
        Button8.Enabled = False 'remove user button 
        Button11.Enabled = False 'that's the password reset button
        Button7.BackColor = Color.Empty
        Button8.BackColor = Color.Empty
        Button11.BackColor = Color.Empty
        TbGroup.BackColor = Color.Empty
        tbuser.BackColor = Color.Empty
        Label16.Text = "New password for user"

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        reset_action_colors()
        Label3.Text = "Group composed of: "
        If tips.CheckState = 1 Then
            ToolTip1.Active = True
        Else
            ToolTip1.Active = False
        End If
        If debug.CheckState = 1 Then
            debuxswitch = True
        End If
        Me.MaximizeBox = debuxswitch
        'lblUserDN.Visible = debuxswitch
        'Label10.Visible = debuxswitch
        ListView1.Visible = debuxswitch
        debux.Visible = debuxswitch
        Label1.Visible = debuxswitch
        Button3.Visible = debuxswitch
        Button5.Visible = debuxswitch
        LineShape1.Visible = debuxswitch
        wait.Visible = True
        TextBox4.Text = SystemInformation.UserName
        'removed temporarily Button2_Click(Me, New System.EventArgs)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'this part gets all groups (non recursive) that the current user is member of and displays them in listview (red for read only, green for rw)
        Hourglass(True)
        'context ctx can either point to domain (the one we are logged in) or machine (the one we are logged on) 
        Try 'catch error if we cannot proceed with the search e.g. no DC available.
            Dim ctx As New PrincipalContext(ContextType.Domain)
            'Dim ctx As New PrincipalContext(ContextType.Machine)
            Dim qbeuser As New UserPrincipal(ctx)
            qbeuser.SamAccountName = CStr(TextBox4.Text)
            Dim p As New PrincipalSearcher(qbeuser)
            Dim members = p.FindAll
            ListBox2.Items.Clear()
            ListView3.Items.Clear() 'housekeeping reset admin group list. 
            reset_action_colors() 'housekeeping : reset actions buttons and fields.
            Dim cntuser As Integer = members.Count
            If cntuser = 0 Then
                MsgBox("Retry", CType(vbOK, MsgBoxStyle), "No user with that name found")
                Exit Sub
            End If
            Using members
                For Each member In members
                    Me.debux.AppendText("number of users found by search : " & CStr(cntuser) & vbCrLf)
                    Me.debux.AppendText(member.SamAccountName & member.DisplayName & vbCrLf)
                    'ListBox2.Items.Add(member.SamAccountName)
                    ' here, we get all the groups our user is memberof, we will display only the groups contained in the OU he is part of.
                    Using p1 = UserPrincipal.FindByIdentity(ctx, member.SamAccountName)
                        'Dim groups = p1.GetGroups()
                        Dim groupsA = p1.GetAuthorizationGroups()
                        Dim groups = p1.GetGroups()
                        Dim mygroups = groups
                        If RecurseGrps.CheckState = 1 Then
                            mygroups = groupsA
                        Else
                            mygroups = groups
                        End If
                        'ok careful here : changing groups feed to be getAuthorisationGroups instead of getgroups
                        '     Dim groups = p1.GetAuthorizationGroups()
                        'Dim groups = p1.GetGroups()
                        Using mygroups
                            Dim tmpListofGroups As New List(Of String)
                            For Each group In mygroups
                                Me.debux.AppendText(group.SamAccountName & group.DisplayName & vbCrLf)
                                ' lv2.SubItems.Add(group.SamAccountName & group.DisplayName & vbCrLf)
                                ' AddItemToListView(group.DisplayName, group.SamAccountName)
                                'Dim initial As String = GetChar(CStr(group.SamAccountName), 1)
                                Dim initial As String = group.SamAccountName.Substring(0, 4)
                                '' If (initial = "SCHG" Or initial = "SBRU" Or initial = "SDAR" Or initial = "SKAT" Or initial = "SFRA" Or initial = "SEA " Or initial = "SEA_") Then
                                If (True) Then
                                    'If Not initial = "x" Then 'for the moment, we display only the groups starting by S, 
                                    'I need to find a way to display only those of the OU. (that shall come later, see button 5 code)
                                    Dim pto As String()
                                    'pto = New String() {"allowedChildClasses"}
                                    'pto = New String() {"allowedAttributes"}
                                    pto = New String() {"allowedAttributesEffective"}
                                    For Each ptt In pto
                                        debux.AppendText("string is " & ptt & vbCrLf)
                                    Next
                                    'Dim testrw As New DirectoryEntry("LDAP://" & group.DistinguishedName, "serco-eu\pascal olin", "OBafgkmn0")
                                    Dim testrw As New DirectoryEntry("LDAP://" & group.DistinguishedName)
                                    debux.AppendText("checking rights to group " & group.DistinguishedName & vbCrLf)
                                    testrw.RefreshCache(pto)
                                    Dim thisgroupro As Boolean = True
                                    Dim s3 As Integer
                                    s3 = testrw.Properties("allowedAttributesEffective").Count
                                    debux.AppendText("number of attributesEffective for this group " & CStr(s3) & " " & group.DistinguishedName & vbCrLf)
                                    thisgroupro = True
                                    If s3 > 0 Then thisgroupro = False
                                    If thisgroupro = True Then
                                        tmpListofGroups.Add("READ" & "^" & CStr(group.SamAccountName))
                                        ''  AddItemToListView("READ", CStr(group.SamAccountName))
                                        'ListBox1.Items.Add("READ ONLY GROUP : " & group.DisplayName & group.SamAccountName & group.DistinguishedName)
                                    Else
                                        ''    AddItemToListView("Edit", CStr(group.SamAccountName))
                                        tmpListofGroups.Add("Edit" & "^" & CStr(group.SamAccountName))

                                    End If
                                    Label2.Visible = True
                                End If 'if the initial 4 chars of the group is not one of ours, then simply do not display it (good enough for me) 

                            Next

                            ' This is where  we must fill up the listview (from a sorted array) as the .net framework 
                            ' Does not support listview sorting. 
                            tmpListofGroups.Sort()
                            tmpListofGroups.Reverse()
                            For Each ttt As String In tmpListofGroups
                                '' debug debux.AppendText(ttt)
                                Dim po1() As String = Split(ttt, "^")


                                ' the list is sorted by group name, fill up the listview 
                                AddItemToListView(po1(0), po1(1))
                            Next
                        End Using
                    End Using
                    lblUserDN.Text = member.DistinguishedName
                Next
            End Using
            'predict_array("Add") = Val(predict_array("Add")) + 5
            ' reset_action_colors() 'clean the board
            activate_add_user() ' we may want to add a user after a selection has been made here
        Catch ex As Exception
            Dim extext As String
            extext = ex.Message
            MsgBox("Operation failed with severe exception: " & vbCrLf & extext, , "Aborting")
            'temporarily disabled Me.Close() 'close form 1, call all destruct methods
        End Try
        '        End Using
        ListView1.Items.Clear()
        Hourglass(False) 'Turn off wait panel
        wait.Visible = False
    End Sub
    Public Sub Hourglass(ByVal Show As Boolean) 'Used to toggle wait panel
        Dim Point As New System.Drawing.Point()
        If (Show = True) Then
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Point.X = 50
            Point.Y = 50
            wait.Location = Point
            wait.Show()
        Else
            Point.X = 850
            Point.Y = 850
            wait.Location = Point
            wait.Show()
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Private Sub AddItemToListView(ByVal Item As String, ByVal Item2 As String)
        Dim str(2) As String
        Dim lv As ListViewItem
        str(0) = Item
        str(1) = Item2
        lv = New ListViewItem(str)
        lv.ForeColor = Color.Green
        lv.Font = New Font(lv.Font, FontStyle.Bold)
        If Item = "Truc" Or Item = "READ" Then
            lv.Font = New Font(lv.Font, FontStyle.Italic)
            lv.ForeColor = Color.Red
        End If
        ListView3.Items.Add(lv)
    End Sub

    Public Shared Function GetADProperty(ByVal de As DirectoryEntry, ByVal pName As String) As String
        Dim pValue As String
        Try
            pValue = de.Properties(pName).Value.ToString() 'When value is found return it. . .
        Catch
            pValue = "" 'When property dosn't exist set value to null and return . . .
            'MsgBox("Property Notfound =" & pName)
        End Try
        Return (pValue) '. . .here
    End Function

    Private Sub ListView3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        Button3.Visible = True
        Button3.Text = ListView3.Items(ListView3.FocusedItem.Index).SubItems(0).Text
        Me.debux.AppendText("Selected group is : " & CStr(ListView3.Items(ListView3.FocusedItem.Index).SubItems(0).Text))
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        ' a user has been selected in the search result box of user list (listbox1) 
        Hourglass(True)
        target_is_group = False
        tbuser.Text = CStr(ListBox1.SelectedItem)
        Me.debux.AppendText("Selected user is : " & CStr(ListBox1.SelectedItem))
        tbuser.BackColor = Color.LightGreen 'set the selected user textbox green to show we have a valid name
        valid_uname = True
        Button1_Click(Me, New System.EventArgs)
        'reset_action_colors() 'clean the board
        activate_add_user() 'this is normally what happens at this point (add a user to a group) 
        activate_reset_user() 'but it might be we want to reset the user's password.
        Hourglass(False)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'this part gets all users in a group and returns their samaccountname in listbox2
        'Dim ctx As New PrincipalContext(ContextType.Machine)
        'There should be a try catch here ... 
        Try
            Dim ctx As New PrincipalContext(ContextType.Domain)
            Using p = GroupPrincipal.FindByIdentity(ctx, CStr(TbGroup.Text)) 'textbox tbgroup hold the name of the group we are working on
                ' As System.DirectoryServices.AccountManagement.MatchType
                Dim members = p.GetMembers
                ListBox2.Items.Clear()
                Label3.Visible = True
                Label3.Text = "Group " & CStr(TbGroup.Text) & " Composed of"
                Using (members)
                    For Each member In members
                        Me.debux.AppendText(member.SamAccountName & member.DisplayName & vbCrLf)
                        ListBox2.Items.Add(member.SamAccountName)
                        debux.AppendText(CStr(member.StructuralObjectClass) & vbCrLf)
                    Next
                End Using
            End Using
            valid_gname = True
            If Not tbuser.Text = "" Then activate_add_user()
            TbGroup.BackColor = Color.LightGreen 'set the selected user textbox green to show we have a valid name
        Catch ex As Exception
            Dim extext As String
            extext = ex.Message
            MsgBox("Operation Get group users failed with severe exception: " & vbCrLf & extext, , "Error")
            Me.Close() 'close form 1, call all destruct methods
        End Try

    End Sub
    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        debux.AppendText("Decision made : " & CStr(ListBox2.SelectedItem))
        tbuser.Text = CStr(ListBox2.SelectedItem)
        valid_uname = True
        tbuser.BackColor = Color.LightGreen 'set the selected user textbox green to show we have a valid name
        If Not (TbGroup.Text = "" And tbuser.Text = "") Then Button8.BackColor = Color.LightGreen
        activate_remove_user() 'a priori this is a remove user action 
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ' this part returns in listbox1 all users samaccountname that matches the text in textbox2.
        'V2 R3 this also will fill up the group box listbox4

        'Using ctx As New PrincipalContext(ContextType.Machine)
        Try 'catch error if we cannot proceed with the search e.g. no DC available.
            Dim ctx As New PrincipalContext(ContextType.Domain)
            'Dim ctx As New PrincipalContext(ContextType.Machine)
            Dim qbeuser As New UserPrincipal(ctx)
            'qbeuser.DisplayName = CStr(TextBox2.Text)
            qbeuser.SamAccountName = CStr(TextBox2.Text)
            Dim p As New PrincipalSearcher(qbeuser)
            'p.QueryFilter = 
            Dim members = p.FindAll
            ListBox1.Items.Clear()
            Dim cntuser As Integer = members.Count
            If cntuser = 0 Then
                ' MsgBox("Retry", CType(vbOK, MsgBoxStyle), "No user matching " & qbeuser.DisplayName & " found")
                'Exit Sub
            Else
                Using members
                    For Each member In members
                        Me.debux.AppendText("number of users found by search : " & CStr(cntuser) & vbCrLf)
                        Me.debux.AppendText(member.SamAccountName & member.DisplayName & vbCrLf)
                        ListBox1.Items.Add(CStr(member.SamAccountName))
                        'ListBox1.Items.Add(CStr(member.DisplayName))
                        'ListBox4.Items.Add(CStr(member.DisplayName))
                    Next
                End Using
                reset_action_colors()
                If Not (TbGroup.Text = "" And tbuser.Text = "") Then Button7.BackColor = Color.LightGreen
            End If
            Dim qbegroup As New GroupPrincipal(ctx)
            Dim pg As New PrincipalSearcher(qbegroup)
            'qbegroup.DisplayName = CStr(TextBox2.Text)
            qbegroup.SamAccountName = CStr(TextBox2.Text)
            Dim groups = pg.FindAll
            ListBox4.Items.Clear()
            Dim cntgroup As Integer = groups.Count
            If cntgroup = 0 Then
                ' MsgBox("Retry", CType(vbOK, MsgBoxStyle), "No Group matching " & qbeuser.DisplayName & " found")
                ' Exit Sub
            Else
                Using groups
                    For Each group In groups
                        Me.debux.AppendText("number of groups found by search : " & CStr(cntgroup) & vbCrLf)
                        Me.debux.AppendText(group.SamAccountName & group.DisplayName & vbCrLf)
                        Dim initial As String = group.SamAccountName.Substring(0, 4)
                        If (initial = "SCHG" Or initial = "SBRU" Or initial = "SDAR" Or initial = "SKAT" Or initial = "SFRA" Or initial = "SEA " Or initial = "SEA_") Then
                            'If Not initial = "x" Then 'for the moment, we display only the groups starting by S, 
                            'I need to find a way to display only those of the OU. (that shall come later, see button 5 code)
                            ListBox4.Items.Add(CStr(group.SamAccountName))
                        End If
                    Next
                End Using
                reset_action_colors()
                If Not (TbGroup.Text = "" And tbuser.Text = "") Then Button7.BackColor = Color.LightGreen
            End If
            ' Button10_Click(Me, New System.EventArgs)
            reset_action_colors() 'the users list has been refreshed, reset the actions area to avoid danger.
        Catch ex As Exception
            Dim extext As String
            extext = ex.Message
            MsgBox("Operation Get Matching users failed with severe exception: " & vbCrLf & extext, , "Error")
            Me.Close() 'close form 1, call all destruct methods
        End Try
    End Sub

    Private Sub debug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles debug.CheckedChanged
        'RaiseEvent.form1.load()
        Form1_Load(Me, New System.EventArgs)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Using Root As New DirectoryEntry ' connection objet to current logged on user
            '       'same as  above in the context ctx, we either point to the domain (root) of the directorysearcher object, or to the machine SAM
            Try
                Using searcher2 As New DirectorySearcher(Root)
                    'Using searcher2 As New DirectorySearcher("LDAP://dc=serco,dc=eu")
                    searcher2.Filter = "(&(objectClass=OrganizationalUnit))"
                    ' "(&(objectCategory=user)(ANR=" & TextBox4.Text & " * )) " 
                    searcher2.SearchScope = SearchScope.Subtree
                    searcher2.PropertiesToLoad.Add("name")
                    searcher2.PropertiesToLoad.Add("distinguedName")
                    Using ous = searcher2.FindAll
                        'MsgBox("found" & CStr(ous.Count), CType(vbOK, MsgBoxStyle))
                        ' For Each ou In ous
                        For Each ou As SearchResult In ous
                            ' debux.AppendText("ou : " & CStr(ou.GetType.Name))
                            debux.AppendText("ou : " & CStr(ou.Properties("Name").Item(0)) & vbCrLf)
                            'Dim adr As New ActiveDirectoryAuditRule(ou.Properties("SID"), ActiveDirectoryRights.AccessSystemSecurity, System.Security.AccessControl.AuditFlags.Success)
                            'Using ttt As New System.Security.Principal.GenericPrincipal(CType(ou, Security.Principal.IIdentity), ActiveDirectoryRights.ExtendedRight)
                        Next
                    End Using
                End Using
            Catch ex As Exception
                Dim extext As String
                extext = ex.Message
                MsgBox("Operation OU Build failed with severe exception: " & vbCrLf & extext, , "Error")
                Me.Close() 'close form 1, call all destruct methods
            End Try

        End Using

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'here we determine the user's OU. this is needed to be able to get the groups of this OU and therefore the scope of this 
        'user's modification realm.
        Hourglass(True) 'cosmetics  . should find a better way to display activity.
        'context ctx can either point to domain (the one we are logged in) or machine (the one we are logged on) 
        Try 'catch error if we cannot proceed with the search e.g. no DC available.
            'Dim ctx As New PrincipalContext(ContextType.Domain, "sbru-dc-03.serco.eu", "OU=Users,OU=Serco Europe,DC=serco,DC=eu")
            'Dim ctx As New PrincipalContext(ContextType.Machine)
            Dim ctx As New PrincipalContext(ContextType.Domain) 'original searching the whole domain...
            Dim qbeuser As New UserPrincipal(ctx)
            qbeuser.SamAccountName = CStr(TextBox4.Text)
            Dim p As New PrincipalSearcher(qbeuser)
            Dim members = p.FindAll 'find the user stored in textbox4.
            'ListBox1.Items.Clear() 'house keeping
            Dim cntuser As Integer = members.Count
            'we want one and only 1 user returned. 
            If cntuser = 0 Then
                MsgBox("Retry", CType(vbOK, MsgBoxStyle), "No user with that name found")
                Exit Sub
            End If
            If cntuser > 1 Then
                MsgBox("Retry", CType(vbOK, MsgBoxStyle), "More than 1 user returned ")
                Exit Sub
            End If
            Using members   'members is the list of 1 user returned by the p.findall method
                For Each member In members
                    Me.debux.AppendText("number of users found by search : " & CStr(cntuser))
                    Me.debux.AppendText(member.SamAccountName & member.DisplayName & vbCrLf)
                    ListBox2.Items.Add(member.SamAccountName)
                    'following 2 lines have to be moved to the right section (where we actually get the group members, using button3
                    Label3.Visible = True
                    Label3.Text = "Group " & CStr(TbGroup.Text) & " Composed of"

                    ' here, we get all the groups our user is memberof, we will display only the groups contained in the OU he is part of.
                    Using p1 = UserPrincipal.FindByIdentity(ctx, member.SamAccountName)
                        Dim group As DirectoryEntry = CType(p1.GetUnderlyingObject(), DirectoryEntry)
                        Dim tt As String
                        tt = group.Path
                        TbGroup.Text = tt

                    End Using
                Next
            End Using
        Catch ex As Exception
            MsgBox("No connection to a domain controller available, try to rehook to the AD domain", , "Aborting")
        End Try
        'now we have the full distinguedname in textbox5 (to be improved by a local variable)
        'we want to loop through each OU and extract their information.
        Dim str_container As String = " "
        Dim bits As String() = TbGroup.Text.Split(New Char() {","c}) 'we have stored the full container in textbox5 during the above (private) loop. 
        ' now we process it !
        ' Loop through result strings with For Each
        Dim bit As String
        For Each bit In New ReverseIterator(bits)
            ' For Each bit In bits
            'right now we should have the distinguished name split into bit ...
            'we therefore have each OU name ... and what we want it the comments field (and maybe some others) of each OU
            ' we are processing the context in reverse order, this means that we are able to recreate the 
            'container, bit by bit, in other terms, we examine the ous one after the other in the right order
            debux.AppendText("object found for that user: " & bit & vbCrLf)
            'Dim initial As String = GetChar(CStr(bit), 2)
            Dim initial As String = bit.Substring(0, 2) 'check if this an OU or anything else (e.g. dc= or CN=)
            If Not UCase(initial) = "OU" Then
                ' if the node is not an OU we still build our container with relevant information (have to as it has to be complete
                ' we just do not examine the properties for anything else than an OU
                debux.AppendText("not an ou : " & bit & " " & initial & vbCrLf)
                str_container = "," & bit & str_container
                Continue For
            End If
            'If we reach this point, it means that the node we are investigating (bit) is an OU
            Dim ou As String = bit.Substring(3)
            'getting this OU properties one after the other. 
            debux.AppendText("found OU : " & ou & vbCrLf)
            str_container = "OU=" & ou & str_container 'still building the container as there is often OU encapsulated in OU
            debux.AppendText("strcontainer = " & str_container & vbCrLf)
            '
            ' Warning, we should have a try catch sequence here in case of exception
            '
            Dim thisOU As New DirectoryEntry("LDAP://" & str_container) ' now we force thisou to point to the currently built container(e.g.LDAP://OU=xxx,dc=yyy,dc=zzz)
            debux.AppendText("ou name could be : " & CStr(thisOU.Name) & vbCrLf)
            '''' debux.AppendText("ou name could be : " & CStr(thisOU.Properties.Item("Description"(0))) & vbCrLf)
            ' the following small loop counts the and list the properties directly accessible of the current container
            Dim tte As System.Collections.ICollection = thisOU.Properties.PropertyNames
            For Each ttel In tte
                debux.AppendText("ou name could be : " & CStr(ttel) & vbCrLf) 'report the property name.
            Next
            debux.AppendText("number of properties is : " & CStr(thisOU.Properties.Count) & vbCrLf) 'number of DIRECTLY accessible OU properties
            ' the following is a tentative to get the OU's additional ACL by other methods as I cannot find a way to do it directly
            'Dim acls As New DirectoryServices.ExtendedRightAccessRule(thisOU, AccountManagement.GroupPrincipal("bidule"))
            Dim security_desc As SecurityDescriptor = CType(thisOU.Properties("ntSecurityDescriptor").Value, SecurityDescriptor)
            Dim acl As AccessControlList = CType(security_desc.DiscretionaryAcl, AccessControlList)
            Dim ace As AccessControlEntry
            For Each ace In CType(acl, IEnumerable)
                debux.AppendText("Trustee : {0} " & ace.Trustee & vbCrLf)
                debux.AppendText("AccessMask: {0} " & ace.AccessMask & vbCrLf)
                debux.AppendText("Access Type: {0} " & ace.AceType & vbCrLf)
            Next
        Next
        Hourglass(False)
    End Sub

    Private Sub ListView3_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView3.DoubleClick, ListView3.Click
        If tbuser.Text = "" Then reset_action_colors() 'reset the actions area as we either are changing group or we start the app.
        'Button3.Visible = True 'not important now it is out of focus
        TbGroup.Text = ListView3.Items(ListView3.FocusedItem.Index).SubItems(1).Text
        Me.debux.AppendText("Selected group is : " & CStr(ListView3.Items(ListView3.FocusedItem.Index).SubItems(1).Text))
        Button3_Click(Me, New System.EventArgs)
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        'this sub 
        Dim my_item As ListViewItem
        Button3.Visible = True
        Dim checkeditems As ListView.CheckedListViewItemCollection = ListView3.CheckedItems
        If ListView3.CheckedItems.Count > 1 Then
            MsgBox("You can only check one group !", vbExclamation, "Warning")
        Else
            For Each my_item In checkeditems
                TbGroup.Text = my_item.SubItems(1).Text
            Next
            'TbGroup.Text = ListView3.SelectedListViewItemCollection
            'TbGroup.Text = ListView3.Items(ListView3.SelectedItems.Item)     FocusedItem.Index).SubItems(1).Text
            Me.debux.AppendText("Selected group is : " & CStr(TbGroup.Text))
            TbGroup.BackColor = Color.LightGreen 'set the selected user textbox green to show we have a valid name
            Button3_Click(Me, New System.EventArgs)
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If Not TbGroup.Text = "" Then
            If Not tbuser.Text = "" Then
                'OvalShape1.BorderColor = Color.LightGreen
                'OvalShape1.BorderWidth = 3
                'Button7.Enabled = True
                'Button8.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'add a user (in tbuser) to a group (in tbgroup), 
        If Not TbGroup.Text = "" Then
            If Not tbuser.Text = "" Then
                If MsgBox("You are about to add " & tbuser.Text & " to " & TbGroup.Text & " !", vbOKCancel, "Confirm") = vbOK Then
                    Try
                        Dim ctx As New PrincipalContext(ContextType.Domain)
                        Using p = GroupPrincipal.FindByIdentity(ctx, CStr(TbGroup.Text)) 'textbox tbgroup hold the name of the group we are working on
                            ' As System.DirectoryServices.AccountManagement.MatchType
                            If target_is_group Then
                                Dim up As GroupPrincipal = GroupPrincipal.FindByIdentity(ctx, tbuser.Text)
                                p.Members.Add(up)
                                p.Save()
                            Else
                                Dim up As UserPrincipal = UserPrincipal.FindByIdentity(ctx, tbuser.Text)
                                p.Members.Add(up)
                                p.Save()
                            End If

                        End Using
                        valid_gname = True
                    Catch ex As Exception
                        MsgBox("Operation ADD user failed with severe exception", , "Error")
                        MsgBox(ex.Message.ToString() & " is the error")
                    End Try
                End If
            End If
        End If
        Form1_Load(Me, New System.EventArgs)
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'remove a user (in tbuser) to a group (in tbgroup), 
        If Not TbGroup.Text = "" Then
            If Not tbuser.Text = "" Then
                If MsgBox("You are about to Remove " & tbuser.Text & " from " & TbGroup.Text & " !", vbOKCancel, "Confirm") = vbOK Then
                    Try
                        Dim ctx As New PrincipalContext(ContextType.Domain)
                        Using p = GroupPrincipal.FindByIdentity(ctx, CStr(TbGroup.Text)) 'textbox tbgroup hold the name of the group we are working on
                            ' As System.DirectoryServices.AccountManagement.MatchType

                            p.Members.Remove(ctx, IdentityType.SamAccountName, tbuser.Text)
                            p.Save()
                        End Using
                        valid_gname = True
                    Catch ex As Exception
                        MsgBox("Operation REMOVE user failed with severe exception", , "Error")
                    End Try
                End If
            End If
        End If
        Form1_Load(Me, New System.EventArgs)
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        'If Asc(e.KeyChar) = 13 Then
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Button4_Click(Me, New System.EventArgs)
        End If
    End Sub

    Sub predict()
        ' this code should be called each time the user has done anything to predict what he is trying to achieve. 
        ' ideally the array "predict" could be fitted with 3 indexes (add,remove,reset) and we could add prediction like this : 
        'predict(add) += 5, or predict(reset) -=3 and in here sort the predict array by value and pick up the highest index after sort. 
        'problem is that associative arrays don't seeem to exist in vb.net ....
        'Dim firstvar As Dictionary(Of String, Integer)
        'firstvar = (From entry In predict_array Order By entry.Value Descending Select entry).ToDictionary(KeyValuePair(Of => 
        'MsgBox(" at the moment, the highest probable action is " & CStr(predict_array.OrderBy(), CType(vbOK, MsgBoxStyle), "Information")

        'MsgBox("values are : for Add : " & CStr(predict_array("Add")) & " for remove :  " & CStr(predict_array("Remove")) & " for reset : " & CStr(predict_array("Reset")), CType(vbOK, MsgBoxStyle))

    End Sub
    Sub reset_action_colors()
        TbGroup.Text = ""
        tbuser.Text = ""
        OvalShape1.BorderColor = Color.White
        OvalShape1.BorderWidth = 1
        RectangleShapeA.SendToBack()
        RectangleShapeR.SendToBack()
        Button7.BackColor = Color.White
        Button8.BackColor = Color.White
        Button7.Enabled = False
        Button8.Enabled = False
        TbGroup.BackColor = Color.White
        tbuser.BackColor = Color.White
        NewPasswordBox.BackColor = Color.White
        NewPasswordBox.Text = ""
        NewPasswordBox.Enabled = False
        Button11.BackColor = Color.White
        newgroupBox.Enabled = False  'we want to control what is entered in there
        newgroupBox.BackColor = Color.White
        newgroupBox.Text = ""
        newgroupButton.Enabled = True 'no reason to ever hide this one
        newgroupdescrbox.Text = ""
        newgroupdescrbox.BackColor = Color.White
    End Sub
    Sub activate_add_user()
        If Not TbGroup.Text = "" Then
            If Not tbuser.Text = "" Then
                OvalShape1.BorderColor = Color.LightGreen
                OvalShape1.BorderWidth = 3
                OvalShape1.SendToBack()
                RectangleShapeA.SendToBack()
                RectangleShapeR.BringToFront()
                Button7.Enabled = True
                Button8.Enabled = False
                Button7.BackColor = Color.LightGreen
            End If
        End If
    End Sub
    Sub activate_remove_user()
        If Not TbGroup.Text = "" Then
            If Not tbuser.Text = "" Then
                OvalShape1.BorderColor = Color.LightGreen
                OvalShape1.BorderWidth = 3
                OvalShape1.SendToBack()
                RectangleShapeR.SendToBack()
                RectangleShapeA.BringToFront()
                Button8.Enabled = True
                Button7.Enabled = False
                Button8.BackColor = Color.LightGreen
            End If
        End If
    End Sub
    Sub activate_reset_user()
        If Not tbuser.Text = "" Then
            Button11.Enabled = True
            Button11.BackColor = Color.LightGreen
            NewPasswordBox.Enabled = True
            NewPasswordBox.BackColor = Color.LightGreen
        End If
    End Sub
    Sub deactivate_reset_user()
        'regardless
        Button11.Enabled = False
        Button11.BackColor = Color.White
        NewPasswordBox.Enabled = False
        NewPasswordBox.BackColor = Color.White

    End Sub
    Private Sub ListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox3.SelectedIndexChanged
        'A group (of the previously selected user) has been selected in the group listbox3
        Hourglass(True)
        Dim ugrp As String = CStr(ListBox3.SelectedItem)
        Dim tt3 As ListViewItem = ListView3.FindItemWithText(ugrp, True, 0, True) ' go through  listview 1 to offer the focus to that group
        If tt3 IsNot Nothing Then
            ListView3.TopItem = tt3
            ListView3.Focus()
            tt3.Focused = True
            tt3.Selected = True
            ListView3_DoubleClick(tt3, New System.EventArgs)
            TbGroup.Text = ugrp 'set the group field (after all this is a valid way of selecting a group) 
            'reset_action_colors() 'clean the board
            activate_remove_user() 'a priori action is to remove the user from that group.
        End If
        Hourglass(False)
    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        'reset password has been selected for that user.
        Dim newpwd As String
        If NewPasswordBox.Text = "" Then
            If Not tbuser.Text = "" Then
                ' first click on reset password for this user . 
                ' highlight the password textzone and the password reset button .
                NewPasswordBox.BackColor = Color.LightGreen
                NewPasswordBox.Enabled = True
                Button11.BackColor = Color.LightGreen
                Label16.Text = "Enter new password for user " & tbuser.Text
            End If
        Else
            'second click on the reset pw button : just do it ! 
            newpwd = NewPasswordBox.Text
            If Not tbuser.Text = "" Then
                If MsgBox("You are about to reset password of " & tbuser.Text & " !", vbOKCancel, "Confirm") = vbOK Then
                    Try
                        Dim ctx As New PrincipalContext(ContextType.Domain)
                        Using u = UserPrincipal.FindByIdentity(ctx, CStr(tbuser.Text)) 'textbox tbuser holds the name of the user we are working on
                            ' As System.DirectoryServices.AccountManagement.MatchType
                            u.SetPassword(newpwd)
                            u.UnlockAccount()
                            u.Save()
                        End Using
                        valid_gname = True
                    Catch ex As Exception
                        Dim extext As String = ex.InnerException.ToString
                        extext = ex.Message
                        MsgBox("Operation Reset password user failed with severe exception: " & vbCrLf & extext, , "Error")
                    End Try
                    reset_action_colors() 'clear the board
                    Form1_Load(Me, New System.EventArgs) 'reload the whole app. 
                End If 'Admin said he or she was sure .... 
            End If 'end of part testing if we were on the first or second click 
        End If
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' Here we need to insert all the actions required to close the active connections and sessions.
    End Sub
    Private Sub newgroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newgroupButton.Click
        'here we clicked on the create group button 
        Hourglass(True)
        Dim tmp = get_user_ou()
        Dim full = tmp(2).Substring(1) 'remove the comma
        Dim tmp1 = tmp(1)
        If newgroupBox.Text = "" Then
            'first time click on it : set the board 
            newgroupBox.BackColor = Color.LightGreen
            newgroupdescrbox.Enabled = True
            newgroupdescrbox.BackColor = Color.LightGreen
            newgroupBox.Enabled = True
            newgroupprefixbox.Text = naming_convention(tmp1) 'go and get the naming convention for that group
            newgroupBox.Focus() ' focus to the group name
        Else
            'second click, just do it . 
            Dim fullgroupname As String = newgroupprefixbox.Text & " " & newgroupBox.Text
            MsgBox("Creating group: " & fullgroupname)
            If Not (newgroupBox.Text = "" Or newgroupdescrbox.Text = "") Then
                If MsgBox("You are about to create the group " & fullgroupname & " in the Organisational Unit " & tmp1 & " using path " & full, vbOKCancel, "Confirm") = vbOK Then
                    Try
                        Dim newgp As GroupPrincipal

                        Dim ctx As New PrincipalContext(ContextType.Domain, "serco.eu", full) ' forces the focus of the context to point to my current OU
                        newgp = New GroupPrincipal(ctx)
                        With newgp
                            .Name = fullgroupname
                            .IsSecurityGroup = True
                            .GroupScope = GroupScope.Global
                            .SamAccountName = fullgroupname
                            .Description = newgroupdescrbox.Text
                            .Save()
                        End With
                        Threading.Thread.Sleep(1000)
                        tbuser.Text = TextBox4.Text
                        TbGroup.Text = fullgroupname
                        Threading.Thread.Sleep(1000)
                        Button7_Click(Me, New System.EventArgs) 'add current logged admin to new group.
                        Threading.Thread.Sleep(1000)
                    Catch ex As Exception
                        Dim extext As String
                        extext = ex.Message
                        MsgBox("Operation add group failed with severe exception: " & vbCrLf & extext, , "Error")
                    End Try
                Else : Form1_Load(Me, New System.EventArgs) 'reload the whole app. 
                End If
            Else
                MsgBox("Both group name and description are mandatory: ", CType(vbAbort, MsgBoxStyle), "Error")
            End If
        End If
        Hourglass(False)
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Hourglass(True)
    End Sub
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Hourglass(False)
    End Sub

    Private Sub tips_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tips.CheckedChanged
        Form1_Load(Me, New System.EventArgs) 'reload the whole app.
    End Sub

    Private Sub ListBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox4.SelectedIndexChanged
        ' a group has been selected in the search result box of user list (listbox1) 
        Hourglass(True)
        tbuser.Text = CStr(ListBox4.SelectedItem)
        Me.debux.AppendText("Selected user is : " & CStr(ListBox1.SelectedItem))
        tbuser.BackColor = Color.LightGreen 'set the selected user textbox green to show we have a valid name
        valid_uname = True
        ' Button1_Click(Me, New System.EventArgs) 'valid only for user, we MAY want to replicate the button1 action later
        'if it is required to display the groups that this group is memeber of ... we will see with version3
        'reset_action_colors() 'clean the board
        target_is_group = True
        activate_add_user() 'this is normally what happens at this point (add a user to a group) 
        deactivate_reset_user() 'too dangerous to leave that active
        'activate_reset_user() 'not for groups .... 
        Hourglass(False)
    End Sub


    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Form1_Load(Me, New System.EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecurseGrps.CheckedChanged
        Form1_Load(Me, New System.EventArgs)
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub
End Class