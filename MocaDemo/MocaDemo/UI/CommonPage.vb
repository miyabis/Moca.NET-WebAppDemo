Imports Moca.Util

Namespace UI

    ''' <summary>
    ''' 当システムのページ用抽象クラス
    ''' </summary>
    ''' <remarks>
    ''' ページは当抽象クラスを継承してください。
    ''' </remarks>
    Public Class CommonPage
        Inherits Moca.Web.UI.MocaPage

#Region " Declare "

        ''' <summary>アラート</summary>
        Protected Friend alerts As Moca.Web.UI.BootstrapAlerts

        ''' <summary>入力値検証</summary>
        Protected validator As Moca.Util.Validator

        ''' <summary>入力値検証開始</summary>
        Private _validationStart As Boolean

#End Region

#Region " Handles "

        ''' <summary>
        ''' 初期化
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
            Me._validationStart = True
            validator = New Moca.Util.Validator
            Me.alerts = _getBootstrapAlert()
        End Sub

#End Region

#Region " Methods "

        ''' <summary>
        ''' エラーメッセージ設定
        ''' </summary>
        ''' <param name="caption"></param>
        ''' <param name="validatorControl"></param>
        ''' <param name="ctrl"></param>
        ''' <param name="value"></param>
        ''' <param name="rcVerify"></param>
        ''' <param name="min"></param>
        ''' <param name="max"></param>
        ''' <param name="showMessage"></param>
        ''' <param name="ctrls"></param>
        ''' <remarks></remarks>
        Protected Sub setErrorMessage(ByVal caption As String, ByVal validatorControl As BaseValidator, ByVal ctrl() As WebControl, ByVal value As String, ByVal rcVerify As ValidateTypes, Optional ByVal min As Object = Nothing, Optional ByVal max As Object = Nothing, Optional ByVal showMessage As Boolean = True, Optional ByVal ctrls() As WebControl = Nothing)
            _initError(validatorControl, ctrl)

            If Not showMessage Then
                Return
            End If

            If rcVerify = ValidateTypes.None Then
                Return
            End If

            ' 必須
            If Not validator.IsValidRequired(rcVerify) Then
                Me.setError(validatorControl, ctrl, MessageIDs.E001, caption)
            End If

            ' 数字
            If Not validator.IsValidNumeric(rcVerify) Then
                Me.setError(validatorControl, ctrl, MessageIDs.E002, caption)
            End If

            ' 日付
            If Not validator.IsValidDateFormat(rcVerify) Then
                Me.setError(validatorControl, ctrl, MessageIDs.E002, caption)
            End If

            ' 数値
            If Not validator.IsValidDecimal(rcVerify) Then
                Me.setError(validatorControl, ctrl, MessageIDs.E002, caption)
            End If

            ' 最小桁数
            If Not validator.IsValidLenghtMin(rcVerify) Then
                Me.setError(validatorControl, ctrl, MessageIDs.E004, caption, min.ToString, value.Length)
            End If
            ' 最小桁数半角で
            If Not validator.IsValidLenghtMinB(rcVerify) Then
                Me.setError(validatorControl, ctrl, MessageIDs.E004, caption, min.ToString, VBUtil.LenB(value))
            End If

            ' 最大桁数
            If Not validator.IsValidLenghtMax(rcVerify) Then
                Me.setError(validatorControl, ctrl, MessageIDs.E003, caption, max.ToString, value.Length)
            End If
            ' 最大桁数半角で
            If Not validator.IsValidLenghtMaxB(rcVerify) Then
                Me.setError(validatorControl, ctrl, MessageIDs.E003, caption, max.ToString, VBUtil.LenB(value))
            End If

            ' 半角英数
            If Not validator.IsValidHalfWidthAlphanumeric(rcVerify) Then
                Me.setError(validatorControl, ctrl, MessageIDs.E002, caption)
            End If

            ' 半角
            If Not validator.IsValidInJis(rcVerify) Then
                Me.setError(validatorControl, ctrl, MessageIDs.E002, caption)
            End If

            ' TEL
            If Not validator.IsValidTel(rcVerify) Then
                Me.setError(validatorControl, ctrl, MessageIDs.E002, caption)
            End If

            ' MAIL
            If Not validator.IsValidMail(rcVerify) Then
                Me.setError(validatorControl, ctrl, MessageIDs.E002, caption)
            End If

            ' ZIP
            If Not validator.IsValidZip(rcVerify) Then
                Me.setError(validatorControl, ctrl, MessageIDs.E002, caption)
            End If

            ' URL
            If Not validator.IsValidURL(rcVerify) Then
                Me.setError(validatorControl, ctrl, MessageIDs.E002, caption)
            End If

            '' 最小値
            'If validator.IsValidateType(rcVerify, ValidateTypes.Minimum) Then
            '	If showMessage Then
            '		Me.setError(validatorControl, ctrl, MessageIDs.E003, caption, min.ToString)
            '	End If
            'End If

            '' 最大値
            'If validator.IsValidateType(rcVerify, ValidateTypes.Maximum) Then
            '	If showMessage Then
            '		Me.setError(validatorControl, ctrl, MessageIDs.E004, caption, max.ToString)
            '	End If
            'End If
        End Sub

        ''' <summary>
        ''' コントロールのエラー表示解除
        ''' </summary>
        ''' <param name="inputCtrl"></param>
        ''' <remarks></remarks>
        Protected Sub clearControlError(ByVal inputCtrl() As WebControl)
            For Each ctrl As WebControl In inputCtrl
                ctrl.ToolTip = String.Empty
                ctrl.BorderColor = Drawing.Color.FromArgb(204, 204, 204)
                ctrl.BorderWidth = New Unit(1)
            Next
        End Sub

        ''' <summary>
        ''' 処理エラー設定
        ''' </summary>
        ''' <param name="validCtrl"></param>
        ''' <param name="inputCtrl"></param>
        ''' <param name="msgID"></param>
        ''' <param name="val"></param>
        ''' <remarks></remarks>
        Protected Overloads Sub setError(ByVal validCtrl As BaseValidator, ByVal inputCtrl() As WebControl, ByVal msgID As MessageIDs, ByVal ParamArray val() As String)
            Dim message As String
            message = Sys.Util.GetMessage(msgID, val)
            _alertError(validCtrl, message, inputCtrl)
        End Sub

        ''' <summary>
        ''' コントロールのエラー表示設定
        ''' </summary>
        ''' <param name="message"></param>
        ''' <param name="inputCtrl"></param>
        ''' <remarks></remarks>
        Protected Overloads Sub setControlError(ByVal message As String, ByVal inputCtrl() As WebControl)
            If inputCtrl Is Nothing Then
                Return
            End If
            For Each ctrl As WebControl In inputCtrl
                ctrl.ToolTip = message
                ctrl.BorderColor = Drawing.Color.FromArgb(231, 76, 60)
                ctrl.BorderWidth = New Unit(2)
            Next
        End Sub

        ''' <summary>
        ''' BootstrapAlerts
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property _getBootstrapAlert As Moca.Web.UI.BootstrapAlerts
            Get
                Return DirectCast(Me.Master, UI.IAlerts).Alerts
            End Get
        End Property

        ''' <summary>
        ''' エラーメッセージ初期化
        ''' </summary>
        ''' <param name="validatorControl"></param>
        ''' <param name="ctrl"></param>
        ''' <remarks></remarks>
        Private Sub _initError(ByVal validatorControl As BaseValidator, ByVal ctrl() As WebControl)
            If _validationStart Then
                validatorControl.ErrorMessage = String.Empty
                _validationStart = False
            End If
            If ctrl Is Nothing Then
                Return
            End If
            Me.clearControlError(ctrl)
        End Sub

        ''' <summary>
        ''' エラーメッセージを設定する
        ''' </summary>
        ''' <param name="validCtrl">検証コントロール</param>
        ''' <param name="message">検証結果のメッセージ</param>
        ''' <remarks></remarks>
        Private Overloads Sub _alertError(ByVal validCtrl As BaseValidator, ByVal message As String, ByVal inputCtrl() As WebControl)
            _initError(validCtrl, inputCtrl)

            validCtrl.IsValid = False

            setControlError(message, inputCtrl)

            alerts.Error(message)
        End Sub

#End Region

    End Class

End Namespace
