using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestEightQueen;

public class EightQueenTests
{
    [Test]
    public void Test1()
    {
        var queen = new Queen();
        var expected = new List<List<string>>
        {
            new()
            {
                ".Q..", "...Q", "Q...", "..Q."
            },
            new()
            {
                "..Q.", "Q...", "...Q", ".Q.."
            }
        };
        CollectionAssert.AreEqual(expected, queen.Solve(4));
    }
}

public class Queen
{
    private readonly List<List<string>> _result = new List<List<string>>();

    public List<List<string>> Solve(int n)
    {
        DFS(n, 0, new int[n]);
        return _result;
    }

    private void DFS(int n, int row, int[] exist)
    {
        if (row == n)
        {
            var list = new List<string>();
            for (var i = 0; i < n; i++)
            {
                var arr = new char[n];
                Array.Fill(arr, '.');
                arr[exist[i]] = 'Q';
                list.Add(new string(arr));
            }

            _result.Add(list);

            return;
        }

        for (var i = 0; i < n; i++)
        {
            if (IsValid(row, i, exist))
            {
                exist[row] = i;
                DFS(n, row + 1, exist);
            }
        }
    }

    private static bool IsValid(int row, int col, int[] exist)
    {
        for (var i = 0; i < row; i++)
        {
            if (exist[i] == col || exist[i] + i == row + col || i - exist[i] == row - col)
            {
                return false;
            }
        }

        return true;
    }
}