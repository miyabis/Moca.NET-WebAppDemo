
Namespace Sys

    ''' <summary>
    ''' SysSettings のモジュール
    ''' </summary>
    ''' <remarks></remarks>
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(), _
      Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
    Public Module SysSettingsProperty

        ''' <summary>構成ファイルのDB接続情報</summary>
        Public Const C_CONNECTION_STRING As String = "MocaDemo.My.MySettings.Db"

        ''' <summary>
        ''' 当システムの設定値
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("Sys.Settings")> _
        Public ReadOnly Property Settings() As Global.MocaDemo.Sys.SysSettings
            Get
                Return Global.MocaDemo.Sys.SysSettings.Instance
            End Get
        End Property

    End Module

End Namespace
