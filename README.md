Moca.NET Web Form App Demo
===================

sample application that uses a moca.net

[Moca.NET Framework](https://github.com/mocanet/MocaCore)

## 環境構築
### 拡張機能のインストール

* [Moca.NET Templates](https://visualstudiogallery.msdn.microsoft.com/7735e52f-74f2-4ac7-8172-11cde77e6290) ([v2010](https://visualstudiogallery.msdn.microsoft.com/f97a7486-560b-425a-aa05-528dd397f5ba))
* [Moca.NET Code Snippet](https://visualstudiogallery.msdn.microsoft.com/96efa364-a9d3-4352-85fc-c5d117abca7f) ([v2010](https://visualstudiogallery.msdn.microsoft.com/ef40c12b-d48e-45e5-9e18-12726b9ac1ee))

### サンプルのインストール
サンプル ギャラリーから当サンプルをインストールします。
![サンプルのインストール](Images\SampleInstall.png)

サンプルのプロジェクトを新しく作成します。
![サンプルのプロジェクト作成](Images\SampleCreate.png)

## Web Form プロジェクト作成
通常通りに新規にプロジェクトを作成してください。  
※VB.NET の場合は、Moca.NETのプロジェクトテンプレートを使うこともできます。

#### ライブラリの追加
Nuget にて Moca のライブラリを追加します。  
* Web の場合、『[Moca.NET Project Template Web Form](https://www.nuget.org/packages/Moca.NETWebFormsProject/)』

※Moca.NETのプロジェクトテンプレートを使ったときは既に追加されているため不要です。

#### ライブラリの更新
追加した Moca のライブラリを最新にします。

#### log4net を使う場合
WebConfigTransformAssemblyInfo.(vb or cs) ファイルの log4net 部分のアセンブリ属性を有効にする。

C# : Properties\WebConfigTransformAssemblyInfo.cs
```
[assembly: log4net.Config.XmlConfigurator(ConfigFile=@"log4net.config", Watch=true)]
```

VB : My Project\WebConfigTransformAssemblyInfo.vb
```
<Assembly: log4net.Config.XmlConfigurator(ConfigFile:="log4net.config", Watch:=True)>
```

#### 設定ファイルの暗号化
WebConfigTransformAssemblyInfo.(vb or cs) ファイルの Moca 部分のアセンブリ属性を有効にし、暗号種別、暗号化（複合化）したいセクション名を入力する。

C# :
```
[assembly: Moca.Configuration.SectionProtection(Moca.Configuration.ProtectionProviderType.DPAPI, "Section Name")]
```

VB :
```
<Assembly: Moca.Configuration.SectionProtection(Moca.Configuration.ProtectionProviderType.DPAPI, "Section Name")>
```
プログラムの起動時に次のメソッドを実行する。
ここまで手順通りであれば、MocaAssemblyInfo.(vb or cs) ファイルにて WebActivator を利用して実行するようになっています。
```
Moca.Configuration.SectionProtector.Protect()
```

#### 初期化・終了処理
WebActivator を利用して初期化・終了処理を行っています。
アセンブリ属性は MocaAssemblyInfo.(vb or cs) ファイルに定義してあります。

#### Web フォーム作成
Moca.NET テンプレートの 「Web フォーム」から作成してください。  
※ フォームの継承先が Page から Moca.Web.UI.MocaPage に変更されて作成されます。
なお、マスターページ、ユーザーコントロール、APIコントローラークラスも同様に Moca のクラスを継承するように作成されます。

#### セッションを使う場合
Moca.NET テンプレートの 「Web Session インタフェース」を使って作成します。
インタフェースへセッション変数名でプロパティを定義します。
セッションを利用するページで Protected 以上でインタフェースを使ったフィールドを定義します。  
※ 実装クラスは不要です。Moca.NET で実行時に自動的にセッションを割り当てます。

#### クッキーを使う場合
Moca.NET テンプレートの 「Web Cookie インタフェース」を使って作成します。  
インタフェースには HttpCookie を返す読み取り専用プロパティを定義し、インタフェースを使う時はスニペットの ICookie を使ってフィールドを定義します。

#### クエリー文字列を使う場合
クエリー文字列を取得するためのインタフェースを定義します。  
```
<Moca.Web.Attr.QueryString()>
Public Interface IQueryStrings

    <Moca.Web.Attr.QueryStringName("c")>
    Property Count As String

End Interface
```

#### ビューステートを使う場合
ビューステートを使うページで IViewState スニペットを使ってインタフェースを定義します。
ビューステートを利用するページで Protected 以上でインタフェースを使ったフィールドを定義します。  

## データベースアクセス
Moca.NET では、データベースアクセスクラスを作成してアクセスします。

### エンティティ 作成
Moca.NET テンプレートの「Entity クラス」で作成します。  
ウィザード形式で、接続先DBを選択しSQLステートメントを実行することでクラスを作成します。

### Dao 作成
Moca.NET テンプレートの「Dao クラス」で作成でき、インタフェースと実装クラスの構成で作成されます。
接続先はインタフェース毎の指定となり、Dao 属性の引数に設定ファイル（Config）の connectionStrings キーを指定することでインタフェース内のメソッドがデータベースへアクセスできるようになります。
メソッド内のコードはスニペット（DAODelete、DAOInsert、DAOSelect、DAOStoredPrepare、DAOStoredSelect、DAOStoredUpd、DAOUpdate）を使ってください。

### トランザクション処理
更新系のSQLステートメントを実行するときは、インタフェースのメソッドへ Transaction 属性を付けてください。
この属性を付けると、トランザクションの開始、コミット、例外発生時のロールバックを自動で行います。
TransactionScope（MSDTC）を使うときは設定ファイルの moca セクションの transaction タグの Type 属性へ scope を指定し、使わないときは local を指定してください。

### Dao を使う
クラスのフィールドとして Protected 以上で定義してください。
インスタンス化はライブラリで自動で行うので New しないでください。

## アスペクト
Moca.NET では、アスペクト属性を使ってインターセプターを割り込ませることができます。
アスペクト属性を付けたメソッドを持つクラスは、使う側のクラスをインジェクト（Moca.Di.MocaInjector.Inject()）してください。
インターセプタークラスは「AOP メソッドインターセプタークラス」テンプレートを使って作成します。
DaoクラスでDBをメインに使ったインターセプターは「AOP Daoインターセプタークラス」テンプレートを使用してください。


## 注意点
Moca.NET では透過プロキシを使っています。Visual Studio 2015で透過型プロキシの値をウォッチしても現状だと見ることができません。下記を参考にオプションの設定を変更することで見ることができるようになります。

[Visual Studio 2015で透過型プロキシのランタイム型をウォッチする際の注意点について](https://blogs.msdn.microsoft.com/jpvsblog/2016/03/28/visual-studio-2015-transparentproxy/)
