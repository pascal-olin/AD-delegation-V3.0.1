﻿'****************************** Module Header ******************************'
'Module Name:  MainModule.vb
'Project:      SEADelegatedADManagement1
'Copyright (c) Microsoft Corporation.
'
'This sample application demonstrates how to perform a search on the user’s 
'group membership in Active Directory. This demonstrates the recursive 
'looping method. Also it shows how to get the Object SID for the group.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************'
Option Strict On

Imports System.DirectoryServices
Imports System.DirectoryServices.ActiveDirectory
Imports System.DirectoryServices.AccountManagement
Imports System.Text


'Module MainModule

'    Public Sub Main()
'        'MsgBox("starting application")
'        'Dim ttform As New Form1
'        'ttform.ShowDialog()
'        ' A priori this main is never gonna get executed as this is a form app
'        'MsgBox("Closing application")

'        Dim aa = New System.DirectoryServices.AccountManagement.PrincipalServerDownException

'    End Sub

'    ''' <summary>
'    ''' This function will search the user. 
'    ''' Once user is found, it will get it's memberOF attribute's value.
'    ''' </summary>
'    ''' <param name="domainDN">distinguishedName of the domain</param>
'    ''' <param name="sAMAccountName">
'    ''' sAMAccountName of the user for which we are searching the group membership in AD
'    ''' </param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Function GetUserGroupsiiii(ByVal domainDN As String, ByVal sAMAccountName As String) As List(Of String)
'        Try
'            Form1.debux.AppendText("connecting to AD using string " & "LDAP://" & domainDN & vbCrLf)

