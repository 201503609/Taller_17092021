Imports System.Data.SqlClient

Public Class Form1

    Dim conn As New SqlConnection("Server=localhost\SQLEXPRESS;Database=Taller;Trusted_Connection=True;")

    Private Sub Nombre_Click(sender As Object, e As EventArgs) Handles Nombre.Click

    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Try
            Dim command As New SqlCommand("INSERT INTO Estudiante VALUES (@nombre,@apellido,@edad,@direccion,@telefono)", conn)
            command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtNombre.Text
            command.Parameters.Add("@apellido", SqlDbType.VarChar).Value = txtApellido.Text
            command.Parameters.Add("@edad", SqlDbType.Int).Value = Convert.ToInt32(txtEdad.Text)
            command.Parameters.Add("@direccion", SqlDbType.VarChar).Value = txtDireccion.Text
            command.Parameters.Add("@telefono", SqlDbType.VarChar).Value = txtTel.Text
            conn.Open()

            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Se registro de forma correcta el usuario")
            Else
                MessageBox.Show("No se logro registrar el usuario")
            End If

            conn.Close()
            MostrarDatos()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarDatos()
    End Sub

    Private Sub MostrarDatos()
        Try
            Dim command As New SqlCommand("SELECT * FROM Estudiante", conn)
            Dim dataAdapter As New SqlDataAdapter(command)
            Dim dataSet As New DataSet
            dataAdapter.Fill(dataSet, "Estudiante")
            dgvEstudiantes.DataSource = dataSet.Tables("Estudiante")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            Dim command As New SqlCommand("UPDATE Estudiante SET nombre=@nombre WHERE id=@id", conn)
            command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtNombre.Text
            command.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(txtId.Text)

            conn.Open()

            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Se modifico correctamente el usuario")
            Else
                MessageBox.Show("No se logro modificar el usuario")
            End If

            conn.Close()
            MostrarDatos()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim command As New SqlCommand("DELETE FROM Estudiante WHERE id = @id", conn)
        command.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(txtId.Text)
        conn.Open()

        If command.ExecuteNonQuery() = 1 Then
            MessageBox.Show("Se elimino correctamente el usuario")
        Else
            MessageBox.Show("No se logro eliminar el usuario")
        End If

        conn.Close()
        MostrarDatos()

    End Sub
End Class
