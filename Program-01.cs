using System;
using System.Data.Odbc;

namespace cs_0602_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("こんにちは世界");

            // 接続文字列作成
            OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder();
            builder.Driver = "MySQL ODBC 8.0 Unicode Driver";

            // 接続用のパラメータを追加
            builder.Add("server", "localhost");
            builder.Add("database", "r202");
            builder.Add("uid", "root");
            builder.Add("pwd", "");

            // 接続の作成
            OdbcConnection myCon = new OdbcConnection();

            // MySQL の接続準備完了
            myCon.ConnectionString = builder.ConnectionString;

            Console.WriteLine(builder.ConnectionString);

            // MySQL に接続
            myCon.Open();

            myCon.Close();

            Console.WriteLine("処理が修了しました");
        }
    }
}
