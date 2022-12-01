using FreeSql;
using FreeSqlLikeProblem;
using MySql.Data.MySqlClient;
using System;

var mysqlConnection = "Server=127.0.0.1;port=3306;Database=test;user id=root;password=123456;";

using (var connection = new MySqlConnection(mysqlConnection))
{
    try
    {
        connection.Open();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"mysql连接错误--{ex.Message}");
    }
}

var fsql = new FreeSqlBuilder().UseConnectionString(DataType.MySql, mysqlConnection).Build();
var searchTerms = "姓名_";
var names = fsql.Select<User>().Where(e => e.Name.Contains(searchTerms)).ToList(e => e.Name);
Console.WriteLine($"关键词: {searchTerms}, 搜索结果：{string.Join(',', names)}");

searchTerms = "姓名%";
names = fsql.Select<User>().Where(e => e.Name.Contains(searchTerms)).ToList(e => e.Name);
Console.WriteLine($"关键词: {searchTerms}, 搜索结果：{string.Join(',', names)}");


searchTerms = "姓_";
names = fsql.Select<User>().Where(e => e.Name.Contains(searchTerms)).ToList(e => e.Name);
Console.WriteLine($"关键词: {searchTerms}, 搜索结果：{string.Join(',', names)}");


searchTerms = "姓%";
names = fsql.Select<User>().Where(e => e.Name.Contains(searchTerms)).ToList(e => e.Name);
Console.WriteLine($"关键词: {searchTerms}, 搜索结果：{string.Join(',', names)}");