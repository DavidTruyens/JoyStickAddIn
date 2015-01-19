Imports System
Imports System.Type
Imports System.Activator
Imports System.Runtime.InteropServices
Imports Inventor

Public Class Form1

    Private _invApp As Inventor.Application
    Private _Doc As Inventor.AssemblyDocument
    Private WithEvents joystick1 As Joystick
    Private WithEvents joystick2 As Joystick

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _invApp = Marshal.GetActiveObject("Inventor.Application")
        _Doc = _invApp.ActiveDocument

        Dim oParm As Parameters
        oParm = _Doc.ComponentDefinition.Parameters

        Dim iParm As Integer

        For iParm = 1 To oParm.Count
            If oParm.Item(iParm).IsKey Then
                Param1.Items.Add(oParm.Item(iParm).Name)
                Param2.Items.Add(oParm.Item(iParm).Name)
            End If
        Next

        If Me.Param1.Items.Count = 0 Then
            MsgBox("Add a key to the parameters you would like to use!")
        Else
            Param1.Text = Param1.Items(1)
            Param2.Text = Param1.Items(1)
        End If

    End Sub
    Private Sub Param1_SelectedValueChanged(sender As Object, e As EventArgs) Handles Param1.SelectedValueChanged
        SetLimits(Param1, Min1, Max1, TrackBar1)
    End Sub
    Private Sub Param2_SelectedValueChanged(sender As Object, e As EventArgs) Handles Param2.SelectedValueChanged
        SetLimits(Param2, Min2, Max2, TrackBar2)
    End Sub


    Private Sub SetLimits(Box As System.Windows.Forms.ComboBox, Min As System.Windows.Forms.TextBox, Max As System.Windows.Forms.TextBox, Slider As System.Windows.Forms.TrackBar)
        Dim i As Integer
        i = Box.SelectedIndex

        Dim CurrentSelection As String
        CurrentSelection = Box.Items(i).ToString

        Dim CurrentValue As Double
        CurrentValue = _Doc.ComponentDefinition.Parameters.Item(CurrentSelection).Value

        Dim oPars As Parameters
        oPars = _Doc.ComponentDefinition.Parameters

        Dim oType As String
        oType = oPars.Item(CurrentSelection).Units
        Select Case oType
            Case "deg"
                Min.Text = (180 * (oPars.Item(CurrentSelection).Value) / Math.PI) - 10
                Max.Text = (180 * (oPars.Item(CurrentSelection).Value) / Math.PI) + 10

            Case "mm"
                Min.Text = oPars.Item(CurrentSelection).Value * 10 - 10
                Max.Text = oPars.Item(CurrentSelection).Value * 10 + 10

        End Select
        Slider.Value = 50
        _Doc.Update()

    End Sub

    Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar1.ValueChanged
        Slide(Param1, Min1, Max1, TrackBar1)
    End Sub
    Private Sub TrackBar2_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar2.ValueChanged
        Slide(Param2, Min2, Max2, TrackBar2)
    End Sub


    Private Sub Slide(Box As System.Windows.Forms.ComboBox, Min As System.Windows.Forms.TextBox, Max As System.Windows.Forms.TextBox, Slider As System.Windows.Forms.TrackBar)
        Dim i As Integer
        i = Box.SelectedIndex

        Dim CurrentSelection As String
        CurrentSelection = Box.Items(i).ToString

        Dim oPars As Parameters
        oPars = _Doc.ComponentDefinition.Parameters

        Dim oType As String
        oType = oPars.Item(CurrentSelection).Units

        Dim numbercheck As Boolean
        numbercheck = IsNumeric(Max.Text) And IsNumeric(Min.Text)

        Dim minVal As Double
        Dim maxVal As Double

        If numbercheck Then
            minVal = CDbl(Min.Text)
            maxVal = CDbl(Max.Text)

            Select Case oType
                Case "deg"
                    oPars.Item(CurrentSelection).Value = (Slider.Value * (maxVal - minVal) / 100 + minVal) * Math.PI / 180

                Case "mm"
                    oPars.Item(CurrentSelection).Value = (Slider.Value * (maxVal - minVal) / 100 + minVal) / 10

            End Select
            _Doc.Update()

        Else
            MsgBox("Make sure there are numbers in the limit boxes!")
        End If

    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        joystick1 = New Joystick(Me, 0)
        'joystick2 = New Joystick(Me, 1)

    End Sub

    Private Sub joystick1_Down() Handles joystick1.Down
        If Me.TrackBar1.Value >= 10 Then
            Me.TrackBar1.Value = Me.TrackBar1.Value - 10
        End If
    End Sub

    Private Sub joystick1_Up() Handles joystick1.Up
        If Me.TrackBar1.Value <= 90 Then
            Me.TrackBar1.Value = Me.TrackBar1.Value + 10
        End If
    End Sub

    Private Sub joystick1_Left() Handles joystick1.Left
        If Me.TrackBar2.Value >= 10 Then
            Me.TrackBar2.Value = Me.TrackBar2.Value - 10
        End If
    End Sub
    Private Sub joystick1_Right() Handles joystick1.Right
        If Me.TrackBar2.Value <= 90 Then
            Me.TrackBar2.Value = Me.TrackBar2.Value + 10
        End If
    End Sub
End Class


