using System;
using System.Collections;
using System.IO;
using System.Threading;


class Cell
{
    private int row;
    private int col;
    private string text;
    public Cell(int row, int col, string text)
    {
        this.text = text;
        this.col = col;
        this.row = row;
    }
    public void SetCellText(string text)
    {
        this.text = text;
    }

    public string GetCellText()
    {
        return text;
    }
}

class SharableSpreadaheet
{
    private Cell[,] spreadsheet;
    private int row;
    private int col;

    private static SemaphoreSlim maximumThreadsSemaphore;

    private static Semaphore writerSemaphore;
    private static Semaphore[] rowsOrColumnsSemaphores;

    private static Mutex checkMutexSheet;
    private static Mutex checkMutexRowsOrColumn;

    private static int[] rowsOrColumnCounter;
    private static int rowsOrColumnsIndicator;
    private int sheetReadCounter;
    private int currentUsers;

    Boolean searchLimit = false;


    public int getRow()
    {
        return row;
    }
    public int getColumn()
    {
        return col;
    }
    public SharableSpreadaheet(int nRows, int nCols)
    {
        spreadsheet = new Cell[nRows, nCols];
        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < nCols; j++)
            {
                this.spreadsheet[i, j] = new Cell(i, j, "testcell" + (i + 1) + (j + 1));
            }
        }
        writerSemaphore = new Semaphore(1, 1);
        rowsOrColumnsIndicator = nRows >= nCols ? 0 : 1;
        rowsOrColumnCounter = rowsOrColumnsIndicator == 0 ? new int[nRows] : new int[nCols];
        UpdateMutexArray(rowsOrColumnsIndicator == 0 ? nRows : nCols, true);
        checkMutexSheet = new Mutex();
        checkMutexRowsOrColumn = new Mutex();
        this.row = nRows;
        this.col = nCols;
        // construct a nRows*nCols spreadsheet
    }

    private static void UpdateMutexArray(int amount, bool makeNew)
    {
        if (makeNew)
        {
            rowsOrColumnsSemaphores = new Semaphore[amount];
        }

        for (int i = 0; i < amount; i++)
        {
            rowsOrColumnsSemaphores[i] = new Semaphore(1, 1);
        }
    }

    public String getCell(int row, int col)
    {
        void RnWCellBefore(int where)
        {

            checkMutexRowsOrColumn.WaitOne();
            rowsOrColumnCounter[where]++;
            if (rowsOrColumnCounter[where] == 1)
                rowsOrColumnsSemaphores[where].WaitOne();
            checkMutexRowsOrColumn.ReleaseMutex();
        }


        void RnWCellAfter(int where)
        {
            checkMutexRowsOrColumn.WaitOne();
            rowsOrColumnCounter[where]--;
            if (rowsOrColumnCounter[where] == 0)
                rowsOrColumnsSemaphores[where].Release();
            checkMutexRowsOrColumn.ReleaseMutex();
        }

        if (searchLimit) { maximumThreadsSemaphore.Wait(); }

        row--; col--;
        RnWSpreadSheetBefore();
        RnWCellBefore(rowsOrColumnsIndicator == 0 ? row : col);
        string returnString = spreadsheet[row, col].GetCellText();
        RnWSpreadSheetAfter();
        RnWCellAfter(rowsOrColumnsIndicator == 0 ? row : col);

        if (searchLimit) maximumThreadsSemaphore.Release();
        return returnString;

    }


    private void RnWSpreadSheetBefore()
    {
        checkMutexSheet.WaitOne();
        sheetReadCounter++;
        if (sheetReadCounter == 1)
        {
            writerSemaphore.WaitOne();
        }
        checkMutexSheet.ReleaseMutex();
    }

    private void RnWSpreadSheetAfter()
    {
        checkMutexSheet.WaitOne();
        sheetReadCounter--;
        if (sheetReadCounter == 0)
        {
            writerSemaphore.Release();
        }
        checkMutexSheet.ReleaseMutex();
    }



    public bool setCell(int row, int col, String str)
    {
        if (row < 1 || col < 1 || row > this.row + 1 || col > this.col + 1)
            return false;
        if (searchLimit) { maximumThreadsSemaphore.Wait(); }
        RnWSpreadSheetBefore();
        row--; col--;

        rowsOrColumnsSemaphores[rowsOrColumnsIndicator == 0 ? row : col].WaitOne();
        spreadsheet[row, col].SetCellText(str);
        rowsOrColumnsSemaphores[rowsOrColumnsIndicator == 0 ? row : col].Release();
        RnWSpreadSheetAfter();
        if (searchLimit) maximumThreadsSemaphore.Release();
        return true;
        // set the string at [row,col]
    }
    public bool searchString(String str, ref int row, ref int col)
    {

        if (searchLimit) { maximumThreadsSemaphore.Wait(); }
        RnWSpreadSheetBefore();
        for (int i = 0; i < this.row; i++)
        {
            for (int j = 0; j < this.col; j++)
            {
                if (str == spreadsheet[i, j].GetCellText())
                {
                    row = i + 1; col = j + 1;
                    RnWSpreadSheetAfter();
                    if (searchLimit) maximumThreadsSemaphore.Release();
                    return true;
                }
            }
        }
        RnWSpreadSheetAfter();
        if (searchLimit) maximumThreadsSemaphore.Release();
        return false;
    }

    public bool exchangeRows(int row1, int row2)
    {
        if (row1 < 1 || row2 < 1 || row1 > this.row + 1 || row2 > this.row + 1)
            return false;
        if (searchLimit) maximumThreadsSemaphore.Wait();
        writerSemaphore.WaitOne();
        row1--;
        row2--;
        if (row1 > this.row || row2 > row)
        {
            if (searchLimit) maximumThreadsSemaphore.Release();
            writerSemaphore.Release();
            return false;
        }

        string temp;
        for (int j = 0; j < col; j++)
        {
            temp = spreadsheet[row1, j].GetCellText();
            spreadsheet[row1, j].SetCellText(spreadsheet[row2, j].GetCellText());
            spreadsheet[row2, j].SetCellText(temp);
        }

        writerSemaphore.Release();
        if (searchLimit) maximumThreadsSemaphore.Release();
        return true;
    }
    public bool exchangeCols(int col1, int col2)
    {
        if (col < 1 || col2 < 1 || col1 > this.col + 1 || col2 > this.col + 1)
            return false;
        if (searchLimit) { maximumThreadsSemaphore.Wait(); }
        writerSemaphore.WaitOne();
        col1--; col2--;
        if (col1 >= this.row || col2 >= this.row)
        {
            if (searchLimit) maximumThreadsSemaphore.Release();
            writerSemaphore.Release();
            return false;
        }

        string temp;
        for (int j = 0; j < this.row; j++)
        {
            temp = spreadsheet[j, col1].GetCellText();
            spreadsheet[j, col1].SetCellText(spreadsheet[j, col2].GetCellText());
            spreadsheet[j, col2].SetCellText(temp);
        }

        // exchange the content of col1 and col2
        writerSemaphore.Release();
        if (searchLimit) maximumThreadsSemaphore.Release();
        return true;
    }
    public bool searchInRow(int row, String str, ref int col)
    {
        if (row < 1 || row > this.row + 1)
            return false;
        if (searchLimit) maximumThreadsSemaphore.Wait();
        checkMutexSheet.WaitOne();
        Interlocked.Increment(ref sheetReadCounter);
        if (sheetReadCounter == 1)
        {
            writerSemaphore.WaitOne();
        }
        checkMutexSheet.ReleaseMutex();
        row--;
        if (row > this.row)
            return false;
        for (int j = 0; j < this.col; j++)
        {
            if (spreadsheet[row, j].GetCellText() == str)
            {
                col = j + 1;
                RnWSpreadSheetAfter();
                if (searchLimit) maximumThreadsSemaphore.Release();
                return true;
            }
        }


        // perform search in specific row

        RnWSpreadSheetAfter();
        if (searchLimit) maximumThreadsSemaphore.Release(1);
        return false;
    }
    public bool searchInCol(int col, String str, ref int row)
    {
        if (col < 1 || col > this.col + 1)
            return false;
        if (searchLimit) { maximumThreadsSemaphore.Wait(); }
        RnWSpreadSheetBefore();
        col--;
        if (col > this.col)
            return false;
        for (int j = 0; j < this.row; j++)
        {
            if (spreadsheet[j, col].GetCellText() == str)
            {
                row = j + 1;
                RnWSpreadSheetAfter();
                if (searchLimit) maximumThreadsSemaphore.Release();
                return true;
            }
        }
        // perform search in specific col
        RnWSpreadSheetAfter();
        if (searchLimit) maximumThreadsSemaphore.Release();
        return false;
    }
    public bool searchInRange(int col1, int col2, int row1, int row2, String str, ref int row, ref int col)
    {
        if (row1 < 1 || col1 < 1 || row1 > this.row + 1 || col1 > this.col + 1 || row2 < 1 || col2 < 1 || row2 > this.row + 1 || col2 > this.col + 1)
            return false;

        if (row2 > row1)
        {

            int temp = row1;
            row1 = row2;
            row2 = temp;
        }
        if (col2 > col1)
        {

            int temp = col1;
            col1 = col2;
            col2 = temp;
        }
        if (searchLimit)
            maximumThreadsSemaphore.Wait();
        RnWSpreadSheetBefore();
        col1--; col2--; row1--; row2--;

        for (int i = row1; i <= row2; i++)
        {
            for (int j = col1; j <= col2; j++)
            {
                if (spreadsheet[i, j].GetCellText() == str)
                {
                    row = i + 1;
                    col = j + 1;
                    RnWSpreadSheetAfter();
                    if (searchLimit) maximumThreadsSemaphore.Release(1);
                    return true;
                }
            }

        }
        // perform search within spesific range: [row1:row2,col1:col2] 
        //includes col1,col2,row1,row2
        RnWSpreadSheetAfter();
        if (searchLimit) maximumThreadsSemaphore.Release(1);
        return false;
    }

    public bool addRow(int row1)
    {
        if (row1 < 1 || row1 > this.row + 1)
            return false;
        if (searchLimit) { maximumThreadsSemaphore.Wait(); }
        writerSemaphore.WaitOne();
        row1--;
        bool flag = false;
        Cell[,] newSpreadsheet = new Cell[row + 1, col];
        for (int i = 0; i < row + 1; i++)
        {
            for (int j = 0; j < col; j++)
            {
                newSpreadsheet[i, j] = new Cell(i, j, "");
            }
        }
        for (int i = 0; i < row; i++)
        {
            if (i == row1)
            {
                flag = true;
                i++;
            }
            for (int j = 0; j < col; j++)
            {
                if (flag)
                    newSpreadsheet[i, j].SetCellText(spreadsheet[i - 1, j].GetCellText());
                else
                {
                    newSpreadsheet[i, j].SetCellText(spreadsheet[i, j].GetCellText());
                }
            }
        }

        this.spreadsheet = newSpreadsheet;
        this.row++;
        if (rowsOrColumnsIndicator == 0)
        {
            rowsOrColumnCounter = new int[row];
            UpdateMutexArray(row, true);
        }
        writerSemaphore.Release();
        //add a row after row1
        if (searchLimit) maximumThreadsSemaphore.Release();
        return true;
    }
    public bool addCol(int col1)
    {
        if (col1 < 1 || col1 > this.col + 1)
            return false;
        if (searchLimit) { maximumThreadsSemaphore.Wait(); }
        writerSemaphore.WaitOne();
        col1--;
        bool flag = false;
        Cell[,] newSpreadsheet = new Cell[row, col + 1];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col + 1; j++)
            {
                newSpreadsheet[i, j] = new Cell(i, j, "");
            }
        }
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (j == col1)
                {
                    j++;
                    flag = true;
                }
                if (flag)
                    newSpreadsheet[i, j].SetCellText(spreadsheet[i, j - 1].GetCellText());
                else
                {
                    newSpreadsheet[i, j].SetCellText(spreadsheet[i, j].GetCellText());
                }

            }
            flag = false;
        }
        this.spreadsheet = newSpreadsheet;
        this.col++;
        if (rowsOrColumnsIndicator == 1)
        {
            rowsOrColumnCounter = new int[col];
            UpdateMutexArray(col, true);
        }
        writerSemaphore.Release();
        if (searchLimit) maximumThreadsSemaphore.Release();
        return true;
    }
    public bool save(String fileName)
    {
        if (searchLimit) maximumThreadsSemaphore.Wait();
        writerSemaphore.WaitOne();
        using (StreamWriter outfile = new StreamWriter(fileName + ".dat"))
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    outfile.Write("{0},", spreadsheet[i, j].GetCellText());
                }
                outfile.WriteLine();
            }
        // save the spreadsheet to a file fileName.
        // you can decide the format you save the data. There are several options.
        writerSemaphore.Release();
        if (searchLimit) maximumThreadsSemaphore.Release();
        return true;
    }


    public void print()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write("{0},", spreadsheet[i, j].GetCellText());
            }
            Console.WriteLine();
        }
    }

    public void setConcurrentSearchLimit(int nUsers)
    {
        writerSemaphore.WaitOne();
        if (!searchLimit)
        {
            maximumThreadsSemaphore = new SemaphoreSlim(nUsers, 1000);
            this.searchLimit = true;
            currentUsers = nUsers;
        }
        else
        {
            if (nUsers - currentUsers < 0)
            {
                writerSemaphore.Release();
                return;
            }

            for (int i = 0; i < nUsers - currentUsers; i++)
            {
                maximumThreadsSemaphore.Release();
            }

            currentUsers = nUsers;
        }
        writerSemaphore.Release();
        // this function aims to limit the number of users that can perform the search operations concurrently.
        // The default is no limit. When the function is called, the max number of concurrent search operations is set to nUsers. 
        // In this case additional search operations will wait for existing search to finish.
    }

    public bool load(String fileName)
    {
        // read the data file

        if (searchLimit) maximumThreadsSemaphore.Wait();
        writerSemaphore.WaitOne();
        StreamReader objInput = new StreamReader(fileName, System.Text.Encoding.Default);
        string contents = objInput.ReadToEnd().Trim();
        string[] split = System.Text.RegularExpressions.Regex.Split(contents, "\\s+");
        int srow, scol;
        string[] currentRow = split[0].Split(',');
        srow = split.Length;
        scol = currentRow.Length - 1;
        this.row = srow;
        this.col = scol;
        rowsOrColumnCounter = row >= col ? new int[row] : new int[col];
        UpdateMutexArray(row >= col ? row : col, true);
        rowsOrColumnsIndicator = row >= col ? 0 : 1;

        Cell[,] carr = new Cell[srow, scol]; //generate anew 2d cell array

        for (int i = 0; i < srow; i++) //insital the cell array
        {
            for (int j = 0; j < scol; j++)
            {
                carr[i, j] = new Cell(i, j, "testcell" + (i + 1) + (j + 1));
            }
        }

        int r = 0;
        foreach (string s in split)
        {
            currentRow = s.Split(',');
            for (int j = 0; j < scol; j++)
            {
                carr[r, j].SetCellText(currentRow[j]); // insert the value from the loaded value to the cell array
            }
            r++;

        }
        this.spreadsheet = carr;
        UpdateMutexArray(srow, true);
        // load the spreadsheet from fileName
        // replace the data and size of the current spreadsheet with the loaded data
        writerSemaphore.Release();
        if (searchLimit) maximumThreadsSemaphore.Release();
        return true;
    }

}