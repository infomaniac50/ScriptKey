using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
namespace Utility
{
    /// <summary>
    /// Provides some common functions from Visual Basic programs you cant in C# programs.
    /// </summary>
    public static class Information
    {
        /// <summary>
        /// Determines whether the file is a .NET assembly.
        /// </summary>
        /// <param name="FilePath">The file path.</param>
        /// <returns>
        /// 	<c>true</c> if the file is a .NET assembly; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDotNetAssembly(string FilePath)
        {
            bool result;
            uint peHeader;
            uint peHeaderSignature;
            ushort machine;
            ushort sections;
            uint timestamp;
            uint pSymbolTable;
            uint noOfSymbol;
            ushort optionalHeaderSize;
            ushort characteristics;
            ushort dataDictionaryStart;
            uint[] dataDictionaryRVA = new uint[16];
            uint[] dataDictionarySize = new uint[16];


            Stream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fs);

            //PE Header starts @ 0x3C (60). Its a 4 byte header.
            fs.Position = 0x3C;

            peHeader = reader.ReadUInt32();

            //Moving to PE Header start location...
            fs.Position = peHeader;
            peHeaderSignature = reader.ReadUInt32();

            //We can also show all these value, but we will be       
            //limiting to the CLI header test.

            machine = reader.ReadUInt16();
            sections = reader.ReadUInt16();
            timestamp = reader.ReadUInt32();
            pSymbolTable = reader.ReadUInt32();
            noOfSymbol = reader.ReadUInt32();
            optionalHeaderSize = reader.ReadUInt16();
            characteristics = reader.ReadUInt16();

            /*
            Now we are at the end of the PE Header and from here, the
            PE Optional Headers starts...
            To go directly to the datadictionary, we'll increase the      
            stream’s current position to with 96 (0x60). 96 because,
            28 for Standard fields
            68 for NT-specific fields
            From here DataDictionary starts...and its of total 128 bytes. DataDictionay has 16 directories in total,
            doing simple maths 128/16 = 8.
            So each directory is of 8 bytes.
            In this 8 bytes, 4 bytes is of RVA and 4 bytes of Size.
           
            btw, the 15th directory consist of CLR header! if its 0, its not a CLR file :)
            */
            dataDictionaryStart = Convert.ToUInt16(Convert.ToUInt16
            (fs.Position) + 0x60);
            fs.Position = dataDictionaryStart;
            for (int i = 0; i < 15; i++)
            {
                dataDictionaryRVA[i] = reader.ReadUInt32();
                dataDictionarySize[i] = reader.ReadUInt32();
            }
            if (dataDictionaryRVA[14] == 0)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            fs.Close();
            return result;
        }


        /// <summary>
        /// Determines whether the specified expression is numeric.
        /// </summary>
        /// <param name="Expression">The expression.</param>
        /// <returns>
        /// 	<c>true</c> if the specified expression is numeric; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumeric(string Expression)
        {
            double num;

            return double.TryParse(Expression, out num);
        }

        /// <summary>
        /// Determines whether the specified value is null.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified value is null; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNothing(object Value)
        {
            return (Value == null);
        }

        /// <summary>
        /// Gets the path for the executable file that started the application, including the executable name.
        /// </summary>
        /// <value>The executable path.</value>
        public static string ExecutablePath
        {
            get
            {
                return Application.ExecutablePath;
            }
        }

        /// <summary>
        /// Gets the directory the application's executable file resides in.
        /// </summary>
        /// <value>The executable path.</value>
        public static string ExecutableDirectory
        {
            get
            {
                return Path.GetDirectoryName(ExecutablePath); 
            }
        }

    }
}
