using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;

namespace WindowsFormsApplication1
{
    [Serializable()]
    public class Book
    {
        public List<string> AuthorsList;
        public string Name { get; set; }
        public DateTime RealiseDate;
        public string Annotation;
        public string ImagePath;
        public string Genre;
        public string Categuro;

        [XmlIgnore()]
        public string Authors
        {
            get
            {
                if (AuthorsList.Count != 0)
                {
                    string result = AuthorsList[0];
                    for (var i = 1; i < AuthorsList.Count; i++)
                        result += (", " + AuthorsList[i]);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            set { }
        }
        [XmlIgnore()]
        public string GetRealiseDate
        {
            get { return RealiseDate.Day.ToString() + "." + RealiseDate.Month.ToString() + "." + RealiseDate.Year.ToString(); }
            set { }
        }
        [XmlIgnore()]
        public Bitmap Image { get
            { return new Bitmap(ImagePath); } private set { } }

        public Book() { }
        public Book(string[] _a, string _n, DateTime _d, string _ann, string _imPath, string _gen, string _cat)
        {
            AuthorsList = new List<string>();
            foreach (var item in _a)
            {
                AuthorsList.Add(item);
            }
            Name = _n;
            RealiseDate = _d;
            Annotation = _ann;
            ImagePath = _imPath;
            Genre = _gen;
            Categuro = _cat;
        }
        public void BookChanged(string[] _a, string _n, DateTime _d, string _ann, string _imPath, string _gen, string _cat)
        {
            AuthorsList = new List<string>();
            foreach (var item in _a)
            {
                AuthorsList.Add(item);
            }
            Name = _n;
            RealiseDate = _d;
            Annotation = _ann;
            ImagePath = _imPath;
            Genre = _gen;
            Categuro = _cat;
        }

        ~Book() { }
        //enum Category { }
    }
}
