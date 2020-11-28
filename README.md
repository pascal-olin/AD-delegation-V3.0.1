# AD-delegation-V3.0.1
Allows end-users of AD domain to peek and (if delegated) to control the content of the AD groups they are administrators of
To make this work, users running this code must be delegated access to an OU or SubOU in Active Directory



As a visual basic form application project 
it requires MS.VB.PowerPacks
and imports the following assemblies 
Imports ActiveDs
Imports System.DirectoryServices
Imports System.DirectoryServices.ActiveDirectory
Imports System.DirectoryServices.AccountManagement
Imports System.Text
Imports System.Collections.Generic
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
