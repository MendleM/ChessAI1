﻿Public Class Form1

    Private F As Font = New Font("Segoe UI", 12)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        With e.Graphics
            'Constant declerations
            Const SQR As Integer = 40
            Const H_DISP As Integer = 80
            Const V_DISP As Integer = 80
            Const B_THICKNESS As Integer = 30

            'Draw border
            Using b_brown As New SolidBrush(Color.FromArgb(61, 36, 17))
                .FillRectangle(b_brown, New Rectangle(H_DISP - B_THICKNESS, V_DISP - B_THICKNESS, SQR * 8 + (2 * B_THICKNESS), SQR * 8 + (2 * B_THICKNESS)))
            End Using

            'Draw white tiles
            Using b_white As New SolidBrush(Color.FromArgb(254, 222, 137))
                .FillRectangle(b_white, New Rectangle(H_DISP, V_DISP, SQR * 8, SQR * 8))
            End Using

            'Draw black tiles
            Using b_black As New SolidBrush(Color.FromArgb(142, 81, 33))
                For v = 0 To 7
                    For b = 0 To 3
                        .FillRectangle(b_black, New Rectangle((2 * (SQR * b)) + (SQR * (v Mod 2)) + H_DISP, SQR * v + V_DISP, SQR, SQR))
                    Next
                Next
            End Using

            'Draw column/row labels
            For v = 0 To 7
                Dim sz_n As Size = .MeasureString(v + 1, F).ToSize
                Dim sz_l As Size = .MeasureString(Convert.ToChar(Convert.ToInt32("A"c) + v - 1).ToString(), F).ToSize
                .DrawString(v + 1, F, Brushes.White, H_DISP - (B_THICKNESS / 2) - (sz_n.Width / 2), V_DISP + (SQR * v) + (SQR / 2) - (sz_n.Height / 2))
                .DrawString(Convert.ToChar(Convert.ToInt32("A"c) + v).ToString(), F, Brushes.White, H_DISP + (SQR * v) + (SQR / 2) - (sz_l.Width / 2), V_DISP + (SQR * 8) + (B_THICKNESS / 2) - (sz_l.Height / 2))
            Next
        End With
    End Sub
End Class
