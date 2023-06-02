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

            // SQL
            string myQuery =
                @"SELECT
                    社員マスタ.*,
                    DATE_FORMAT(生年月日,'%Y-%m-%d') as 誕生日
                    from 社員マスタ";

            // SQL実行用のオブジェクトを作成
            OdbcCommand myCommand = new OdbcCommand();

            // 実行用オブジェクトに必要な情報を与える
            myCommand.CommandText = myQuery;    // SQL
            myCommand.Connection = myCon;       // 接続

            // 次でする、データベースの値をもらう為のオブジェクトの変数の定義
            OdbcDataReader myReader;
            // SELECT を実行した結果を取得
            myReader = myCommand.ExecuteReader();

            // データの読み出し
            while (myReader.Read())
            {
                for (int i = 0; i < 11; i++)
                {
                    Console.WriteLine( myReader.GetValue(i).ToString() );
                }
                Console.WriteLine( "-----------------------------" );
            }



            // 接続解除
            myCon.Close();

            Console.WriteLine("処理が修了しました");
        }
    }
}
