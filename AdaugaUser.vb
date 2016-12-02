Public Class AdaugaUser
    'Declarea variabilelor
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True 'variabilele penru a putea muta mouse-ul
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'mouse in X
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'mouse in Y
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        'daca este activa functia drag, atunci do this
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False 'se opreste drag
    End Sub


    Private Sub AdaugaUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'Inchide forma
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()
    End Sub

    'Adauga concurent in ListView din Form1.vb
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'daca numele lipseste
        If adauganume.TextLength = 0 Then
            MsgBox("Numele nu este completat!")
        ElseIf adauganume.TextLength > 0 Then
            Dim str(2) As String
            Dim itm As ListViewItem
            str(0) = adauganume.Text
            str(1) = adaugaprenume.Text
            itm = New ListViewItem(str)
            Form1.ListView1.Items.Add(itm)
        End If
        'curata textboxurile
        adauganume.Text = ""
        adaugaprenume.Text = ""
    End Sub
    'Anuleaza adaugarea
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
