Imports Inventor
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports System.Windows.Forms
Imports System.Drawing


Namespace InventorAddIn1
    <ProgIdAttribute("InventorAddIn1.StandardAddInServer"), _
    GuidAttribute("5232abc7-9eb0-4192-8e61-278de9e5e336")> _
    Public Class StandardAddInServer

        Implements Inventor.ApplicationAddInServer

        ' Inventor application object.
        Private m_inventorApplication As Inventor.Application
        Private WithEvents m_buttonDef As ButtonDefinition = Nothing
        Private WithEvents m_uiEvents As UserInterfaceEvents = Nothing
        Private m_clientID As String = "{5232abc7-9eb0-4192-8e61-278de9e5e336}"
        'wB added
        Private m_AppEvents As ApplicationEvents
        Private m_Form1 As Form1

#Region "ApplicationAddInServer Members"

        Public Sub Activate(ByVal addInSiteObject As Inventor.ApplicationAddInSite, ByVal firstTime As Boolean) Implements Inventor.ApplicationAddInServer.Activate

            ' This method is called by Inventor when it loads the AddIn.
            ' The AddInSiteObject provides access to the Inventor Application object.
            ' The FirstTime flag indicates if the AddIn is loaded for the first time.

            ' Initialize AddIn members.
            m_inventorApplication = addInSiteObject.Application

            ' TODO:  Add ApplicationAddInServer.Activate implementation.
            ' e.g. event initialization, command creation etc.

            'wB added
            m_AppEvents = m_inventorApplication.ApplicationEvents
            'AddHandler m_AppEvents.OnSaveDocument, AddressOf Me.m_ApplicationEvents_OnSaveDocument


            ButtonActivation()

            If firstTime Then
                CreateUserInterface()
            End If
            ' Connect to UI events to be able to handle a UI reset.
            m_uiEvents = m_inventorApplication.UserInterfaceManager.UserInterfaceEvents

            AddHandler m_buttonDef.OnExecute, AddressOf ShowForm

        End Sub

        Public Sub ShowForm()
            m_Form1 = New Form1()
            m_Form1.ShowDialog()
        End Sub

        Public Sub Deactivate() Implements Inventor.ApplicationAddInServer.Deactivate

            ' This method is called by Inventor when the AddIn is unloaded.
            ' The AddIn will be unloaded either manually by the user or
            ' when the Inventor session is terminated.

            ' TODO:  Add ApplicationAddInServer.Deactivate implementation

            'wB added
            'RemoveHandler m_AppEvents.OnSaveDocument, AddressOf Me.m_ApplicationEvents_OnSaveDocument
            m_AppEvents = Nothing
            'wB end added

            ' Release objects.
            Marshal.ReleaseComObject(m_inventorApplication)
            m_inventorApplication = Nothing

            System.GC.WaitForPendingFinalizers()
            System.GC.Collect()

        End Sub

        Public ReadOnly Property Automation() As Object Implements Inventor.ApplicationAddInServer.Automation

            ' This property is provided to allow the AddIn to expose an API 
            ' of its own to other programs. Typically, this  would be done by
            ' implementing the AddIn's API interface in a class and returning 
            ' that class object through this property.

            Get
                Return Nothing
            End Get

        End Property

        Public Sub ExecuteCommand(ByVal commandID As Integer) Implements Inventor.ApplicationAddInServer.ExecuteCommand

            ' Note:this method is now obsolete, you should use the 
            ' ControlDefinition functionality for implementing commands.

        End Sub

        'Private Sub m_ApplicationEvents_OnSaveDocument(ByVal DocumentObject As Inventor._Document,
        '                                 ByVal BeforeOrAfter As Inventor.EventTimingEnum,
        '                                 ByVal Context As Inventor.NameValueMap,
        '                                 ByRef HandlingCode As Inventor.HandlingCodeEnum)

        '    If BeforeOrAfter = EventTimingEnum.kBefore Then
        '        Try
        '            'Check if the active document is a Drawing
        '            If m_inventorApplication.ActiveDocumentType = DocumentTypeEnum.kDrawingDocumentObject Then

        '                'Get the custom iProperties
        '                Dim oPropSet As PropertySet = m_inventorApplication.ActiveDocument.PropertySets _
        '                                              ("{D5CDD505-2E9C-101B-9397-08002B2CF9AE}")

        '                Dim bDateAdded As Boolean = False
        '                Dim bTimeAdded As Boolean = False

        '                Dim prop As Inventor.Property
        '                For Each prop In oPropSet
        '                    If prop.Name = "SysDate" Then
        '                        prop.Value = Format(Date.Now, "MMM-d-yy")
        '                        bDateAdded = True
        '                    End If

        '                    If prop.Name = "SysTime" Then
        '                        prop.Value = Format(Date.Now, "hh:mm:ss tt")
        '                        bTimeAdded = True
        '                    End If
        '                Next

        '                'If the drawing does not have the SysDate custom property
        '                If bDateAdded = False Then
        '                    oPropSet.Add(Format(Date.Now, "MMM-d-yy"), "SysDate")
        '                End If

        '                'If the drawing does not have the SysTime custom property
        '                If bTimeAdded = False Then
        '                    oPropSet.Add(Format(Date.Now, "hh:mm:ss tt"), "SysTime")
        '                End If

        '            End If ' if document is a drawing
        '        Catch ex As Exception
        '            MsgBox(ex.ToString())

        '        End Try
        '    End If 'if before save

        'End Sub

        Public Sub ButtonActivation()

            ' Get a reference to the UserInterfaceManager object. 
            Dim UIManager As Inventor.UserInterfaceManager = m_inventorApplication.UserInterfaceManager

            ' Get a reference to the ControlDefinitions object. 
            Dim controlDefs As ControlDefinitions = m_inventorApplication.CommandManager.ControlDefinitions

            ' Get the images from the resources. They are stored as .Net images and the
            ' PictureConverter class is used to convert them to IPictureDisp objects, which
            ' the Inventor API requires. 
            Dim smallPicture As IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources._16px_Gnome_joystick)
            Dim largePicture As IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources._36px_Gnome_joystick)


            ' Create the buttondefinition. 
            m_buttonDef = controlDefs.AddButtonDefinition("JoyStick", "UIRibbonSampleOne", CommandTypesEnum.kNonShapeEditCmdType, m_clientID, , , smallPicture, largePicture)
            ' Call the function to addinformation to the user-interface.

        End Sub

        Private Sub CreateUserInterface()
            ' Get a reference to the UserInterfaceManager object. 
            Dim UIManager As Inventor.UserInterfaceManager = m_inventorApplication.UserInterfaceManager
            ' Get the zero doc ribbon.
            Dim zeroRibbon As Inventor.Ribbon = UIManager.Ribbons.Item("Assembly")
            ' Get the getting started tab.
            Dim startedTab As Inventor.RibbonTab = zeroRibbon.RibbonTabs.Item("id_TabAssemble")
            ' Get the new features panel.
            Dim newFeaturesPanel As Inventor.RibbonPanel
            newFeaturesPanel = startedTab.RibbonPanels.Item("id_PanelA_AssembleRelationships")
            ' Adda buttonto the panel, using the previously created buttondefinition.
            newFeaturesPanel.CommandControls.AddButton(m_buttonDef, True)
        End Sub
#End Region

        Private Function Form1() As Form
            Throw New NotImplementedException
        End Function




    End Class

End Namespace

