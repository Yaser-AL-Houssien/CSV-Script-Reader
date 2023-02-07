//define the arguments.
string filePath=string.Empty;
int columnIndex=0;
string searchKey=string.Empty;

//read the arguments
ReadArgs();
//main call 
Console.WriteLine(string.Join(",",ReadRecord(searchKey,filePath,columnIndex)));

//read the arguments
public  void ReadArgs()
{
    try
    {

     filePath=Args[0];
     columnIndex=Int32.Parse(Args[1]);
     searchKey=Args[2];
    }
     catch(Exception ex)
    {
          Console.WriteLine("Make sure that you pass the arguments correctly :dotnet script {ScriptName.csx} {file_path} {colum_index} {name}.");
          Console.WriteLine(" for example:dotnet script CsvReader.csx ../Info.csv 2 Alberto");
        throw new ApplicationException("This program did an oopsie :",ex);
         
    }
}

//read the csv file.
public static string[] ReadRecord(string searchTerm,string filePath,int positionOfSearchTerm)
{
    string[] recordNotFound={"Record not found"};
    
    try
    {
        string[] lines=System.IO.File.ReadAllLines(@filePath);
        
        for (int i=0;i<lines.Length;i++)
        {
            string[] fields=lines[i].Split(",");
            if(IsRecodMatches(searchTerm,fields,positionOfSearchTerm))
              return fields;
        }
    }
    catch(Exception ex)
    {
          Console.WriteLine("This program did an oopsie");
          return recordNotFound;
          throw new ApplicationException("This program did an oopsie :",ex);
    }
    return recordNotFound;
}
public static bool IsRecodMatches(string searchTerm,string[] record,int positionOfSearchTerm)
{
    if(record[positionOfSearchTerm].Equals(searchTerm))
    return true;
    return false;
}