'            'Create the DirectoryEntry object to bind the distingusihedName of your domain
'            Using rootDE As New DirectoryEntry("LDAP://" & domainDN)
'                ' Using rootDE As New DirectoryEntry(" 
'                'Create a DirectorySearcher for performing a search on abiove created DirectoryEntry
'                Using dSearcher As New DirectorySearcher(rootDE)

'                    'Create the sAMAccountName as filter
'                    dSearcher.Filter = "(&(sAMAccountName=" & sAMAccountName & ")(objectClass=User)(objectCategory=Person))"
'                    dSearcher.PropertiesToLoad.Add("memberOf")
'                    dSearcher.ClientTimeout.Add(New TimeSpan(0, 20, 0))
'                    dSearcher.ServerTimeLimit.Add(New TimeSpan(0, 20, 0))

'                    'Search the user in AD
'                    Dim sResult As SearchResult = dSearcher.FindOne
'                    If sResult Is Nothing Then
'                        Throw New ApplicationException("No user with username " & sAMAccountName & " could be found in the domain")
'                    Else
'                        Dim lGroups As New List(Of String)
'                        'Once we get the userm let us get all the memberOF attibute's value
'                        For Each grp In sResult.Properties("memberOf")
'                            Dim sGrpName As String = CStr(grp).Remove(0, 3)
'                            'Bind to this group
'                            Dim deTempForSID As New DirectoryEntry("LDAP://" + grp.ToString().Replace("/", "\/"))

'                            Try
'                                deTempForSID.RefreshCache()

'                                'Get the objectSID which is Byte array
'                                Dim objectSid As Byte() = DirectCast(deTempForSID.Properties("objectSid").Value, Byte())

'                                'Pass this Byte array to Security.Principal.SecurityIdentifier to convert this 
'                                'byte array to SDDL format
'                                Dim SID As New System.Security.Principal.SecurityIdentifier(objectSid, 0)

'                                If sGrpName.Contains(",CN") Then
'                                    sGrpName = sGrpName.Remove(sGrpName.IndexOf(",CN"))
'                                ElseIf sGrpName.Contains(",OU") Then
'                                    sGrpName = sGrpName.Remove(sGrpName.IndexOf(",OU"))
'                                End If

'                                'Perform a recursive search on these groups.
'                                RecursivelyGetGroups(dSearcher, lGroups, sGrpName, SID.ToString())
'                            Catch ex As Exception
'                                'Console.WriteLine("Error while binding to path : " + grp.ToString())
'                                'Console.WriteLine(ex.Message.ToString())
'                                Form1.debux.AppendText("Error while binding to path : " & grp.ToString() & vbCrLf)
'                            End Try
'                        Next
'                        Return lGroups
'                    End If
'                End Using
'            End Using
'        Catch ex As Exception
'            'Console.WriteLine("Please check the distinguishedName of the domain if it is as per your domain or not?")

'            Form1.debux.AppendText("Please check the distinguishedName of the domain if it is as per your domain or not? --> We are handling this exception" & vbCrLf)
'            'Console.WriteLine(ex.Message.ToString())
'            'Console.ReadLine()
'            '
'            Form1.debux.AppendText("fin de plantage")
'            Form1.Show()

'            Dim lGroups As New List(Of String)
'            'MsgBox("fin de plantage")
'            Form1.debux.AppendText("End of controlled exception management code, something went wrong but we recovered" & vbCrLf)

'            Return lGroups

'            End
'        Finally
'            Form1.debux.AppendText("Recovery from finally reached" & vbCrLf)
'            'Form1.ShowDialog()

'        End Try
'    End Function

'    ''' <summary>
'    ''' This function will perform a recursive search and will add only one occurance of 
'    ''' the group found in the enumeration.
'    ''' </summary>
'    ''' <param name="dSearcher">DirectorySearcher object to perform search</param>
'    ''' <param name="lGroups">List of the Groups from AD</param>
'    ''' <param name="sGrpName">
'    ''' Group name which needs to be checked inside the Groups collection
'    ''' </param>
'    ''' <param name="SID">objectSID of the object</param>
'    ''' <remarks></remarks>
'    Public Sub RecursivelyGetGroups(ByVal dSearcher As DirectorySearcher, ByVal lGroups As List(Of String), ByVal sGrpName As String, ByVal SID As String)
'        'Check if the group has already not found
'        If Not lGroups.Contains(sGrpName) Then
'            lGroups.Add(sGrpName & " : " & SID)

'            'Now perform the search based on this group
'            dSearcher.Filter = "(&(objectClass=grp)(CN=" & sGrpName & "))".Replace("\", "\\")
'            dSearcher.ClientTimeout.Add(New TimeSpan(0, 2, 0))
'            dSearcher.ServerTimeLimit.Add(New TimeSpan(0, 2, 0))

'            'Search this group
'            Dim GroupSearchResult As SearchResult = dSearcher.FindOne
'            If Not GroupSearchResult Is Nothing Then
'                For Each grp In GroupSearchResult.Properties("memberOf")
'                    Dim ParentGroupName As String = CStr(grp).Remove(0, 3)

'                    'Bind to this group
'                    Dim deTempForSID As New DirectoryEntry("LDAP://" + grp.ToString().Replace("/", "\/"))
'                    Try
'                        'Get the objectSID which is Byte array
'                        Dim objectSid As Byte() = DirectCast(deTempForSID.Properties("objectSid").Value, Byte())

'                        'Pass this Byte array to Security.Principal.SecurityIdentifier to convert this 
'                        'byte array to SDDL format
'                        Dim ParentSID As New System.Security.Principal.SecurityIdentifier(objectSid, 0)

'                        If ParentGroupName.Contains(",CN") Then
'                            ParentGroupName = ParentGroupName.Remove(ParentGroupName.IndexOf(",CN"))
'                        ElseIf ParentGroupName.Contains(",OU") Then
'                            ParentGroupName = ParentGroupName.Remove(ParentGroupName.IndexOf(",OU"))
'                        End If
'                        RecursivelyGetGroups(dSearcher, lGroups, ParentGroupName, ParentSID.ToString())
'                    Catch ex As Exception
'                        Console.WriteLine("Error while binding to path : " + grp.ToString())
'                        Console.WriteLine(ex.Message.ToString())
'                    End Try
'                Next
'            End If
'        End If
'    End Sub

'End Module
