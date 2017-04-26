﻿/*>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
UnityIO was released with an MIT License.
Arther: Byron Mayne
Twitter: @ByMayne


MIT License

Copyright(c) 2016 Byron Mayne

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*/

using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace UnityIO.Interfaces
{
    public interface IDirectory : IEnumerable<IDirectory>, IComparer<IDirectory>, IEquatable<IDirectory>
    {
        string path { get; }

        void Delete();

        IDirectory CreateSubDirectory(string path);
        IDirectory Duplicate();
        IDirectory Duplicate(string newName);

        void Move(string targetDirectory);
        void Move(IDirectory targetDirectory);

        void Rename(string newName);

        void DeleteSubDirectory(string directroyName);
        bool SubDirectoryExists(string directoryName);

        bool IsEmpty(bool directoriesCount);
        bool Exists();

        // Directories
        IDirectory this[string name] { get; }
   

        // Conditionals 
        IDirectory IfSubDirectoryExists(string name);
        IDirectory IfSubDirectoryDoesNotExist(string name);
        IDirectory IfEmpty(bool directoriesCount);
        IDirectory IfNotEmpty(bool directoriesCount);
        IDirectory IfExists();
        IDirectory IfDoesNotExist();

        // IFIle
        IFile IfFileExists(string name);

        // IFiles
        IFiles GetFiles();
        IFiles GetFiles(bool recursive);
        IFiles GetFiles(string filter);
        IFiles GetFiles(string filter, bool recursive);
    }
}
