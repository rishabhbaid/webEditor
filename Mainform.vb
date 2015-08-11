Imports System.Drawing.Printing
Public Class Form1
#Region "File & Print"
    Private strFileName As String
    Private strPrintRecord As String
    ' Private Property TextBox1 As Object
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        ToolStripStatusLabel1.Text = "Open"
        With OpenFileDialog1
            .Filter = "Hyper text Mark Up Language(*.htm)|*.html|All Files (*.*)|*.*"
            .FilterIndex = 1
            .Title = "Open File "
        End With
        'Show the Open dialog and if the user clicks the Open button,
        'load the file
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                'Save the file path and name
                strFileName = OpenFileDialog1.FileName
                Dim fileContents As String
                fileContents = My.Computer.FileSystem.ReadAllText(strFileName)
                'Display the file contents in the text box
                TextBox1.Text = fileContents
            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, _
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ToolStripStatusLabel1.Text = "Save"
        'Set the Save dialog properties
        With SaveFileDialog1
            .DefaultExt = "txt"
            .FileName = strFileName
            .Filter = "Hyper Text Markup Language (*.html)|*.htm|All Files (*.*)|*.*"
            .FilterIndex = 1
            .OverwritePrompt = True
            .Title = " Save File  "
        End With
        'Show the Save dialog and if the user clicks the Save button,
        'save the file
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                'Save the file path and name
                strFileName = SaveFileDialog1.FileName
                My.Computer.FileSystem.WriteAllText(strFileName, TextBox1.Text, False)
            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, _
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        'Instantiate a new instance of the PrintDocument
        '  DialogsPrintDocument1 = New PrintDocument
        'Set the PrintDialog properties
        With PrintDialog1
            .AllowCurrentPage = False
            .AllowPrintToFile = False
            .AllowSelection = False
            .AllowSomePages = False
            ' .Document = DialogsPrintDocument1
            .PrinterSettings.DefaultPageSettings.Margins.Top = 25
            .PrinterSettings.DefaultPageSettings.Margins.Bottom = 25
            .PrinterSettings.DefaultPageSettings.Margins.Left = 25
            .PrinterSettings.DefaultPageSettings.Margins.Right = 25
        End With
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            'Set the selected printer settings in the PrintDocument
            '  DialogsPrintDocument1.PrinterSettings = _
            '  PrintDialog1.PrinterSettings

            'Get the print data
            strPrintRecord = TextBox1.Text
            'Invoke the Print method on the PrintDocument
            ' DialogsPrintDocument1.Print()
        End If
    End Sub
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.BackColor = ColorDialog1.Color
        End If
    End Sub
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        ToolStripStatusLabel1.Text = "New"
        TextBox1.Text = "<html>" + vbCrLf + Chr(9) + "<body>" + vbCrLf + Chr(9) + Chr(9) + "<!-- Start Coding Here-->" + vbCrLf + Chr(9) + "</body>" + vbCrLf + "</html>"
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WebBrowser1.DocumentText = TextBox1.Text
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        ToolStripStatusLabel1.Text = "Quit"
        Me.Close()
    End Sub
    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click
        ToolStripStatusLabel1.Text = "Save As.."
        Dim sfd As New SaveFileDialog
        sfd.Filter = "Text Documents (*.htm)|*.html|All Files (*.*)|*.*"
        sfd.FilterIndex = 1
        sfd.RestoreDirectory = True
        If sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim filename As String = sfd.FileName
            Dim sw As New System.IO.StreamWriter(filename, False)
            sw.WriteLine(TextBox1.Text)
            sw.Close()
        End If
    End Sub
#End Region
#Region "Edit "
    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        TextBox1.Cut()
    End Sub
    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        TextBox1.Paste()
    End Sub
    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        TextBox1.Copy()
    End Sub
    Private Sub UNDOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UNDOToolStripMenuItem.Click
        TextBox1.Undo()
    End Sub
    Private Sub REDOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REDOToolStripMenuItem.Click
        '  TextBox1.Redo()
    End Sub
#End Region
    '  Private Sub  TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles  TextBox1.KeyPress
    '    If (e.KeyChar = ChrW(Keys.Tab)) Then
    '         TextBox1.Text =  TextBox1.Text & ""
    '    End If
    ' End Sub
#Region "statusstrip"
    Private Sub OpenToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.MouseHover
        ToolStripStatusLabel1.Text = "Open"
    End Sub
    Private Sub NewToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.MouseHover
        ToolStripStatusLabel1.Text = "New"
    End Sub
    Private Sub FileToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.MouseHover
        ToolStripStatusLabel1.Text = "File"
    End Sub
    Private Sub SaveToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.MouseHover
        ToolStripStatusLabel1.Text = "Save"
    End Sub
    Private Sub SaveToolStripMenuItem1_MouseHover(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.MouseHover
        ToolStripStatusLabel1.Text = "Save As.."
    End Sub
    Private Sub ExitToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.MouseHover
        ToolStripStatusLabel1.Text = "Exit"
    End Sub
    Private Sub EToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles EToolStripMenuItem.MouseHover
        ToolStripStatusLabel1.Text = "Edit"
    End Sub
    Private Sub CutToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.MouseHover
        ToolStripStatusLabel1.Text = "Cut"
    End Sub
    Private Sub CopyToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.MouseHover
        ToolStripStatusLabel1.Text = "Copy"
    End Sub
    Private Sub PasteToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.MouseHover
        ToolStripStatusLabel1.Text = "Paste"
    End Sub
    Private Sub UNDOToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles UNDOToolStripMenuItem.MouseHover
        ToolStripStatusLabel1.Text = "Undo"
    End Sub
    Private Sub REDOToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles REDOToolStripMenuItem.MouseHover
        ToolStripStatusLabel1.Text = "Redo"
    End Sub
    Private Sub ToolStripMenuItem2_MouseHover(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.MouseHover
        ToolStripStatusLabel1.Text = "Change Coulour of the For"
    End Sub
    Private Sub PrintToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.MouseHover
        ToolStripStatusLabel1.Text = "Print"
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.TabStop = False
        MenuStrip1.TabStop = False
        WebBrowser1.TabStop = False
        TextBox1.TabIndex = 0
        StatusStrip1.TabStop = False
    End Sub

#End Region
    Private Sub H1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles H1ToolStripMenuItem.Click
        Dim h1 As String
        h1 = "<h1>Heading H1</h1>"
        TextBox1.Paste(h1)
    End Sub
End Class
