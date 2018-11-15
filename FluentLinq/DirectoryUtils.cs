using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentLinq
{
    class DirectoryUtils
    {
        #region Properties
        private string _Path;
        #endregion

        #region Constructors
        public DirectoryUtils(string path)
        {
            _Path = path;
        }
        #endregion

        #region Accessors
        public string Path { get => _Path; set => _Path = value; }
        #endregion

        #region Method
        /// <summary>
        /// Liste les noms des fichiers dont leurs noms contiennent la lettre m avec query Syntaxs
        /// </summary>
        /// <returns>List<String> comportant les noms des fichier avec un m</String></returns>
        public List<string> GetFilesNameContainsMWithQuerySyntaxe(string stringToFind)
        {
            List<string> files = new DirectoryInfo(_Path).GetFiles().Select(f => f.Name).ToList();
            return (from f in files
                      where f.Contains(stringToFind)
                      select f).ToList();
        }

        /// <summary>
        /// Liste les noms des fichiers dont leurs noms contiennent la lettre m avec fluent Syntaxs
        /// </summary>
        /// <returns>List<String> comportant les noms des fichier avec un m</String></returns>
        public List<string> GetFilesNameContainsMWithFluentSyntaxe(string stringToFind)
        {
            List<string> files = new DirectoryInfo(_Path).GetFiles().Select(f => f.Name).ToList();
            return files.Where(f => f.Contains(stringToFind)).ToList();
        }
        #endregion
    }
}
